using Dal.Context;
using Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public User(int id, string username, string password, string email)
        {
            Id = id;
            Username = username;
            Password = password;
            Email = email;
        }

        public User(int id, string username)
        {
            Id = id;
            Username = username;
        }

        //Factory aanroepen
        private readonly IUser UserDAL;
        public User()
        {
            UserDAL = FactoryDal.CreateUserDal();
        }

        //Begin van de Methodes aanroepen
        public void SetName(string name)
        {
            UserDAL.SetName(name);
        }

        public void SetPassword(string password)
        {
            UserDAL.SetPassword(password);
        }

        public void SetEmail(string email)
        {
            UserDAL.SetEmail(email);
        }
    }
}
