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
            dataGridView = new DataGridView();
            treeView = new TreeView();
            btnLoad = new Button();
            btnSaveDb = new Button();
            btnDetails = new Button();
            pictureBox = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)splitContainer).BeginInit();
            splitContainer.Panel1.SuspendLayout();
            splitContainer.Panel2.SuspendLayout();
            splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            SuspendLayout();
            // 
            // splitContainer
            // 
            splitContainer.Dock = DockStyle.Left;
            splitContainer.Location = new Point(0, 0);
            splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            splitContainer.Panel1.Controls.Add(dataGridView);
            splitContainer.Panel1.Controls.Add(treeView);
            // 
            // splitContainer.Panel2
            // 
            splitContainer.Panel2.Controls.Add(btnLoad);
            splitContainer.Panel2.Controls.Add(btnSaveDb);
            splitContainer.Panel2.Controls.Add(btnDetails);
            splitContainer.Panel2.Controls.Add(pictureBox);
            splitContainer.Size = new Size(1687, 866);
            splitContainer.SplitterDistance = 1000;
            splitContainer.TabIndex = 0;
            // 
            // dataGridView
            // 
            dataGridView.ColumnHeadersHeight = 46;
            dataGridView.Location = new Point(1, 399);
            dataGridView.Name = "dataGridView";
            dataGridView.RowHeadersWidth = 82;
            dataGridView.Size = new Size(473, 467);
            // 
            // treeView
            // 
            treeView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            treeView.Location = new Point(3, 5);
            treeView.Name = "treeView";
            treeView.Size = new Size(498, 388);
            treeView.TabIndex = 0;
            treeView.AfterSelect += TreeView_AfterSelect;
            // 
            // btnLoad
            // 
            btnLoad.Location = new Point(10, 5);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(75, 64);
            btnLoad.TabIndex = 1;
            btnLoad.Text = "Загрузить";
            btnLoad.Click += BtnLoad_Click;
            btnLoad.Click += BtnLoad_Click;
            // 
            // btnSaveDb
            // 
            btnSaveDb.Location = new Point(120, 5);
            btnSaveDb.Name = "btnSaveDb";
            btnSaveDb.Size = new Size(75, 67);
            btnSaveDb.TabIndex = 2;
            btnSaveDb.Text = "Сохранить в БД";
            btnSaveDb.Click += BtnSaveDb_Click;
            // 
            // btnDetails
            // 
            btnDetails.Location = new Point(237, 12);
            btnDetails.Name = "btnDetails";
            btnDetails.Size = new Size(83, 57);
            btnDetails.TabIndex = 3;
            btnDetails.Text = "Подробнее";
            btnDetails.Click += BtnDetails_Click;
            // 
            // pictureBox
            // 
            pictureBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            pictureBox.Location = new Point(434, 556);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(246, 307);
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox.TabIndex = 4;
            pictureBox.Image = Image.FromFile("../../../../maxresdefault.jpg");
            pictureBox.TabStop = false;
            // 
            // MainForm
            // 
            ClientSize = new Size(1699, 866);
            Controls.Add(splitContainer);
            Name = "MainForm";
            Text = "Управление лагерем";
            splitContainer.Panel1.ResumeLayout(false);
            splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer).EndInit();
            splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
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

    }
}