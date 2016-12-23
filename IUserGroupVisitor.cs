namespace Appointments
{
    interface IUserGroupVisitor : IUserVisitor
    {
        void VisitGroup(string groupName);
    }
}