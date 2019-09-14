using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNotebook.ViewModels
{
    public class UserCollection
    {
        public static UserCollection Instance = new UserCollection();
        private UserCollection()
        {

        }
        public List<User> Users { get; private set; } = new List<User>(); //TODO: add serialization

        public User this[string UserName]
        {
            get
            {
                foreach (var item in Users)
                {
                    if (item.Name == UserName)
                    {
                        return item;
                    }
                }

                throw new Exception($"No user found {UserName}");
            }
            set
            {
                foreach (var item in Users)
                {
                    if (item.Name == UserName)
                    {
                        throw new Exception($"User with this name {UserName} already exists");
                    }
                }
                Users.Add(value);
            }
        }

        public User[] GetUsers => Users.ToArray();

        public bool UserExists(string UserName)
        {
            foreach (var item in Users)
            {
                if (item.Name == UserName)
                {
                    return true;
                }
            }
            return false;
        }

        public void AddNewUser(User user)
        {
            if (UserExists(user.Name))
            {
                throw new Exception($"User already exists with name {user.Name}");
            }

            Users.Add(user);
        }
    }
}
