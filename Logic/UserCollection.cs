using Interfaces.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal.Context;
using Factory;

namespace Logic
{
    public class UserCollection
    {
        //Factory aanroepen
        private readonly IUserCollection UserCollectionDAL;
        public UserCollection()
        {
            UserCollectionDAL = FactoryDal.CreateUserCollectionDal();
        }

        //Begin van de Methodes aanroepen
        public void SignUp(string username, string password, string email)
        {
            UserCollectionDAL.SignUp(username, password, email);
        }

        public User SignIn(string username, string password)
        {
            UserDto userdto = UserCollectionDAL.SignIn(username, password);
            User user = new User(userdto.Id, userdto.Username);
            return user;
        }

        public User MakingTeam()
        {
            throw new NotImplementedException();
        }
    }
}
