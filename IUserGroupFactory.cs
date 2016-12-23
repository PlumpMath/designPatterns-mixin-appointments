using System.Collections.Generic;

namespace Appointments
{
    interface IUserGroupFactory
    {
        IUserGroup CreateUserGroup(string groupName);
        IUserGroup CreateUserGroup(IList<IUser> users, string groupName);
        IRegistrantGroup CreateRegistrantUserGroup(IUserGroup userGroup, string password);
    }
}