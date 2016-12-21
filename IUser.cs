using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointments
{
    interface IUser
    {
        IAppointment MakeAppointment(DateTime startTime);
    }
}
