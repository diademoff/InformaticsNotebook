using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace MyNotebook.ViewModels
{
    [Serializable]
    public class UserCollection
    {
        static string folder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Notebook";
        static string dataPath = folder + "\\data.bin";

        public static UserCollection Instance = UserCollection.DeserializeSingle(dataPath);
        private UserCollection()
        {
        }
        ~UserCollection()
        {
            Serialize();
        }

        public List<User> Users { get; private set; } = new List<User>();

        public User this[string UserString]
        {
            get
            {
                foreach (var item in Users)
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
                foreach (var item in Users)
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
            foreach (var item in Users)
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
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            BinaryFormatter bf = new BinaryFormatter();
            using (FileStream fs = new FileStream(dataPath, FileMode.Create))
            {
                bf.Serialize(fs, this);
            }
        }

        public static UserCollection DeserializeFolder(string folder)
        {
            UserCollection collection = new UserCollection();
            string[] files = Directory.GetFiles(folder);
            for (int i = 0; i < files.Length; i++)
            {
                collection.Users.AddRange(DeserializeSingle(files[i]).Users);
            }
            return collection;
        }
        private static UserCollection DeserializeSingle(string dataPath)
        {
            try
            {
                BinaryFormatter bf = new BinaryFormatter();
                using (FileStream fs = new FileStream(dataPath, FileMode.Open))
                {
                    return bf.Deserialize(fs) as UserCollection;
                }
            }
            catch
            {
                return new UserCollection();
            }
        }
    }
}
