using Rastvors.Common.Entities;
using System.Collections;
using System.Data;

namespace Rastvors.WinFormsApp
{
    public partial class AddComponentForm : Form
    {
        DataGridView _dataGrid_Components;

        Rastvor _currenRastvor;

        Label _label_IsCorrectStructure_MainForm;

        List<Component> _FreeComponents;
        public AddComponentForm(DataGridView dataGrid_Components, Rastvor rastvor, Label label_IsCorrectStructure)
        {
            InitializeComponent();

            textBox_Value.KeyPress += new KeyPressEventHandler(textBox_Value_KeyPress);
            textBox_Value.Text = "0.0";

            _currenRastvor = rastvor;
            var list_component = MainForm.Components.Where(
                        x => _currenRastvor.Structures.FirstOrDefault(y => y.ComponentId == x.Id) == null)
                        .ToList();
            _FreeComponents = list_component;

            var items = new ArrayList();
            foreach (var item in _FreeComponents)
            {
                items.Add(item.Name);
            }

            comboBox_Name.Items.AddRange(items.ToArray());

            _dataGrid_Components = dataGrid_Components;

            //Коректность Состава
            _label_IsCorrectStructure_MainForm = label_IsCorrectStructure;
        }

        /// <summary>
        /// Ограничение на поле Значения, чирьы вводилось число > 0
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            // Проверяет что значение <= 100
            else if (double.TryParse((sender as TextBox).Text + e.KeyChar, out double value) && value > 100)
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Добавления Компанента для текущего Раствора
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Add_Click(object sender, EventArgs e)
        {
            string name = comboBox_Name.Text;
            double value = Double.Parse(textBox_Value.Text.Replace('.', ','));
            //double value = Double.Parse("0,0");

            // Проверка условия
            if (value > 0)
            {
                var component = _FreeComponents.First(x => x.Name == name);
                var row = new Structure()
                {
                    RastvorId = _currenRastvor.Id,
                    ComponentId = component.Id,
                    Component = new Component()
                    {
                        Id = component.Id,
                        Name = component.Name,
                    },
                    Value = value
                };
                _currenRastvor.Structures.Add(row);

                _dataGrid_Components.Rows.Add(row.Component.Name, row.Value);
                //_dataGrid_Rastvors.Rows.Add(row.Name, row.Value);
                _dataGrid_Components.ClearSelection();

                if (_currenRastvor.IsCorrectStructure())
                {
                    _label_IsCorrectStructure_MainForm.Text = "Готов";
                    _label_IsCorrectStructure_MainForm.BackColor = Color.Green;
                }
                else
                {
                    _label_IsCorrectStructure_MainForm.Text = "Ошибка";
                    _label_IsCorrectStructure_MainForm.BackColor = Color.Red;
                }

                this.Close();
            }
            else
            {
                // Отображение окна ошибки с пояснением
                MessageBox.Show("Ошибка: условие не выполнено.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
