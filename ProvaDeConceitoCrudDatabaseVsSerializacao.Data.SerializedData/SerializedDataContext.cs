using System;
using System.Collections.Generic;
using System.IO;

namespace ProvaDeConceitoCrudDatabaseVsSerializacao.Data.SerializedData
{
    public class SerializedDataContext<TEntity> where TEntity : class
    {
        public readonly string FileName = @"_Database.xml";
        public SerializedDataContext(string path = "")
        {
            if (path == "")
                path = AppDomain.CurrentDomain.BaseDirectory;
            FileName = path + typeof(TEntity).Name + FileName;
        }

        public void WriteXML(List<TEntity> printers)
        {
            var writer = new System.Xml.Serialization.XmlSerializer(typeof(List<TEntity>));
            var wfile = new System.IO.StreamWriter(FileName);
            writer.Serialize(wfile, printers);
            wfile.Close();
        }

        public List<TEntity> ReadXML()
        {
            System.Xml.Serialization.XmlSerializer reader = new System.Xml.Serialization.XmlSerializer(typeof(List<TEntity>));
            if (!File.Exists(FileName))
                WriteXML(new List<TEntity>());
            StreamReader file = new StreamReader(FileName);
            List<TEntity> printers = (List<TEntity>)reader.Deserialize(file);
            file.Close();

            return printers;
        }
    }
}
