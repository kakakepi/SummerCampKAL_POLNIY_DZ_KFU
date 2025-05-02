using System.Data;
using System.Windows.Forms;
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
                schedulesNode.Nodes.Add(new TreeNode($"{schedule.Date:dd.MM} {schedule.Time}") { Tag = schedule });
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

            using var context = new CampContext();
            context.Database.EnsureCreated();

            context.Campers.AddRange(_campers);
            context.Activities.AddRange(_activities);
            context.Schedules.AddRange(_schedules);

            context.SaveChanges();
            MessageBox.Show("Данные сохранены в БД!");
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