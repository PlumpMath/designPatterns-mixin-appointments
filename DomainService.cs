using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointments
{
    class DomainService
    {
        private readonly DataService dataService;

        public DomainService(DataService dataService)
        {
            this.dataService = dataService;
        }

        public IUser RegisterUser(string name, string password)
        {
            this.dataService.RegisterUser(name, password);
            return new User(name, password);
        }

        public IUser ChangePassword(string name, string password, string newPassword)
        {
            this.dataService.ChangePassword(name, password, newPassword);
            return new User(name, newPassword);
        }
    }
}
