using System;
using System.Collections.Generic;

namespace Appointments
{
    class UserGroup : IUserGroup
    {
        private IList<IUser> members = new List<IUser>();

        public void AddMember(IUser user)
        {
            this.members.Add(user);
        }
    }
}