using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace MyNotebook.ViewModels
{
    [Serializable]
    public class UserCollection
    {
        static string folder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Notebook";
        public static string dataPath = folder + "\\data.bin";

        public static UserCollection Instance = new UserCollection() { Users = new UserCollection().DeserializeSingle(dataPath) };
        private UserCollection()
        {
        }
        ~UserCollection()
        {
            Serialize();
        }

        public List<User> Users { get; set; } = new List<User>();

        public User this[string UserString]
        {
            get
            {
                foreach (User item in Users)
                {
                    if (item.ToString() == UserString)
                    {
                        return item;
                    }
                }

                throw new Exception($"No user found {UserString}");
            }
            set
            {
                foreach (User item in Users)
                {
                    if (item.ToString() == UserString)
                    {
                        throw new Exception($"User with this name {UserString} already exists");
                    }
                }
                Users.Add(value);
            }
        }

        public User[] GetUsers => Users.ToArray();

        public bool UserExists(string UserString)
        {
            foreach (User item in Users)
            {
                if (item.ToString() == UserString)
                {
                    return true;
                }
            }
            return false;
        }

        public void AddNewUser(User user)
        {
            if (UserExists(user.ToString()))
            {
                throw new Exception($"User already exists {user.ToString()}");
            }

            Users.Add(user);
        }

        public void DeleteUser(User user)
        {
            if (!UserExists(user.ToString()))
            {
                throw new Exception($"User doesnt exists {user.ToString()}");
            }

            for (int i = 0; i < Users.Count; i++)
            {
                if (Users[i].ToString() == user.ToString())
                {
                    Users.RemoveAt(i);
                    return;
                }
            }
        }

        public void Serialize()
        {
            try
            {
                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }

                XmlSerializer bf = new XmlSerializer(new List<User>().GetType());
                using (FileStream fs = new FileStream(dataPath, FileMode.Create))
                {
                    bf.Serialize(fs, Users);
                }
            }
            catch { System.Windows.Forms.MessageBox.Show("Ошибка сериализации"); }
        }

        public List<User> DeserializeFolder(string folder)
        {
            List<User> collection = new List<User>();
            string[] files = Directory.GetFiles(folder);
            for (int i = 0; i < files.Length; i++)
            {
                collection.AddRange(DeserializeSingle(files[i]));
            }
            return collection;
        }
        private List<User> DeserializeSingle(string dataPath)
        {
            try
            {
                XmlSerializer bf = new XmlSerializer(new List<User>().GetType());
                using (FileStream fs = new FileStream(dataPath, FileMode.Open))
                {
                    Users = bf.Deserialize(fs) as List<User>;
                }
            }
            catch
            {
                Users = new List<User>();
            }
            return Users;
        }
    }
}
