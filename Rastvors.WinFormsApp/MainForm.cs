using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Rastvors.BLL.Interfaces;
using Rastvors.Common.Entities;
using Rastvors.DAL;
using Rastvors.Dependencies;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rastvors.WinFormsApp
{
    public partial class MainForm : Form
    {
        private IRastvorsManagerLogic _rastvorsManagerBLL;

        public static List<Rastvor> RastvorsDATA = new List<Rastvor>();

        public static List<Component> Components = new List<Component>();

        public MainForm()
        {
            InitializeComponent();

            _rastvorsManagerBLL = DependencyResolver.Instance.RastvorsManagerLogic;

            //var a = new ApplicationDBContext();

            //foreach (var row in a.Components)
            //{
            //    dataGridView_Rastvors.Rows.Add(row.Name, row.Id);
            //}

            var a = _rastvorsManagerBLL.GetAllRastvors();
            var b = _rastvorsManagerBLL.GetAllComponents();

            if (a != null)
            {
                RastvorsDATA.AddRange(a);
            }
            if (b != null)
            {
                Components.AddRange(b);
            }

            //foreach (var row in Components)
            //{
            //    dataGridView_Rastvors.Rows.Add(row.Name, row.Id);
            //}

            foreach (var row in RastvorsDATA)
            {
                dataGridView_Rastvors.Rows.Add(row.Name, row.Value);
            }

            //При выделении ячейки в Растворах
            dataGridView_Rastvors.CellClick += new DataGridViewCellEventHandler(dataGridView_Rastvors_CellClick);
        }


        public Component AddComponent()
        {
            using (var a = new ApplicationDBContext())
            {
                a.Components.Add(new Component()
                {
                    Name = "COMPCOMP"
                });
                var comp = a.Components.FirstOrDefault(x => x.Name == "comp1");
                return new Component()
                {
                    Id = comp.Id,
                    Name = comp.Name
                };
            }

            //return new Component();
        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            //var comp = AddComponent();

            //dataGridView_Rastvors.Rows.Add(comp.Name, comp.Id);

            foreach (var row in RastvorsDATA)
            {
                if (!row.IsCorrectStructure())
                {
                    MessageBox.Show("Ошибка: условие не выполнено.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            
            if (_rastvorsManagerBLL.Save(RastvorsDATA))
            {
                MessageBox.Show("Успех: успешная запись в БД.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Update_DataGrid();
            }
            else
            {
                // Отображение окна ошибки с пояснением
                MessageBox.Show("Ошибка: проблема записи в БД.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        /// <summary>
        /// Перезагрузка данных из БД
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Update_Click(object sender, EventArgs e)
        {
            Update_DataGrid();
        }

        /// <summary>
        /// Обновление таблицы
        /// </summary>
        private void Update_DataGrid()
        {
            dataGridView_Rastvors.Rows.Clear();
            dataGridView_Components.Rows.Clear();

            var a = _rastvorsManagerBLL.GetAllRastvors();

            if (a != null)
            {
                RastvorsDATA = new List<Rastvor>();
                RastvorsDATA.AddRange(a);

                foreach (var row in RastvorsDATA)
                {
                    dataGridView_Rastvors.Rows.Add(row.Name, row.Value);
                }
            }

            label_IsCorrectStructure.Text = "?";
            label_IsCorrectStructure.BackColor = Color.White;
        }


        /// <summary>
        /// Добавление нового Раствора, с откртытием новой Формы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_AddRastvor_Click(object sender, EventArgs e)
        {
            // Создайте новый экземпляр формы
            NewRastvorForm form_NewRastvor = new NewRastvorForm(dataGridView_Rastvors);

            // Откройте новую форму
            form_NewRastvor.Show();

            // Передайте данные в поля формы
            //form_NewRastvor.textBox_Value.Text = "Some data";
            //form_NewRastvor.textb.Text = "More data";
        }

        /// <summary>
        /// Удаление выделенного Раствора
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_DeleteRastvor_Click(object sender, EventArgs e)
        {
            if (dataGridView_Rastvors.SelectedRows.Count > 0 || dataGridView_Rastvors.SelectedCells.Count > 0)
            {
                int ind = dataGridView_Rastvors.CurrentCell.RowIndex;
                string name = dataGridView_Rastvors.Rows[ind].Cells[0].Value.ToString();
                var rast_remove = RastvorsDATA.FirstOrDefault(x => x.Name == name);
                if (rast_remove != null)
                {
                    RastvorsDATA.Remove(rast_remove);
                }
                dataGridView_Rastvors.Rows.RemoveAt(ind);
            }
        }


        /// <summary>
        /// Обновление таблицы Состава при выборе (выделении) Раствора
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView_Rastvors_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView_Rastvors.SelectedRows.Count > 0 || dataGridView_Rastvors.SelectedCells.Count > 0)
            {
                int ind = dataGridView_Rastvors.CurrentCell.RowIndex;
                string name = dataGridView_Rastvors.Rows[ind].Cells[0].Value.ToString();
                var rast_current = RastvorsDATA.FirstOrDefault(x => x.Name == name);

                if (rast_current != null)
                {
                    dataGridView_Components.Rows.Clear();
                    foreach (var structure in rast_current.Structures)
                    {
                        dataGridView_Components.Rows.Add(structure.Component.Name, structure.Value);
                    }
                    if (rast_current.IsCorrectStructure())
                    {
                        label_IsCorrectStructure.Text = "Готов";
                        label_IsCorrectStructure.BackColor = Color.Green;
                    }
                    else
                    {
                        label_IsCorrectStructure.Text = "Ошибка";
                        label_IsCorrectStructure.BackColor = Color.Red;
                    }
                }
            }
        }

        /// <summary>
        /// Добавление нового Компанента для выделеного Раствора, с открытием новой формы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_AddComponent_Click(object sender, EventArgs e)
        {
            if (dataGridView_Rastvors.SelectedRows.Count > 0 || dataGridView_Rastvors.SelectedCells.Count > 0)
            {
                int ind = dataGridView_Rastvors.CurrentCell.RowIndex;
                string name = dataGridView_Rastvors.Rows[ind].Cells[0].Value.ToString();
                var rast_current = RastvorsDATA.FirstOrDefault(x => x.Name == name);

                if (rast_current != null)
                {
                    //var list_component = Components.Where(
                    //    x=>rast_current.Structures.FirstOrDefault(y=>y.ComponentId==x.Id)==null)
                    //    .ToList();
                    // Создайте новый экземпляр формы
                    AddComponentForm form_AddComponent = new AddComponentForm(dataGridView_Components, rast_current, label_IsCorrectStructure);

                    // Откройте новую форму
                    form_AddComponent.Show();
                }

            }
        }

        /// <summary>
        /// Удаление выбранного Компанента для выделеного Раствора, с открытием новой формы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_DeleteComponent_Click(object sender, EventArgs e)
        {
            if ((dataGridView_Rastvors.SelectedRows.Count > 0 || dataGridView_Rastvors.SelectedCells.Count > 0) &&
                (dataGridView_Components.SelectedRows.Count > 0 || dataGridView_Components.SelectedCells.Count > 0))
            {
                int ind_row_rast = dataGridView_Rastvors.CurrentCell.RowIndex;
                string name_rast = dataGridView_Rastvors.Rows[ind_row_rast].Cells[0].Value.ToString();
                var rast_current = RastvorsDATA.FirstOrDefault(x => x.Name == name_rast);

                if (rast_current != null)
                {
                    int ind_row_comp = dataGridView_Components.CurrentCell.RowIndex;
                    string name_comp = dataGridView_Components.Rows[ind_row_comp].Cells[0].Value.ToString();

                    var comp_current = rast_current.Structures.FirstOrDefault(x => x.Component.Name == name_comp);
                    if (comp_current != null)
                    {
                        dataGridView_Components.Rows.RemoveAt(ind_row_comp);
                        rast_current.Structures.Remove(comp_current);

                        if (rast_current.IsCorrectStructure())
                        {
                            label_IsCorrectStructure.Text = "Готов";
                            label_IsCorrectStructure.BackColor = Color.Green;
                        }
                        else
                        {
                            label_IsCorrectStructure.Text = "Ошибка";
                            label_IsCorrectStructure.BackColor = Color.Red;
                        }
                    }
                }
                //int ind = dataGridView_Components.CurrentCell.RowIndex;
                //string name = dataGridView_Components.Rows[ind].Cells[0].Value.ToString();
                //var rast_remove = RastvorsDATA.FirstOrDefault(x => x.Name == name);
                //if (rast_remove != null)
                //{
                //    RastvorsDATA.Remove(rast_remove);
                //}
                //dataGridView_Rastvors.Rows.RemoveAt(ind);
            }
        }



        //private void dataGridView_Components_CellClick(object sender, DataGridViewCellEventArgs e)
        //{


        //}

        //public static void OnForm2Closed()
        //{
        //    dataGridView_Rastvors.Rows.Clear();
        //}
    }
}
