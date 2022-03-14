using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace InternsAppointmentManager.App_Code
{
    public class AppointmentHelper
    {
        public void AddNewAppointment(object appt)
        {
            //Scrub data for safe keeping
            appt.FirstName.Replace("^", "_");
            appt.LastName.Replace("^", "_");
            appt.AppointmentWithName.Replace("^", "_");
            appt.AppointmentReason.Replace("~", "|");

            //Append variable data to local file
            File.AppendAllText(HttpContext.Current.Server.MapPath("~/Appointments.txt"), appt.FirstName + "^");
            File.AppendAllText(HttpContext.Current.Server.MapPath("~/Appointments.txt"), appt.LastName + "^");
            File.AppendAllText(HttpContext.Current.Server.MapPath("~/Appointments.txt"), appt.AppointmentDateTime + "^");
            File.AppendAllText(HttpContext.Current.Server.MapPath("~/Appointments.txt"), appt.UpdateDateTime + "^");
            File.AppendAllText(HttpContext.Current.Server.MapPath("~/Appointments.txt"), appt.AppointmentWithName + "^");
            File.AppendAllText(HttpContext.Current.Server.MapPath("~/Appointments.txt"), appt.AppointmentReason + "~");
        }

        public List<Appointment> GetAllAppointments()
        {
            //To store each parsed appointment
            var appointments = new List<Appointment>();
            //To store each variable untill reset
            var Appt = new Appointment;

            //parsing variable helpers
            var currentWord = "";
            char ch;
            int Tchar = 0;

            //Get local file for parsing
            StreamReader reader = new StreamReader(HttpContext.Current.Server.MapPath("Appointment.txt"));
            do
            {
                //reading character by character and assign the character back to ch
                ch = (char)reader.Read();

                //validate special characters
                if (ch.ToString() == "^")
                {
                    //If special char is ^ this is a complete of a full Appointment variable
                    switch (Tchar)
                    {
                        case 0:
                            Appt.FirstName = currentWord.Replace("_", "^");
                            break;
                        case 1:
                            Appt.LastName = currentWord.Replace("_", "^");
                            break;
                        case 2:
                            Appt.AppointmentDateTime = Convert.ToDateTime(currentWord);
                            break;
                        case 3:
                            Appt.UpdateDateTime = Convert.ToDateTime(currentWord);
                            break;
                    }
                    Tchar += 1;
                    currentWord = "";
                }
                else if (ch.ToString() == "~")
                {
                    //If special char is ~ this is a complete of a final Appointment variable and should assign back to list wile reseting loop variables.
                    Appt.AppointmentReason = currentWord;
                    currentWord = "";
                    Tchar = 1
                    appointments.Add(Appt);
                }
                else
                {
                    //Apend char to work storage and keep reading
                    currentWord += ch.ToString();
                }
            } while (!reader.EndOfStream);
            reader.Close();
            reader.Dispose();
            return appointments;
        }

        public void ClearAppointments()
        {
            File.WriteAllText(HttpContext.Current.Server.MapPath("~/Appointments.txt"), String.Empty);
        }

    }
}