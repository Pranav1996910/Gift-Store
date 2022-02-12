using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Serialization;

namespace HorizontalList               
{
   public class MyStorage
{
    public static void WriteXml<W>(W data, string fileName)
    {
        XmlSerializer sr = new XmlSerializer(typeof(W));
        FileStream stream;
        stream = new FileStream(fileName, FileMode.Create);
        sr.Serialize(stream, data);
        stream.Close();
    }
    public static W ReadXml<W>(string fileName)
    {
        try
        {
            using (StreamReader stream = new StreamReader(fileName))
            {
                XmlSerializer sr = new XmlSerializer(typeof(W));
                return (W)sr.Deserialize(stream);
            }
        }

        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error");
            return default(W);
        }




    }
}
}