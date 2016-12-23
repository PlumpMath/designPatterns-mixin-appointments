using System;
using System.Collections.Generic;

namespace Appointments
{
    class UserGroup : IUserGroup
    {
        private IList<IUser> members = new List<IUser>();
        private string groupName;

        public UserGroup(string groupName)
        {
            this.groupName = groupName;
        }

        public void Accept(Func<IUserGroupVisitor> visitorFactory)
        {
            IUserGroupVisitor visitor = visitorFactory();
            visitor.VisitGroup(this.groupName);

            foreach (IUser member in members)
            {
                member.Accept(() => (IUserVisitor)visitor);
            }
        }

        public void AddMember(IUser user)
        {
            this.members.Add(user);
        }

        public override string ToString()
        {
            return string.Format("Group(name={0})", this.groupName);
        }
    }
}