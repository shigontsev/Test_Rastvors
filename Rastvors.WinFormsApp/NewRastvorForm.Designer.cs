namespace Rastvors.WinFormsApp
{
    partial class NewRastvorForm
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
            label2 = new Label();
            label1 = new Label();
            textBox_Value = new TextBox();
            textBox_Name = new TextBox();
            button_Add = new Button();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(54, 128);
            label2.Name = "label2";
            label2.Size = new Size(91, 21);
            label2.TabIndex = 3;
            label2.Text = "Обхем, м3";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(54, 41);
            label1.Name = "label1";
            label1.Size = new Size(86, 21);
            label1.TabIndex = 4;
            label1.Text = "Название";
            // 
            // textBox_Value
            // 
            textBox_Value.Location = new Point(54, 172);
            textBox_Value.Name = "textBox_Value";
            textBox_Value.Size = new Size(187, 23);
            textBox_Value.TabIndex = 5;
            textBox_Value.KeyPress += textBox_Value_KeyPress;
            // 
            // textBox_Name
            // 
            textBox_Name.Location = new Point(54, 78);
            textBox_Name.Name = "textBox_Name";
            textBox_Name.Size = new Size(187, 23);
            textBox_Name.TabIndex = 6;
            // 
            // button_Add
            // 
            button_Add.Location = new Point(54, 239);
            button_Add.Name = "button_Add";
            button_Add.Size = new Size(75, 23);
            button_Add.TabIndex = 7;
            button_Add.Text = "Add";
            button_Add.UseVisualStyleBackColor = true;
            button_Add.Click += button_Add_Click;
            // 
            // NewRastvorForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button_Add);
            Controls.Add(textBox_Name);
            Controls.Add(textBox_Value);
            Controls.Add(label1);
            Controls.Add(label2);
            Name = "NewRastvorForm";
            Text = "NewRastvorForm";
            FormClosed += NewRastvorForm_FormClosed;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label2;
        private Label label1;
        private TextBox textBox_Value;
        private TextBox textBox_Name;
        private Button button_Add;
    }
}