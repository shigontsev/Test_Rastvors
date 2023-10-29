namespace Rastvors.WinFormsApp
{
    partial class AddComponentForm
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
            comboBox_Name = new ComboBox();
            label1 = new Label();
            textBox_Value = new TextBox();
            label2 = new Label();
            button_Add = new Button();
            SuspendLayout();
            // 
            // comboBox_Name
            // 
            comboBox_Name.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_Name.FormattingEnabled = true;
            comboBox_Name.Location = new Point(42, 58);
            comboBox_Name.Name = "comboBox_Name";
            comboBox_Name.Size = new Size(187, 23);
            comboBox_Name.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(42, 19);
            label1.Name = "label1";
            label1.Size = new Size(86, 21);
            label1.TabIndex = 5;
            label1.Text = "Название";
            // 
            // textBox_Value
            // 
            textBox_Value.Location = new Point(42, 156);
            textBox_Value.Name = "textBox_Value";
            textBox_Value.Size = new Size(187, 23);
            textBox_Value.TabIndex = 6;
            textBox_Value.KeyPress += textBox_Value_KeyPress;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(42, 105);
            label2.Name = "label2";
            label2.Size = new Size(125, 21);
            label2.TabIndex = 7;
            label2.Text = "Количество, %";
            // 
            // button_Add
            // 
            button_Add.Location = new Point(42, 221);
            button_Add.Name = "button_Add";
            button_Add.Size = new Size(75, 23);
            button_Add.TabIndex = 8;
            button_Add.Text = "Add";
            button_Add.UseVisualStyleBackColor = true;
            button_Add.Click += button_Add_Click;
            // 
            // AddComponentForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button_Add);
            Controls.Add(label2);
            Controls.Add(textBox_Value);
            Controls.Add(label1);
            Controls.Add(comboBox_Name);
            Name = "AddComponentForm";
            Text = "AddComponentForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBox_Name;
        private Label label1;
        private TextBox textBox_Value;
        private Label label2;
        private Button button_Add;
    }
}