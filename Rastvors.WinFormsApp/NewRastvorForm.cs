using Rastvors.Common.Entities;

namespace Rastvors.WinFormsApp
{
    public partial class NewRastvorForm : Form
    {
        DataGridView _dataGrid_Rastvors;
        public NewRastvorForm(DataGridView dataGrid_Rastvors)
        {
            InitializeComponent();

            textBox_Value.KeyPress += new KeyPressEventHandler(textBox_Value_KeyPress);
            textBox_Value.Text = "0.0";

            _dataGrid_Rastvors = dataGrid_Rastvors;

        }


        private void textBox_Value_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // Проверьте, что значение больше нуля
            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void button_Add_Click(object sender, EventArgs e)
        {
            string name = textBox_Name.Text;
            double value = Double.Parse(textBox_Value.Text.Replace('.', ','));
            //double value = Double.Parse("0,0");

            // Проверка условия
            if (!String.IsNullOrEmpty(name) &&
                MainForm.RastvorsDATA.FirstOrDefault(x => x.Name == name) == null &&
                value > 0)
            {
                var row = new Rastvor()
                {
                    Name = name,
                    Value = value
                };
                MainForm.RastvorsDATA.Add(row);

                _dataGrid_Rastvors.Rows.Add(row.Name, row.Value);
                _dataGrid_Rastvors.ClearSelection();

                this.Close();
            }
            else
            {
                // Отображение окна ошибки с пояснением
                MessageBox.Show("Ошибка: условие не выполнено.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void NewRastvorForm_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
    }
}
