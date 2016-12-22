using System;
using System.Collections.Generic;

namespace Appointments
{
    class UserGroupFactory : IUserGroupFactory
    {
        private readonly DataService dataService;

        public UserGroupFactory(DataService dataService)
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

        public IUserGroup CreateUserGroup(IList<IUser> users)
        {
            IUserGroup userGroup = new UserGroup();
            foreach(IUser user in users)
            {
                userGroup.AddMember(user);
            }
            return userGroup;
        }

        public IRegistrantGroup CreateRegistrantUserGroup(IList<IUser> users, string groupName, string password)
        {
            return new RegistrantGroup()
        }
    }
}