using BLL.Abstract;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamProject.DAL;
using TeamProject.DAL.Entities;

namespace BLL.Managers
{
    public class AccountManager : IAccountManager
    {
        [Inject]
        ICinemaWork work;

        public AccountManager(ICinemaWork work)
        {
            this.work = work;
        }
        public User CreateUser(string email, string password)
        {
            string cutName = email.Trim(new char[] {'@'});
            User user = new User { Email = email, IsConfirmedEmail = false, Name = cutName, Password = password, Views = null };
            work.Users.Create(user);
            work.Save();
            return user;
        }

        public User GetUser(string name, string password)
        {
            throw new NotImplementedException();
        }

        public User GetUserByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public User GetUserById(string token)
        {
            throw new NotImplementedException();
        }

        public void SendEmailToUser(User user)
        {
            throw new NotImplementedException();
        }

        public void UpdateUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
