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
        public LoadItemList loadItemList = new LoadItemList();

        public Form1()
        {
            InitializeComponent();


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // загрузка списка итемов
            loadItemList.LoadItemRecordList();
             
            dataGridView1.ClearSelection();
            richTextBox1.Clear();

            // Grid 
            ConfigDataGridView();
             
            dataGridView1.DataSource = loadItemList.GetFullItemRecordList();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void ConfigDataGridView()
        {
            dataGridView1.AutoGenerateColumns = false;
            // запрет на изменение размера строк и столбцов
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            // запрет добавления строк
            dataGridView1.AllowUserToAddRows = false;


            DataGridViewCheckBoxColumn checkBoxCol = new DataGridViewCheckBoxColumn()
            {
                DataPropertyName = "CheckBox",
                HeaderText = "Выбор",
                Width = 50,
                SortMode = DataGridViewColumnSortMode.Automatic
            };


            DataGridViewTextBoxColumn category = new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Category",
                HeaderText = "Категория",
                Width = 300,
                SortMode = DataGridViewColumnSortMode.Automatic,
                ReadOnly = true
            };

            DataGridViewTextBoxColumn name = new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Name",
                HeaderText = "Название",
                Width = 250,
                SortMode = DataGridViewColumnSortMode.Automatic,
                ReadOnly = true
            };


            DataGridViewTextBoxColumn quantity = new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Quantity",
                HeaderText = "Качество",
                Width = 100,
                SortMode = DataGridViewColumnSortMode.Automatic,
                ReadOnly = true
            };

            DataGridViewTextBoxColumn costPrice = new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "CostPrice",
                HeaderText = "Цена покупки",
                Width = 100,
                SortMode = DataGridViewColumnSortMode.Automatic,
                ReadOnly = true
            };

            DataGridViewTextBoxColumn sellPrice = new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "SellPrice",
                HeaderText = "Цена продажи",
                Width = 100,
                SortMode = DataGridViewColumnSortMode.Automatic,
                ReadOnly = true
            };

            DataGridViewTextBoxColumn description = new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Description",
                HeaderText = "Описание",
                Width = 150,
                SortMode = DataGridViewColumnSortMode.Automatic,
                ReadOnly = true
            };

            dataGridView1.Columns.Add(checkBoxCol);
            dataGridView1.Columns.Add(category);
            dataGridView1.Columns.Add(name);
            dataGridView1.Columns.Add(description);
            dataGridView1.Columns.Add(quantity);
            dataGridView1.Columns.Add(costPrice);
            dataGridView1.Columns.Add(sellPrice);
        }

        // сформировать текст сета по выбранным записям
        private void button1_Click(object sender, EventArgs e)
        {
            //ругаемся, если не задали имя сета
            if (string.IsNullOrEmpty(textBox1.Text.ToString())) 
            {
                MessageBox.Show("Введите название сета!!!");
                textBox1.Focus();
                return;
            }


            //List<ItemRecord> iRecToList = new List<ItemRecord>();
            List<string> setNameList = new List<string>();

            foreach(DataGridViewRow row in dataGridView1.Rows)
            {
                if (object.Equals(row.Cells[0].Value, true))
                { 
                    setNameList.Add(row.Cells[2].Value.ToString()); 
                }
                
            }

            // список собрали, формируем текст 
        
            richTextBox1.AppendText("//---------------NEXT SET---------------\n");
            richTextBox1.AppendText(String.Concat("    EntityAI ", textBox1.Text.ToString(), "(PlayerBase player)\n")); // имя текста из текстбокса
            richTextBox1.AppendText("    {\n");
            richTextBox1.AppendText("        EntityAI itemEnt;\n");
            richTextBox1.AppendText("\n");

            // сами итемы
            foreach (string str in setNameList)
            {
                richTextBox1.AppendText(String.Concat("        itemEnt = player.GetInventory().CreateInInventory(\u0022", str, "\u0022);\n"));
            }

            richTextBox1.AppendText("\n");
            richTextBox1.AppendText("        return itemEnt;\n");
            richTextBox1.AppendText("    }\n"); 


        }

        // очистить выбор
        private void button4_Click(object sender, EventArgs e)
        {

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Cells[0].Value = false; 
            }

            textBox1.Text = string.Empty;
        }

        // очистить текст
        private void button2_Click(object sender, EventArgs e)
        { 
            richTextBox1.Clear();
        }

        public static bool StringContainsValue(string str, string val)
        { 
            return str.Contains(val); 
        }

        // Поиск по Названию с позиционированием на запись
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox2.Text)) return;



            dataGridView1.ClearSelection();

            foreach (DataGridViewRow row in dataGridView1.Rows)
            { 
                // Если вводим в название и есть символы в Категории или категория пуста
                if (StringContainsValue(row.Cells[2].Value.ToString().ToUpper(), textBox2.Text.ToUpper()) &&
                    ((!String.IsNullOrEmpty(textBox3.Text) && 
                        StringContainsValue(row.Cells[1].Value.ToString().ToUpper(), textBox3.Text.ToUpper())) || 
                    String.IsNullOrEmpty(textBox3.Text))
                    ) 
                {
                    row.Selected = true;
                    dataGridView1.CurrentCell = row.Cells[2];
                    return;
                }
            }


        }

        // Поиск по категории
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox3.Text)) return;


            dataGridView1.ClearSelection();

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (StringContainsValue(row.Cells[1].Value.ToString().ToUpper(), textBox3.Text.ToUpper()) &&
                    ((!String.IsNullOrEmpty(textBox2.Text) && 
                        StringContainsValue(row.Cells[2].Value.ToString().ToUpper(), textBox2.Text.ToUpper())) || 
                    String.IsNullOrEmpty(textBox2.Text))
                    )
                {
                    row.Selected = true;
                    dataGridView1.CurrentCell = row.Cells[1];
                    return;
                }
            }

        }
    }
}
