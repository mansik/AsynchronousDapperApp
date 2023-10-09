namespace AsynchronousDapper
{
    partial class FormAsync
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridView = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            idTextBox = new TextBox();
            label1 = new Label();
            newButton = new Button();
            firstNameTextBox = new TextBox();
            label2 = new Label();
            lastNameTextBox = new TextBox();
            label3 = new Label();
            DeleteButton = new Button();
            SaveButton = new Button();
            showFormSyncbutton = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // dataGridView
            // 
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.AllowUserToResizeColumns = false;
            dataGridView.AllowUserToResizeRows = false;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.BackgroundColor = Color.White;
            dataGridView.BorderStyle = BorderStyle.None;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, Column3 });
            dataGridView.Location = new Point(12, 24);
            dataGridView.MultiSelect = false;
            dataGridView.Name = "dataGridView";
            dataGridView.ReadOnly = true;
            dataGridView.RowHeadersVisible = false;
            dataGridView.RowTemplate.Height = 27;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.Size = new Size(383, 233);
            dataGridView.TabIndex = 0;
            dataGridView.CellContentClick += dataGridView1_CellContentClick;
            dataGridView.SelectionChanged += dataGridView_SelectionChanged;
            // 
            // Column1
            // 
            Column1.DataPropertyName = "Id";
            Column1.HeaderText = "Id";
            Column1.Name = "Column1";
            Column1.ReadOnly = true;
            // 
            // Column2
            // 
            Column2.DataPropertyName = "FirstName";
            Column2.HeaderText = "First Name";
            Column2.Name = "Column2";
            Column2.ReadOnly = true;
            // 
            // Column3
            // 
            Column3.DataPropertyName = "LastName";
            Column3.HeaderText = "Last Name";
            Column3.Name = "Column3";
            Column3.ReadOnly = true;
            // 
            // idTextBox
            // 
            idTextBox.Location = new Point(491, 20);
            idTextBox.Name = "idTextBox";
            idTextBox.ReadOnly = true;
            idTextBox.Size = new Size(100, 25);
            idTextBox.TabIndex = 1;
            idTextBox.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(416, 24);
            label1.Name = "label1";
            label1.Size = new Size(24, 17);
            label1.TabIndex = 2;
            label1.Text = "ID:";
            // 
            // newButton
            // 
            newButton.Location = new Point(445, 130);
            newButton.Name = "newButton";
            newButton.Size = new Size(75, 34);
            newButton.TabIndex = 4;
            newButton.Text = "New";
            newButton.UseVisualStyleBackColor = true;
            newButton.Click += newButton_Click;
            // 
            // firstNameTextBox
            // 
            firstNameTextBox.Location = new Point(491, 51);
            firstNameTextBox.Name = "firstNameTextBox";
            firstNameTextBox.Size = new Size(191, 25);
            firstNameTextBox.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(416, 55);
            label2.Name = "label2";
            label2.Size = new Size(75, 17);
            label2.TabIndex = 2;
            label2.Text = "Frist Name:";
            // 
            // lastNameTextBox
            // 
            lastNameTextBox.Location = new Point(491, 82);
            lastNameTextBox.Name = "lastNameTextBox";
            lastNameTextBox.Size = new Size(191, 25);
            lastNameTextBox.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(416, 86);
            label3.Name = "label3";
            label3.Size = new Size(74, 17);
            label3.TabIndex = 2;
            label3.Text = "Last Name:";
            // 
            // DeleteButton
            // 
            DeleteButton.Location = new Point(526, 130);
            DeleteButton.Name = "DeleteButton";
            DeleteButton.Size = new Size(75, 34);
            DeleteButton.TabIndex = 5;
            DeleteButton.Text = "Delete";
            DeleteButton.UseVisualStyleBackColor = true;
            DeleteButton.Click += DeleteButton_Click;
            // 
            // SaveButton
            // 
            SaveButton.Location = new Point(607, 130);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new Size(75, 34);
            SaveButton.TabIndex = 6;
            SaveButton.Text = "Save";
            SaveButton.UseVisualStyleBackColor = true;
            SaveButton.Click += SaveButton_Click;
            // 
            // showFormSyncbutton
            // 
            showFormSyncbutton.Location = new Point(445, 210);
            showFormSyncbutton.Name = "showFormSyncbutton";
            showFormSyncbutton.Size = new Size(234, 38);
            showFormSyncbutton.TabIndex = 7;
            showFormSyncbutton.Text = "ShowFromSync";
            showFormSyncbutton.UseVisualStyleBackColor = true;
            showFormSyncbutton.Click += showFormSyncbutton_Click;
            // 
            // FormAsync
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(690, 269);
            Controls.Add(showFormSyncbutton);
            Controls.Add(SaveButton);
            Controls.Add(DeleteButton);
            Controls.Add(newButton);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(lastNameTextBox);
            Controls.Add(firstNameTextBox);
            Controls.Add(idTextBox);
            Controls.Add(dataGridView);
            Name = "FormAsync";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView;
        private TextBox idTextBox;
        private Label label1;
        private Button newButton;
        private TextBox firstNameTextBox;
        private Label label2;
        private TextBox lastNameTextBox;
        private Label label3;
        private Button DeleteButton;
        private Button SaveButton;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private Button showFormSyncbutton;
    }
}