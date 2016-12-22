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
                        new DataService()));



            //IUser user = domain.RegisterUser("zoranh", "magicword");
            //Console.WriteLine("{0}\n", user);

            //IAppointment appointment =
            //    user.MakeAppointment(DateTime.Now.Date.AddHours(40));
            //Console.WriteLine("{0}\n", appointment);

            //user = domain.ChangePassword("zoranh", "magicword", "somethingmorecomplex");

            //Console.WriteLine("{0}\n", user);



            IUser jill = domain.RegisterUser("Jill", "pwd");
            IUser joe = domain.RegisterUser("Joe", "pwd");
            IUser jack = domain.RegisterUser("Jack", "pwd");

            IUserGroup group = new UserGroup();
            group.AddMember(jill);
            group.AddMember(joe);
            group.AddMember(jack);

            IRegistrantGroup regGroup = new RegistrantGroup(group, "friends", "secret");

            regGroup.Register();

            Console.ReadLine();
        }
    }
}