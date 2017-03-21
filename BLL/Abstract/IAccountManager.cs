using TeamProject.DAL.Entities;
namespace BLL.Abstract
{
    public interface IAccountManager
    {
        //если я могу общатся с уровнем после и до меня то почему vs не дает мне подключить зависимость
        //   User GetUser(LoginModel model);
        User GetUser(string name, string password);
        User GetUserByEmail(string email);
        User CreateUser(string email, string password);
        User GetUserById(string token);
        void UpdateUser(User user);
        void SendEmailToUser(User user);
    }
}
