using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.IO;
using System.Net;

namespace Chapter2
{
    //This program demonstrates Buffered Streams

    //A buffer is a block of bytes in memory used to cache data, thereby reducing the number of calls to the operating system. 
    //Buffers improve read and write performance. A buffer can be used for either reading or writing, but never both simultaneously. 

    //The following code example shows how to use the BufferedStream class over the NetworkStream class to 
    //increase the performance of certain I/O operations.
    public class BufferedStreams
    {
        const int dataArraySize = 100;
        const int streamBufferSize = 1000;
        const int numberOfLoops = 10000;

        public static void Display()
        {
            
            string remoteName = "<host_computer>";

            // Create the underlying socket and connect to the server.
            Socket clientSocket = new Socket(AddressFamily.InterNetwork,
                SocketType.Stream, ProtocolType.Tcp);

            clientSocket.Connect(new IPEndPoint(
                Dns.Resolve(remoteName).AddressList[0], 1800));

            Console.WriteLine("Client is connected.\n");

            // Create a NetworkStream that owns clientSocket and
            // then create a BufferedStream on top of the NetworkStream.
            // Both streams are disposed when execution exits the
            // using statement.
            using (Stream
                netStream = new NetworkStream(clientSocket, true),
                bufStream =
                      new BufferedStream(netStream, streamBufferSize))
            {
                // Check whether the underlying stream supports seeking.
                Console.WriteLine("NetworkStream {0} seeking.\n",
                    bufStream.CanSeek ? "supports" : "does not support");

                // Send and receive data.
                if (bufStream.CanWrite)
                {
                    SendData(netStream, bufStream);
                }
                if (bufStream.CanRead)
                {
                    ReceiveData(netStream, bufStream);
                }

                // When bufStream is closed, netStream is in turn
                // closed, which in turn shuts down the connection
                // and closes clientSocket.
                Console.WriteLine("\nShutting down the connection.");
                bufStream.Close();
            }

        }

        static void SendData(Stream netStream, Stream bufStream)
        {
            DateTime startTime;
            double networkTime, bufferedTime;

            // Create random data to send to the server.
            byte[] dataToSend = new byte[dataArraySize];
            new Random().NextBytes(dataToSend);

            // Send the data using the NetworkStream.
            Console.WriteLine("Sending data using NetworkStream.");
            startTime = DateTime.Now;
            for (int i = 0; i < numberOfLoops; i++)
            {
                netStream.Write(dataToSend, 0, dataToSend.Length);
            }
            networkTime = (DateTime.Now - startTime).TotalSeconds;
            Console.WriteLine("{0} bytes sent in {1} seconds.\n",
                numberOfLoops * dataToSend.Length,
                networkTime.ToString("F1"));

            // Send the data using the BufferedStream.
            Console.WriteLine("Sending data using BufferedStream.");
            startTime = DateTime.Now;
            for (int i = 0; i < numberOfLoops; i++)
            {
                bufStream.Write(dataToSend, 0, dataToSend.Length);
            }
            bufStream.Flush();
            bufferedTime = (DateTime.Now - startTime).TotalSeconds;
            Console.WriteLine("{0} bytes sent in {1} seconds.\n",
                numberOfLoops * dataToSend.Length,
                bufferedTime.ToString("F1"));

            // Print the ratio of write times.
            Console.WriteLine("Sending data using the buffered " +
                "network stream was {0} {1} than using the network " +
                "stream alone.\n",
                (networkTime / bufferedTime).ToString("P0"),
                bufferedTime < networkTime ? "faster" : "slower");
        }

        static void ReceiveData(Stream netStream, Stream bufStream)
        {
            DateTime startTime;
            double networkTime, bufferedTime = 0;
            int bytesReceived = 0;
            byte[] receivedData = new byte[dataArraySize];

            // Receive data using the NetworkStream.
            Console.WriteLine("Receiving data using NetworkStream.");
            startTime = DateTime.Now;
            while (bytesReceived < numberOfLoops * receivedData.Length)
            {
                bytesReceived += netStream.Read(
                    receivedData, 0, receivedData.Length);
            }
            networkTime = (DateTime.Now - startTime).TotalSeconds;
            Console.WriteLine("{0} bytes received in {1} seconds.\n",
                bytesReceived.ToString(),
                networkTime.ToString("F1"));

            // Receive data using the BufferedStream.
            Console.WriteLine("Receiving data using BufferedStream.");
            bytesReceived = 0;
            startTime = DateTime.Now;

            int numBytesToRead = receivedData.Length;

            while (numBytesToRead > 0)
            {
                // Read may return anything from 0 to numBytesToRead.
                int n = bufStream.Read(receivedData, 0, receivedData.Length);
                // The end of the file is reached.
                if (n == 0)
                    break;
                bytesReceived += n;
                numBytesToRead -= n;
            }

            bufferedTime = (DateTime.Now - startTime).TotalSeconds;
            Console.WriteLine("{0} bytes received in {1} seconds.\n",
                bytesReceived.ToString(),
                bufferedTime.ToString("F1"));

            // Print the ratio of read times.
            Console.WriteLine("Receiving data using the buffered network" +
                " stream was {0} {1} than using the network stream alone.",
                (networkTime / bufferedTime).ToString("P0"),
                bufferedTime < networkTime ? "faster" : "slower");
        }

    }
}
