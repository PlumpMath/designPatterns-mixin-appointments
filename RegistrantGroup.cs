using System;

namespace Appointments
{
    class RegistrantGroup : IRegistrantGroup
    {
        private IUserGroup group;
        private string groupName;
        private string password;

        public RegistrantGroup(IUserGroup group, string groupName, string password)
        {
            this.group = group;
            this.groupName = groupName;
            this.password = password;
        }

        public void AddMember(IUser user)
        {
            this.group.AddMember(user);
        }

        public void ChangePassword(string newPassword)
        {
            throw new NotImplementedException();
        }

        public void Register()
        {
            throw new NotImplementedException();
        }
    }
}