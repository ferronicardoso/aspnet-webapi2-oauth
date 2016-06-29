using ProjetoModelo.Authentication.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoModelo.Authentication.Infrastructure
{
    public class AuthApplicationService : ApplicationContext, IAuthApplicationService
    {
        public IUser Authentication(string username, string password)
        {
            var model = this.User
                            .AsNoTracking()
                            .FirstOrDefault(x => x.Username.Contains(username) && x.Password.Contains(password));
            return model;
        }

        public void UpdateLastAccess(int id)
        {
            var user = this.User.Find(id);
            user.DateLastAccess = DateTime.Now;
            this.Entry(user).State = EntityState.Modified;
            this.SaveChanges();
        }
    }
}
