using System.Windows.Forms;

namespace SummerCamp
{
    public partial class DetailsForm : Form
    {
        public DetailsForm(Camper camper)
        {
            InitializeComponent();
            ConfigureCamperDetails(camper);
        }

        private void ConfigureCamperDetails(Camper camper)
        {
            Text = $"Детали: {camper.FullName}";

            lblName.Text = camper.FullName;
            lblAge.Text = $"Возраст: {camper.Age}";
            lblCabin.Text = $"Домик: {camper.Cabin}";

            lblPhone.Text = $"Телефон: {camper.Contacts.Phone}";
            lblEmail.Text = $"Email: {camper.Contacts.Email}";

            listSchedule.Items.Clear();
            foreach (var schedule in camper.Schedules)
            {
                listSchedule.Items.Add($"{schedule.Date:dd.MM.yyyy} {schedule.Time} - {schedule.Activity?.Name}");
            }
        }
    }
}