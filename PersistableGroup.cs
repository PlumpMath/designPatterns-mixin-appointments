using System;
using System.Collections.Generic;

namespace Appointments
{
    class PersistableGroup : IRegistrantGroup, IUserGroupVisitor
    {
        private IUserGroup group;
        private string password;
        private string groupName;
        private IList<string> userNames = new List<string>();

        public PersistableGroup(IUserGroup group, string password)
        {
            this.group = group;
            this.password = password;
        }

        public void Accept(Func<IUserGroupVisitor> visitorFactory)
        {
            this.group.Accept(visitorFactory);
        }

        public void AddMember(IUser user)
        {
            this.group.AddMember(user);
        }

        public void ChangePassword(string newPassword)
        {
            this.group.Accept(() => this);
            Console.WriteLine("Changing '{0}' group password from '{1}' to '{2}'.",
                                this.groupName, this.password, newPassword);
            this.password = newPassword;
        }

        public void Register()
        {
            this.group.Accept(() => this);
            Console.WriteLine("Registering group '{0}' with password '{1}'.",
                                this.groupName, this.password);

            foreach (string userName in this.userNames)
            {
                Console.WriteLine("\tAssociating {0} with group '{1}'", userName, this.groupName);
            }
        }

        public void VisitGroup(string groupName)
        {
            this.groupName = groupName;
        }

        public void VisitUser(string name)
        {
            userNames.Add(name);
        }
    }
}