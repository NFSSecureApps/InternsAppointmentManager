using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace InternsAppointmentManager.App_Code
{
    public class Appointment
    {
        //New Default Constructor
        public Appointment()
        {

        }

        //Constructor
        public Appointment(string fName, string lName, DateTime apptDate,string apptReason,string apptWithName)
        {
            FirstName = fName;
            LastName = lName;
            AppointmentDateTime = apptDate;
            UpdateDateTime = apptDate;
            AppointmentReason = apptReason;
            AppointmentWithName = apptWithName;
        }

        //Properties
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime AppointmentDateTime { get; set; }
        public DateTime UpdateDateTime { get; set; }
        public string AppointmentWithName { get; set; }
        public string AppointmentReason { get; set; }
    }
}