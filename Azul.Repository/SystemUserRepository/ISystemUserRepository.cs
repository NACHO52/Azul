using Azul.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azul.Repository
{
    public interface ISystemUserRepository
    {
        public Task<IList<SystemUser>> GetAll();
        public Task<SystemUser> Get(string username, string password);
    }
}
