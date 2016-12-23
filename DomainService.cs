using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointments
{
    class DomainService
    {
        private readonly IUserFactory userFactory;
        private readonly IUserGroupFactory userGroupFactory;

        public DomainService(IUserFactory userFactory, IUserGroupFactory userGroupFactory)
        {
            this.userGroupFactory = userGroupFactory;
            this.userFactory = userFactory;
        }

        public IUser RegisterUser(string userName, string password)
        {
            IRegistrantUser user = this.CreateUser(userName, password);
            user.Register();
            return user;
        }

        public IUser ChangeUserPassword(string userName, string password, string newPassword)
        {
            IRegistrantUser user = this.CreateUser(userName, password);
            user.ChangePassword(newPassword);
            return user;
        }

        public IUserGroup RegisterGroup(IUserGroup group, string password)
        {
            IRegistrantGroup registrantGroup = this.CreateGroup(group, password);
            registrantGroup.Register();
            return group;
        }
        
        public IUserGroup RegisterGroup(IList<IUser> users, string groupName, string password)
        {
            IRegistrantGroup group = this.CreateGroup(users, groupName, password);
            group.Register();
            return group;
        }

        public IUserGroup ChangeGroupPassword(string groupName, string password, string newPassword)
        {
            IRegistrantGroup group = this.CreateGroup(groupName, password);
            group.ChangePassword(newPassword);
            return group;
        }

        public IUserGroup ChangeGroupPassword(IUserGroup group, string password, string newPassword)
        {
            IRegistrantGroup registrantGroup = this.CreateGroup(group, password);
            registrantGroup.ChangePassword(newPassword);
            return registrantGroup;
        }

        private IRegistrantUser CreateUser(string userName, string password)
        {
            IUser user = this.userFactory.CreateUser(userName);
            return this.userFactory.CreateRegistrantUser(user, password);
        }
        private IRegistrantGroup CreateGroup(string groupName, string password)
        {
            IUserGroup userGroup = this.userGroupFactory.CreateUserGroup(groupName);
            return this.userGroupFactory.CreateRegistrantUserGroup(userGroup, password);
        }
        private IRegistrantGroup CreateGroup(IList<IUser> users, string groupName, string password)
        {
            IUserGroup userGroup = this.userGroupFactory.CreateUserGroup(users, groupName);
            return this.userGroupFactory.CreateRegistrantUserGroup(userGroup, password);
        }
        private IRegistrantGroup CreateGroup(IUserGroup userGroup, string password)
        {
            return this.userGroupFactory.CreateRegistrantUserGroup(userGroup, password);
        }
    }
}
