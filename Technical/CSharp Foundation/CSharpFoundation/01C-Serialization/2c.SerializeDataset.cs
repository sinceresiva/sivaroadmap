using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using System.Data;

namespace Chapter05_Serialization
{
    //This program creates DataSet Serialization.
    //Besides serializing an instance of a public class, an instance of a DataSet object can also be serialized.

    public class SerializeDataset
    {
        public static void Display()
        {
            SerializeDataSet("DSSerialize.xml");
        }

        private static void SerializeDataSet(string filename)
        {
            XmlSerializer ser = new XmlSerializer(typeof(DataSet));

            // Creates a DataSet; adds a table, column, and ten rows.
            DataSet ds = new DataSet("myDataSet");
            DataTable t = new DataTable("table1");
            DataColumn c = new DataColumn("thing");

            t.Columns.Add(c);
            ds.Tables.Add(t);

            DataRow r;
            for (int i = 0; i < 10; i++)
            {
                r = t.NewRow();
                r[0] = "Thing " + i;
                t.Rows.Add(r);
            }

            TextWriter writer = new StreamWriter(filename);
            ser.Serialize(writer, ds);
            writer.Close();
        }
    }
}
