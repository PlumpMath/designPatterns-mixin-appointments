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
            this.startTime = startTime;
            this.duration = duration;
        }

        public override string ToString()
        {
            return string.Format("Meeting starting at {0}, taking {1} min.",
                                    this.startTime, duration.Hours * 60 + duration.Minutes);
        }
    }
}
