using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoModelo.Authentication.Domain.Interfaces
{
    public interface IAuthApplicationService
    {
        IUser Authentication(string username, string password);
        void UpdateLastAccess(int id);
    }
}
