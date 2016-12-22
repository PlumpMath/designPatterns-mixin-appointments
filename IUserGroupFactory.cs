using System.Collections.Generic;

namespace Appointments
{
    interface IUserGroupFactory
    {
        IUserGroup CreateUserGroup(IList<IUser> users);
        IRegistrantGroup CreateRegistrantUserGroup(IList<IUser> users, string groupName, string password);
    }
}