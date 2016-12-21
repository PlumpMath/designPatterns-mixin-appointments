using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointments
{
    class Meeting : IAppointment
    {
        private DateTime startTime;
        private TimeSpan duration;

        public Meeting(DateTime startTime, TimeSpan duration)
        {

        }
    }
}
