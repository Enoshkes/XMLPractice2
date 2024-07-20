namespace XMLPractice2
{
    partial class Form1
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
            AddContactButton = new Button();
            PhoneTextBox = new TextBox();
            NameTextBox = new TextBox();
            ContactGridView = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)ContactGridView).BeginInit();
            SuspendLayout();
            // 
            // AddContactButton
            // 
            AddContactButton.Location = new Point(287, 336);
            AddContactButton.Name = "AddContactButton";
            AddContactButton.Size = new Size(137, 29);
            AddContactButton.TabIndex = 0;
            AddContactButton.Text = "Add Contact";
            AddContactButton.UseVisualStyleBackColor = true;
            AddContactButton.Click += AddContactClickHandler;
            // 
            // PhoneTextBox
            // 
            PhoneTextBox.Location = new Point(458, 338);
            PhoneTextBox.Name = "PhoneTextBox";
            PhoneTextBox.PlaceholderText = "Phone";
            PhoneTextBox.Size = new Size(125, 27);
            PhoneTextBox.TabIndex = 1;
            // 
            // NameTextBox
            // 
            NameTextBox.Location = new Point(608, 338);
            NameTextBox.Name = "NameTextBox";
            NameTextBox.PlaceholderText = "Name";
            NameTextBox.Size = new Size(125, 27);
            NameTextBox.TabIndex = 2;
            // 
            // ContactGridView
            // 
            ContactGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ContactGridView.Location = new Point(180, 37);
            ContactGridView.Name = "ContactGridView";
            ContactGridView.RowHeadersWidth = 51;
            ContactGridView.Size = new Size(553, 267);
            ContactGridView.TabIndex = 3;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(ContactGridView);
            Controls.Add(NameTextBox);
            Controls.Add(PhoneTextBox);
            Controls.Add(AddContactButton);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)ContactGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button AddContactButton;
        private TextBox PhoneTextBox;
        private TextBox NameTextBox;
        private DataGridView ContactGridView;
    }
}
