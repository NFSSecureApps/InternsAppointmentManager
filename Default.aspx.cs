using InternsAppointmentManager.App_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InternsAppointmentManager
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var helper = new AppointmentHelper();
                RebuildAppointmentsDL();
            }
        }

        private void RebuildAppointmentsDL()
        {
            //Shared Helper to rebuild Data List
            var helper = new AppointmentHelper();
            var appts = helper.GetAllAppointments();
            AppointmentsDL.DataSource = appts;
            AppointmentsDL.DataBind();
        }

        protected void EditButton_Click(object sender, EventArgs e)
        {
            //To switch the data list into edit.
            //There is a label that holds the index of each data item in the data list called indexLabel.
            //Go find that label and assign its text to the EditItemIndex. Then Bind.
            var EditButton = (Button)sender;
            var indexLabel = (Label)EditButton.Parent.FindControl("indexLabel");
            AppointmentsDL.EditItemIndex = Convert.ToInt32(indexLabel.Text);
            RebuildAppointmentsDL();
        }

        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            //Clear the file holding all appointments and rebuild it.
            var helper = new AppointmentHelper();
            helper.ClearAppointments();

            //Find all data items that are not on the current edit record and add them to the appointments.
            foreach (DataListItem item in AppointmentsDL.Items)
            {
                var appt = new Appointment();
                var indexLabel = (Label)item.FindControl("indexLabel");
                if (Convert.ToInt32(indexLabel.Text) != AppointmentsDL.EditItemIndex)
                {
                    appt.FirstName = ((Label)item.FindControl("FNameLabel")).Text;
                    appt.LastName = ((Label)item.FindControl("LNameLabel")).Text;
                    appt.AppointmentDateTime = Convert.ToDateTime(((Label)item.FindControl("ApptDateLabel")).Text);
                    appt.UpdateDateTime = Convert.ToDateTime(((Label)item.FindControl("UpdateDateLabel")).Text);
                    appt.AppointmentWithName = ((Label)item.FindControl("ApptWithNameLabel")).Text;
                    appt.AppointmentReason = ((Label)item.FindControl("ApptReasonLabel")).Text;
                    helper.AddNewAppointment(appt);
                }
            }
            AppointmentsDL.EditItemIndex = -1;
            //RebuildAppointmentsDL();
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            var appts = new List<Appointment>();
            foreach (DataListItem item in AppointmentsDL.Items)
            {
                var appt = new Appointment();
                var indexLabel = (Label)item.FindControl("indexLabel");
                if (Convert.ToInt32(indexLabel.Text) == AppointmentsDL.EditItemIndex)
                {
                    var TestDate = Convert.ToDateTime("01/01/9999");
                    if (!DateTime.TryParse((((TextBox)item.FindControl("ApptDateTextBox")).Text), out TestDate))
                    {
                        ((TextBox)item.FindControl("ApptDateTextBox")).BorderColor = System.Drawing.Color.Red;
                        return;
                    }
                    else
                    {
                        ((TextBox)item.FindControl("ApptDateTextBox")).BorderColor = System.Drawing.Color.Empty;
                    }

                    appt.FirstName = ((TextBox)item.FindControl("FNameTextBox")).Text;
                    appt.LastName = ((TextBox)item.FindControl("LNameTextBox")).Text;
                    appt.AppointmentDateTime = TestDate;
                    appt.UpdateDateTime = DateTime.Now;
                    appt.AppointmentWithName = ((TextBox)item.FindControl("ApptWithTextBox")).Text;
                    appt.AppointmentReason = ((TextBox)item.FindControl("ApptReasonTextBox")).Text;
                    appts.Add(appt);
                }
                else
                {
                    appt.FirstName = ((Label)item.FindControl("FNameLabel")).Text;
                    appt.LastName = ((Label)item.FindControl("LNameLabel")).Text;
                    appt.AppointmentDateTime = Convert.ToDateTime(((Label)item.FindControl("ApptDateLabel")).Text);
                    appt.UpdateDateTime = Convert.ToDateTime(((Label)item.FindControl("UpdateDateLabel")).Text);
                    appt.AppointmentWithName = ((Label)item.FindControl("ApptWithNameLabel")).Text;
                    appt.AppointmentReason = ((Label)item.FindControl("ApptReasonLabel")).Text;
                    appts.Add(appt);
                }
            }

            var helper = new AppointmentHelper();
            helper.ClearAppointments();
            foreach (Appointment appt in appts)
            {
                helper.AddNewAppointment(appt);
            }
            AppointmentsDL.EditItemIndex = -1;
            RebuildAppointmentsDL();
        }

        protected void OpenAddPanel_Click(object sender, EventArgs e)
        {
            AddNewPanel.Visible = true;
            ViewAppointmentsPanel.Visible = false;
            OpenAddPanel.Visible = false;
        }

        protected void CanceAddButton_Click(object sender, EventArgs e)
        {
            ResetAndCloseAdd();
        }

        protected void SaveAddButton_Click(object sender, EventArgs e)
        {
            var testDate = Convert.ToDateTime("01/01/9999");
            if (!DateTime.TryParse(ApptDateTxt.Text, out testDate))
            {
                ApptDateTxt.BorderColor = System.Drawing.Color.Red;
                return;
            }
            else
            {
                ApptDateTxt.BorderColor = System.Drawing.Color.Empty;
            }

            var helper = new AppointmentHelper();
            var Appt = new Appointment(FNameTxt.Text, LNameTxt.Text, testDate, ApptWithTxt.Text,ApptReasonTxt.Text);
            helper.AddNewAppointment(Appt);
            RebuildAppointmentsDL();
            ResetAndCloseAdd();
        }

        private void ResetAndCloseAdd()
        {
            AddNewPanel.Visible = false;
            ViewAppointmentsPanel.Visible = true;
            OpenAddPanel.Visible = true;
            FNameTxt.Text = "";
            LNameTxt.Text = "";
            ApptDateTxt.Text = "";
            ApptWithTxt.Text = "";
            ApptReasonTxt.Text = "";
        }
    }
}