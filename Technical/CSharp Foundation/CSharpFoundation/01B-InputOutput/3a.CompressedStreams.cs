using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.IO;
using System.Net;
using System.IO.Compression;

namespace Chapter2
{
    //This program demonstrates Compressed Streams

    //In the I/O system inside the .NET Framework, there are two methods for compressing data: GZIP and DEFLATE. 
    //Both of these compression methods are industry-standard compression algorithms that are also free of patent protection.
    
    //In .NET framwork, these streams are implemented in the GZipStream and DeflateStream classes.

    //Both compression methods are limited to compression of uncompressed data up to 4 GB.

    public class  CompressedStreams
    {
        public static void Display()
        {
            //Both the DeflateStream and GZipStream classes use the same algorithm for compressing data. The only difference is that 
            //the GZIP specification allows for headers that include extra information that might be helpful to decompress a file with 
            //the widely used gzip tool. If you are compressing data for use only within your own system, DeflateStream is slightly smaller 
            //because of its lack of header information, but if you intend to distribute the files to be decompressed via GZIP, use GZipStream
            //instead.

            //Let us look at Compression and Decompression using the GZipStream class.

            //First instantiate a file stream that represents the un-compressed file (source stream).
            FileStream sourceFileStream = File.OpenRead("DataFile.txt");

            //Next specify the output stream.
            FileStream destFileStream = File.Create("CompressedFileGZip.zip");

            //Now instantiate a GZipStream class and point to the output stream.
            GZipStream compStream = new GZipStream(destFileStream, CompressionMode.Compress);

            //Now read byte by byte from the source stream and write it to the compressed stream
            int theByte = sourceFileStream.ReadByte();
            while (theByte != -1)
            {
                compStream.WriteByte((byte)theByte);
                theByte = sourceFileStream.ReadByte();
            }
            
            //Close all streams.
            sourceFileStream.Close();
            compStream.Close();
            destFileStream.Close();

            //Note: The compression/decompression procedure is the same for DeflateStream class.
        }

    }
}
