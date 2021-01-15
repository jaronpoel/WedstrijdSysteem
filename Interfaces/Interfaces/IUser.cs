namespace Dal.Context
{
    public interface IUser
    {
        void SetName(string name);
        void SetPassword(string password);
        void SetEmail(string email);
    }
}