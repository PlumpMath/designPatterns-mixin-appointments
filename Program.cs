using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointments
{
    class Program
    {
        static void MassRegister(IEnumerable<IRegistrant> registrants)
        {
            foreach(IRegistrant registrant in registrants)
            {
                registrant.Register();
            }
        }

        static void ScramblePassword(IEnumerable<IRegistrant> registrants)
        {
            foreach(IRegistrant registrant in registrants)
            {
                registrant.ChangePassword(Guid.NewGuid().ToString().Substring(0, 6));
            }
        }

        static void Main(string[] args)
        {
            DomainService domain =
                new DomainService(
                    new UserFactory(
                        new DataService()),
                            new UserGroupFactory());



            //IUser user = domain.RegisterUser("zoranh", "magicword");
            //Console.WriteLine("{0}\n", user);

            //IAppointment appointment =
            //   user.MakeAppointment(DateTime.Now.Date.AddHours(40));
            //Console.WriteLine("{0}\n", appointment);

            //user = domain.ChangeUserPassword("zoranh", "magicword", "somethingmorecomplex");

            //Console.WriteLine("{0}\n", user);



            //Console.WriteLine(new string('-', 60));



            //IUser jill = domain.RegisterUser("Jill", "pwd");
            //IUser joe = domain.RegisterUser("Joe", "pwd");
            //IUser jack = domain.RegisterUser("Jack", "pwd");

            //IUserGroup group = new UserGroup("friends");
            //group.AddMember(jill);
            //group.AddMember(joe);
            //group.AddMember(jack);

            //IRegistrantGroup regGroup = new PersistableGroup(group, "secret");

            //regGroup.Register();



            //Console.WriteLine(new string('-', 60));



            //IUser jill = domain.RegisterUser("Jill", "pwd");
            //IUser joe = domain.RegisterUser("Joe", "pwd");
            //IUser jack = domain.RegisterUser("Jack", "pwd");

            //IUserGroup group2 = new UserGroup("friends");
            //group2.AddMember(jill);
            //group2.AddMember(joe);
            //group2.AddMember(jack);

            //domain.RegisterGroup(group2, "secret");




            //Console.WriteLine(new string('-', 60));



            //List<IUser> users = new List<IUser>(){
            //    domain.RegisterUser("Jill", "pwd"),
            //    domain.RegisterUser("Joe", "pwd"),
            //    domain.RegisterUser("Jack", "pwd")};

            //IUserGroup group3 = domain.RegisterGroup(users, "friends", "secret");
            //domain.ChangeGroupPassword(group3, "secret", "complicatedsecret");



            Console.WriteLine(new string('-', 60));

            IUser jill = new User("Jill");
            IUser joe = new User("Joe");
            IUser jack = new User("Jack");

            IUserGroup group4 = new UserGroup("friends");
            group4.AddMember(jill);
            group4.AddMember(joe);
            group4.AddMember(jack);

            DataService dataSvc = new DataService();

            IEnumerable<IRegistrant> registrants =
                new IRegistrant[]
                {
                    new PersistableUser(jill, dataSvc, "pwd"),
                    new PersistableUser(joe, dataSvc, "pwd"),
                    new PersistableUser(jack, dataSvc, "pwd"),
                    new PersistableGroup(group4, "secret")
                };

            //MassRegister(registrants);
            ScramblePassword(registrants);



            Console.ReadLine();
        }
    }
}