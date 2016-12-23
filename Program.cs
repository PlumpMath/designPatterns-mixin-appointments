using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointments
{
    class Program
    {
        static void Main(string[] args)
        {
            DomainService domain =
                new DomainService(
                    new UserFactory(
                        new DataService()),
                            new UserGroupFactory());



            IUser user = domain.RegisterUser("zoranh", "magicword");
            Console.WriteLine("{0}\n", user);

            IAppointment appointment =
               user.MakeAppointment(DateTime.Now.Date.AddHours(40));
            Console.WriteLine("{0}\n", appointment);

            user = domain.ChangeUserPassword("zoranh", "magicword", "somethingmorecomplex");

            Console.WriteLine("{0}\n", user);



            Console.WriteLine(new string('-', 60));



            IUser jill = domain.RegisterUser("Jill", "pwd");
            IUser joe = domain.RegisterUser("Joe", "pwd");
            IUser jack = domain.RegisterUser("Jack", "pwd");

            IUserGroup group = new UserGroup("friends");
            group.AddMember(jill);
            group.AddMember(joe);
            group.AddMember(jack);

            IRegistrantGroup regGroup = new PersistableGroup(group, "secret");

            regGroup.Register();



            Console.WriteLine(new string('-', 60));



            // IUser jill = domain.RegisterUser("Jill", "pwd");
            // IUser joe = domain.RegisterUser("Joe", "pwd");
            // IUser jack = domain.RegisterUser("Jack", "pwd");

            IUserGroup group2 = new UserGroup("friends");
            group2.AddMember(jill);
            group2.AddMember(joe);
            group2.AddMember(jack);

            domain.RegisterGroup(group2, "secret");




            Console.WriteLine(new string('-', 60));



            List<IUser> users = new List<IUser>(){
                domain.RegisterUser("Jill", "pwd"),
                domain.RegisterUser("Joe", "pwd"),
                domain.RegisterUser("Jack", "pwd")};

            domain.RegisterGroup(users, "friends", "secret");




            Console.ReadLine();
        }
    }
}