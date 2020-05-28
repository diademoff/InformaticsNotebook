using System;
using System.IO;
using System.Xml.Serialization;

namespace MyNotebook.StaticCollections
{
    public class ConfigCollection : Serializer
    {
        static string path = SerializationFolder + "\\config.cfg";
        static ConfigCollection instance;
        public static ConfigCollection Instance
        {
            get
            {
                if (instance == null)
                {
                    Deserialize();
                }
                return instance;
            }
            set
            {
                instance = value;
            }
        }
        public string SelectedFormStyleName { get; set; }

        private ConfigCollection()
        {
            Deserialize();
        }

        public ConfigCollection(string selectedFormStyleName)
        {
            SelectedFormStyleName = selectedFormStyleName ?? throw new ArgumentNullException(nameof(selectedFormStyleName));
        }

        ~ConfigCollection()
        {
            Serialize();
        }

        public override void Serialize()
        {
            CheckFolderExists();

            try
            {
                XmlSerializer bf = new XmlSerializer(typeof(ConfigCollection));
                using (FileStream fs = new FileStream(path, FileMode.Create))
                {
                    bf.Serialize(fs, Instance);
                }
            }
            catch { System.Windows.Forms.MessageBox.Show("Ошибка сериализации"); }
        }

        static void Deserialize()
        {
            try
            {
                XmlSerializer bf = new XmlSerializer(typeof(ConfigCollection));
                using (FileStream fs = new FileStream(path, FileMode.Open))
                {
                    Instance = bf.Deserialize(fs) as ConfigCollection;
                }
            }
            catch
            {
                Instance = new ConfigCollection("Светлая тема");
            }
        }
    }
}
