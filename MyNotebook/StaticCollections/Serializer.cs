using System;
using System.IO;

namespace MyNotebook.StaticCollections
{
    public abstract class Serializer
    {
        public static string SerializationFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Notebook";

        public abstract void Serialize();
        public void CheckFolderExists()
        {
            if (!Directory.Exists(SerializationFolder))
            {
                Directory.CreateDirectory(SerializationFolder);
            }
        }
    }
}
