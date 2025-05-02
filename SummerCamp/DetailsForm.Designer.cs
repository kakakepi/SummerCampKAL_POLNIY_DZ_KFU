namespace SummerCamp
{
    partial class DetailsForm
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
            lblAge = new Label();
            lblCabin = new Label();
            lblPhone = new Label();
            lblEmail = new Label();
            listSchedule = new ListBox();
            lblName = new Label();
            SuspendLayout();
            // 
            // lblAge
            // 
            lblAge.BackColor = SystemColors.ControlLight;
            lblAge.Location = new Point(19, 137);
            lblAge.Name = "lblAge";
            lblAge.Size = new Size(230, 30);
            lblAge.TabIndex = 0;
            // 
            // lblCabin
            // 
            lblCabin.BackColor = SystemColors.ControlLight;
            lblCabin.Location = new Point(19, 178);
            lblCabin.Name = "lblCabin";
            lblCabin.Size = new Size(229, 30);
            lblCabin.TabIndex = 1;
            // 
            // lblPhone
            // 
            lblPhone.Location = new Point(19, 178);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(229, 30);
            lblPhone.TabIndex = 2;
            // 
            // lblEmail
            // 
            lblEmail.BackColor = SystemColors.ControlLight;
            lblEmail.Location = new Point(19, 218);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(229, 30);
            lblEmail.TabIndex = 3;
            // 
            // listSchedule
            // 
            listSchedule.Location = new Point(19, 260);
            listSchedule.Name = "listSchedule";
            listSchedule.Size = new Size(286, 132);
            listSchedule.TabIndex = 4;
            // 
            // lblName
            // 
            lblName.BackColor = SystemColors.ControlLight;
            lblName.Location = new Point(19, 91);
            lblName.Name = "lblName";
            lblName.Size = new Size(230, 37);
            lblName.TabIndex = 5;
            // 
            // DetailsForm
            // 
            ClientSize = new Size(1334, 742);
            Controls.Add(lblName);
            Controls.Add(lblAge);
            Controls.Add(lblCabin);
            Controls.Add(lblPhone);
            Controls.Add(lblEmail);
            Controls.Add(listSchedule);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "DetailsForm";
            Text = "Детали участника";
            ResumeLayout(false);
        }

        #endregion
        private Label lblAge;
        private Label lblCabin;
        private Label lblPhone;
        private Label lblEmail;
        private ListBox listSchedule;
        private Label lblName;
    }
}