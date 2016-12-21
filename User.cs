using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointments
{
    class User : IUser
    {
        private readonly string name;
        private readonly string password;

        public User(string name, string password)
        {
            this.name = name;
            this.password = password;
        }

        public IAppointment MakeAppointment(DateTime startTime)
        {
            return new Meeting(startTime, TimeSpan.FromHours(1));
        }

        public override string ToString()
        {
            return string.Format("User(name={0} password={1})", this.name, this.password);
        }
    }
}
