using System;

namespace Appointments
{
    class UserFactory : IUserFactory
    {
        private readonly DataService dataService;

        public UserFactory(DataService dataService)
        {
            this.dataService = dataService;
        }

        public IUser CreateUser(string name)
        {
            return new User(name);
        }

        public IRegistrantUser CreateRegistrantUser(IUser user, string password)
        {
            return new PersistableUser(user, this.dataService, password);
        }
    }
}