namespace Rastvors.WinFormsApp
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
            button_Save = new Button();
            button_Update = new Button();
            label1 = new Label();
            label2 = new Label();
            dataGridView_Rastvors = new DataGridView();
            Column_Name = new DataGridViewTextBoxColumn();
            Column_Value = new DataGridViewTextBoxColumn();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            dataGridView_Components = new DataGridView();
            Column_Component_Name = new DataGridViewTextBoxColumn();
            Column_Component_Value = new DataGridViewTextBoxColumn();
            button_AddRastvor = new Button();
            button_DeleteRastvor = new Button();
            button_AddComponent = new Button();
            button_DeleteComponent = new Button();
            label_IsCorrectStructure = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView_Rastvors).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView_Components).BeginInit();
            SuspendLayout();
            // 
            // button_Save
            // 
            button_Save.Location = new Point(122, 12);
            button_Save.Name = "button_Save";
            button_Save.Size = new Size(75, 23);
            button_Save.TabIndex = 0;
            button_Save.Text = "Сохранить";
            button_Save.UseVisualStyleBackColor = true;
            button_Save.Click += button_Save_Click;
            // 
            // button_Update
            // 
            button_Update.Location = new Point(21, 12);
            button_Update.Name = "button_Update";
            button_Update.Size = new Size(75, 23);
            button_Update.TabIndex = 1;
            button_Update.Text = "Обновить";
            button_Update.UseVisualStyleBackColor = true;
            button_Update.Click += button_Update_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(21, 84);
            label1.Name = "label1";
            label1.Size = new Size(86, 21);
            label1.TabIndex = 2;
            label1.Text = "Растворы";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(21, 310);
            label2.Name = "label2";
            label2.Size = new Size(63, 21);
            label2.TabIndex = 3;
            label2.Text = "Состав";
            // 
            // dataGridView_Rastvors
            // 
            dataGridView_Rastvors.AllowUserToAddRows = false;
            dataGridView_Rastvors.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView_Rastvors.Columns.AddRange(new DataGridViewColumn[] { Column_Name, Column_Value });
            dataGridView_Rastvors.Location = new Point(21, 110);
            dataGridView_Rastvors.Name = "dataGridView_Rastvors";
            dataGridView_Rastvors.RowTemplate.Height = 25;
            dataGridView_Rastvors.Size = new Size(605, 175);
            dataGridView_Rastvors.TabIndex = 4;
            dataGridView_Rastvors.CellClick += dataGridView_Rastvors_CellClick;
            // 
            // Column_Name
            // 
            Column_Name.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Column_Name.HeaderText = "Название";
            Column_Name.Name = "Column_Name";
            Column_Name.ReadOnly = true;
            // 
            // Column_Value
            // 
            Column_Value.HeaderText = "Объем, м3";
            Column_Value.Name = "Column_Value";
            Column_Value.ReadOnly = true;
            Column_Value.Width = 150;
            // 
            // dataGridView_Components
            // 
            dataGridView_Components.AllowUserToAddRows = false;
            dataGridView_Components.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView_Components.Columns.AddRange(new DataGridViewColumn[] { Column_Component_Name, Column_Component_Value });
            dataGridView_Components.Location = new Point(21, 339);
            dataGridView_Components.Name = "dataGridView_Components";
            dataGridView_Components.RowTemplate.Height = 25;
            dataGridView_Components.Size = new Size(605, 192);
            dataGridView_Components.TabIndex = 5;
            // 
            // Column_Component_Name
            // 
            Column_Component_Name.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Column_Component_Name.HeaderText = "Компонент";
            Column_Component_Name.Name = "Column_Component_Name";
            Column_Component_Name.ReadOnly = true;
            // 
            // Column_Component_Value
            // 
            Column_Component_Value.FillWeight = 150F;
            Column_Component_Value.HeaderText = "Количество, %";
            Column_Component_Value.Name = "Column_Component_Value";
            Column_Component_Value.ReadOnly = true;
            Column_Component_Value.Width = 150;
            // 
            // button_AddRastvor
            // 
            button_AddRastvor.Location = new Point(508, 81);
            button_AddRastvor.Name = "button_AddRastvor";
            button_AddRastvor.Size = new Size(56, 23);
            button_AddRastvor.TabIndex = 6;
            button_AddRastvor.Text = "+";
            button_AddRastvor.UseVisualStyleBackColor = true;
            button_AddRastvor.Click += button_AddRastvor_Click;
            // 
            // button_DeleteRastvor
            // 
            button_DeleteRastvor.Location = new Point(570, 81);
            button_DeleteRastvor.Name = "button_DeleteRastvor";
            button_DeleteRastvor.Size = new Size(56, 23);
            button_DeleteRastvor.TabIndex = 7;
            button_DeleteRastvor.Text = "-";
            button_DeleteRastvor.UseVisualStyleBackColor = true;
            button_DeleteRastvor.Click += button_DeleteRastvor_Click;
            // 
            // button_AddComponent
            // 
            button_AddComponent.Location = new Point(508, 310);
            button_AddComponent.Name = "button_AddComponent";
            button_AddComponent.Size = new Size(56, 23);
            button_AddComponent.TabIndex = 8;
            button_AddComponent.Text = "+";
            button_AddComponent.UseVisualStyleBackColor = true;
            button_AddComponent.Click += button_AddComponent_Click;
            // 
            // button_DeleteComponent
            // 
            button_DeleteComponent.Location = new Point(570, 310);
            button_DeleteComponent.Name = "button_DeleteComponent";
            button_DeleteComponent.Size = new Size(56, 23);
            button_DeleteComponent.TabIndex = 9;
            button_DeleteComponent.Text = "-";
            button_DeleteComponent.UseVisualStyleBackColor = true;
            button_DeleteComponent.Click += button_DeleteComponent_Click;
            // 
            // label_IsCorrectStructure
            // 
            label_IsCorrectStructure.AutoSize = true;
            label_IsCorrectStructure.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label_IsCorrectStructure.Location = new Point(90, 310);
            label_IsCorrectStructure.Name = "label_IsCorrectStructure";
            label_IsCorrectStructure.Size = new Size(17, 21);
            label_IsCorrectStructure.TabIndex = 10;
            label_IsCorrectStructure.Text = "?";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(826, 589);
            Controls.Add(label_IsCorrectStructure);
            Controls.Add(button_DeleteComponent);
            Controls.Add(button_AddComponent);
            Controls.Add(button_DeleteRastvor);
            Controls.Add(button_AddRastvor);
            Controls.Add(dataGridView_Components);
            Controls.Add(dataGridView_Rastvors);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button_Update);
            Controls.Add(button_Save);
            Name = "MainForm";
            Text = "MainForm";
            ((System.ComponentModel.ISupportInitialize)dataGridView_Rastvors).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView_Components).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button_Save;
        private Button button_Update;
        private Label label1;
        private Label label2;
        private DataGridView dataGridView_Rastvors;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private DataGridView dataGridView_Components;
        private DataGridViewTextBoxColumn Column_Name;
        private DataGridViewTextBoxColumn Column_Value;
        private DataGridViewTextBoxColumn Column_Component_Name;
        private DataGridViewTextBoxColumn Column_Component_Value;
        private Button button_AddRastvor;
        private Button button_DeleteRastvor;
        private Button button_AddComponent;
        private Button button_DeleteComponent;
        private Label label_IsCorrectStructure;
    }
}