using System.Windows.Forms;

namespace SummerCamp
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            splitContainer = new SplitContainer();
            treeView = new TreeView();
            dataGridView = new DataGridView();
            panel1 = new Panel();
            pictureBox = new PictureBox();
            btnLoad = new Button();
            btnSaveDb = new Button();
            btnDetails = new Button();
            ((System.ComponentModel.ISupportInitialize)splitContainer).BeginInit();
            splitContainer.Panel1.SuspendLayout();
            splitContainer.Panel2.SuspendLayout();
            splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            SuspendLayout();
            // 
            // splitContainer
            // 
            splitContainer.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            splitContainer.Location = new Point(0, 0);
            splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            splitContainer.Panel1.Controls.Add(treeView);
            // 
            // splitContainer.Panel2
            // 
            splitContainer.Panel2.Controls.Add(dataGridView);
            splitContainer.Panel2.Controls.Add(panel1);
            splitContainer.Size = new Size(625, 321);
            splitContainer.SplitterDistance = 131;
            splitContainer.TabIndex = 0;
            // 
            // treeView
            // 
            treeView.Dock = DockStyle.Fill;
            treeView.Location = new Point(0, 0);
            treeView.Name = "treeView";
            treeView.Size = new Size(131, 321);
            treeView.TabIndex = 0;
            treeView.AfterSelect += TreeView_AfterSelect;
            // 
            // dataGridView
            // 
            dataGridView.AllowUserToAddRows = false;
            dataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView.BackgroundColor = Color.White;
            dataGridView.ColumnHeadersHeight = 46;
            dataGridView.Location = new Point(0, 94);
            dataGridView.Name = "dataGridView";
            dataGridView.ReadOnly = true;
            dataGridView.RowHeadersWidth = 82;
            dataGridView.Size = new Size(484, 224);
            dataGridView.TabIndex = 9;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.Controls.Add(pictureBox);
            panel1.Controls.Add(btnLoad);
            panel1.Controls.Add(btnSaveDb);
            panel1.Controls.Add(btnDetails);
            panel1.Location = new Point(2, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(485, 91);
            panel1.TabIndex = 5;
            // 
            // pictureBox
            // 
            pictureBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox.Image = Properties.Resources.maxresdefault;
            pictureBox.Location = new Point(273, 3);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(209, 82);
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox.TabIndex = 4;
            pictureBox.TabStop = false;
            // 
            // btnLoad
            // 
            btnLoad.AutoSize = true;
            btnLoad.Location = new Point(3, 3);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(71, 85);
            btnLoad.TabIndex = 1;
            btnLoad.Text = "Загрузить";
            btnLoad.Click += BtnLoad_Click;
            // 
            // btnSaveDb
            // 
            btnSaveDb.AutoSize = true;
            btnSaveDb.Location = new Point(165, 3);
            btnSaveDb.Name = "btnSaveDb";
            btnSaveDb.Size = new Size(102, 85);
            btnSaveDb.TabIndex = 2;
            btnSaveDb.Text = "Сохранить в БД";
            btnSaveDb.Click += BtnSaveDb_Click;
            // 
            // btnDetails
            // 
            btnDetails.AutoSize = true;
            btnDetails.Location = new Point(80, 3);
            btnDetails.Name = "btnDetails";
            btnDetails.Size = new Size(79, 85);
            btnDetails.TabIndex = 3;
            btnDetails.Text = "Подробнее";
            btnDetails.Click += BtnDetails_Click;
            // 
            // MainForm
            // 
            ClientSize = new Size(624, 321);
            Controls.Add(splitContainer);
            Name = "MainForm";
            Text = "Управление лагерем";
            splitContainer.Panel1.ResumeLayout(false);
            splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer).EndInit();
            splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            ResumeLayout(false);
        }
        #endregion
        private TreeView treeView;
        private DataGridView dataGridView;
        private SplitContainer splitContainer;
        private Button btnLoad;
        private Button btnSaveDb;
        private Button btnDetails;
        private PictureBox pictureBox;
        private Label lblStatus;
        private Panel panel1;
    }
}