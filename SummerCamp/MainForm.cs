using System.Data;
using System.Text;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SummerCamp
{
    public partial class MainForm : Form
    {
        private List<Camper> _campers = new();
        private List<Activity> _activities = new();
        private List<Schedule> _schedules = new();

        public MainForm()
        {
            InitializeComponent();
        }
        private void BtnLoad_Click(object sender, EventArgs e)
        {
            using OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Data Files|*.xml;*.json";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                var data = DataLoader.LoadData(ofd.FileName);
                _campers = data.Item1;
                _activities = data.Item2;
                _schedules = data.Item3;

                PopulateTreeView();
                UpdateDataGridView(_campers);
            }
        }

        private void PopulateTreeView()
        {
            treeView.Nodes.Clear();

            TreeNode campersNode = new TreeNode("Участники");
            TreeNode activitiesNode = new TreeNode("Активности");
            TreeNode schedulesNode = new TreeNode("Расписание");

            foreach (var camper in _campers)
            {
                campersNode.Nodes.Add(new TreeNode(camper.FullName) { Tag = camper });
            }

            foreach (var activity in _activities)
            {
                activitiesNode.Nodes.Add(new TreeNode(activity.Name) { Tag = activity });
            }

            foreach (var schedule in _schedules)
            {
                schedulesNode.Nodes.Add(new TreeNode($"{schedule.Time}") { Tag = schedule });
            }

            treeView.Nodes.AddRange(new[] { campersNode, activitiesNode, schedulesNode });
            treeView.ExpandAll();
        }

        private void UpdateDataGridView<T>(List<T> data)
        {
            dataGridView.DataSource = data;
            dataGridView.ClearSelection();
        }

        private void BtnSaveDb_Click(object sender, EventArgs e)
        {
            try
            {
                using var context = new CampContext();

                ValidateRelationships();

                context.Database.ExecuteSqlRaw("DELETE FROM schedules");
                context.Database.ExecuteSqlRaw("DELETE FROM activities");
                context.Database.ExecuteSqlRaw("DELETE FROM campers");

                foreach (var camper in _campers)
                {
                    if (camper.Id == 0) camper.Id = _campers.IndexOf(camper) + 1;

                    foreach (var schedule in camper.Schedules)
                    {
                        schedule.CamperId = camper.Id;
                        schedule.Camper = camper;

                        var activity = _activities.FirstOrDefault(a => a.Id == schedule.ActivityId);
                        if (activity == null)
                        {
                            throw new InvalidOperationException($"Активность с ID {schedule.ActivityId} не найдена!");
                        }
                        schedule.Activity = activity;
                    }
                }

                context.Campers.AddRange(_campers);
                context.Activities.AddRange(_activities);
                context.Schedules.AddRange(_schedules);

                context.SaveChanges();

                MessageBox.Show("Данные успешно сохранены в базу данных!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении: {ex.Message}\n\n{ex.StackTrace}");
            }
        }

        private void ValidateRelationships()
        {
            var errors = new StringBuilder();

            foreach (var camper in _campers)
            {
                if (camper.Id <= 0)
                {
                    errors.AppendLine($"Участник {camper.FullName} имеет недопустимый ID: {camper.Id}");
                }

                foreach (var schedule in camper.Schedules)
                {
                    if (!_activities.Any(a => a.Id == schedule.ActivityId))
                    {
                        errors.AppendLine($"Расписание {schedule.Id} ссылается на несуществующую активность ID {schedule.ActivityId}");
                    }
                }
            }

            if (errors.Length > 0)
            {
                throw new InvalidDataException($"Обнаружены ошибки целостности:\n{errors}");
            }
        }

        private void BtnDetails_Click(object sender, EventArgs e)
        {
            if (dataGridView.CurrentRow?.DataBoundItem is Camper selectedCamper)
            {
                new DetailsForm(selectedCamper).ShowDialog();
            }
        }

        private void TreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node?.Tag is Camper camper)
            {
                UpdateDataGridView(new List<Camper> { camper });
            }
            else if (e.Node?.Tag is Activity activity)
            {
                UpdateDataGridView(new List<Activity> { activity });
            }
            else if (e.Node?.Tag is Schedule schedule)
            {
                UpdateDataGridView(new List<Schedule> { schedule });
            }
        }
    }
}