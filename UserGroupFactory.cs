using System;
using System.Collections.Generic;

namespace Appointments
{
    class UserGroupFactory : IUserGroupFactory
    {
        public IRegistrantGroup CreateRegistrantUserGroup(IUserGroup userGroup, string password)
        {
            return new PersistableGroup(userGroup, password);
        }

        public IUserGroup CreateUserGroup(string groupName)
        {
            return new UserGroup(groupName);
        }

        public IUserGroup CreateUserGroup(IList<IUser> users, string groupName)
        {
            IUserGroup group = this.CreateUserGroup(groupName);

            foreach (IUser user in users)
            {
                group.AddMember(user);
            }

            return group;
        }
    }
}