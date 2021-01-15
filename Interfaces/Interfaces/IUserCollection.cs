using Interfaces.DTO;

namespace Dal.Context
{
    public interface IUserCollection
    {
        void SignUp(string username, string password, string email);
        UserDto SignIn(string username, string password);
        void MakingTeam();
    }
}