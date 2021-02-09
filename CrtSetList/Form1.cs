using CrtSetList.MyClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrtSetList
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // загрузка списка итемов
            LoadItemList loadItemList = new LoadItemList();
            loadItemList.LoadItemRecordList();

            listBox1.ClearSelected();
            listBox1.Refresh();
            dataGridView1.ClearSelection();

            // Grid
            dataGridView1.AutoGenerateColumns = false;

            DataGridViewCheckBoxColumn checkBoxCol = new DataGridViewCheckBoxColumn() 
            { 
                HeaderText = "Выбор",
                Width = 50,
                SortMode = DataGridViewColumnSortMode.Automatic
            };
           

            DataGridViewTextBoxColumn category = new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Category",
                HeaderText = "Категория",
                Width = 150,
                SortMode = DataGridViewColumnSortMode.Automatic
            };

            DataGridViewTextBoxColumn name = new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Name",
                HeaderText = "Название",
                Width = 150,
                SortMode = DataGridViewColumnSortMode.Automatic
            };


            DataGridViewTextBoxColumn quantity = new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Quantity",
                HeaderText = "Качество",
                Width = 100,
                SortMode = DataGridViewColumnSortMode.Automatic
            };


            DataGridViewTextBoxColumn costPrice = new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "CostPrice",
                HeaderText = "Цена покупки",
                Width = 100,
                SortMode = DataGridViewColumnSortMode.Automatic
            };

            DataGridViewTextBoxColumn sellPrice = new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "SellPrice",
                HeaderText = "Цена продажи",
                Width = 100,
                SortMode = DataGridViewColumnSortMode.Automatic
            };

            DataGridViewTextBoxColumn description = new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Description",
                HeaderText = "Описание",
                Width = 150,
                SortMode = DataGridViewColumnSortMode.Automatic
            };

            dataGridView1.Columns.Add(checkBoxCol);
            dataGridView1.Columns.Add(category);
            dataGridView1.Columns.Add(name);
            dataGridView1.Columns.Add(quantity);
            dataGridView1.Columns.Add(costPrice);
            dataGridView1.Columns.Add(sellPrice);
            dataGridView1.Columns.Add(description);

            dataGridView1.DataSource = loadItemList.GetFullItemRecordList();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
