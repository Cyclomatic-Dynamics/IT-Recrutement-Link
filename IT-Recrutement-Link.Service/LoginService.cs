using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IT_Recrutement_Link.Domain.Domain;
namespace IT_Recrutement_Link.Service
{
    public class LoginService
    {
        private IUnitOfWork unitOfWork;
        public LoginService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public User LoginUser(string email, string password){
            User user = unitOfWork.FindMany<User>(u => u.Email.Equals(email)).FirstOrDefault();
            if (user != null)
            {
                if (user.VerifyPassword(password))
                {
                    return user;
                }
                else
                {
                    throw new WrongCredentialException();
                }
            }
            else
            {
                throw new WrongCredentialException();
            }
        }
    }
}
