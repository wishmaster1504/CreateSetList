using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrtSetList.MyClasses;


namespace CrtSetList.MyClasses
{
    public class LoadItemList
    {

        //  ---  folder directory + filename
        private static readonly string _testDbPath = Path.Combine(Environment.CurrentDirectory, "itemlist.csv");
        protected bool filefound;

        protected BindingList<ItemRecord> fullItemList;

        // конструктор
        public LoadItemList() {

            fullItemList = new BindingList<ItemRecord>();
            filefound = false;

        }

        // загрузка данных из файла .CSV в список fullItemList
        public void LoadItemRecordList()
        {

            //загрузка из файла в fullItemList 
            string[] fileLine = null;
            string[] lines;
                
            try
             {
                lines = File.ReadAllLines(_testDbPath, System.Text.Encoding.UTF8);
                filefound = true;

            }
            catch (Exception)
            {
                MessageBox.Show(@"Файл не найден");
                filefound = false;
                return;
            }

            // заброс в список
            foreach(var line in lines)
            {
                if (!String.IsNullOrEmpty(line))
                {
                    fileLine = line.Split(';');
                    int cost = int.Parse(fileLine[3]);
                    int sell = int.Parse(fileLine[4]);

                    SetToItemRecordList(fileLine[0],
                                      fileLine[1],
                                      fileLine[2],
                                      cost,
                                      sell,
                                      fileLine[5]);
                }
                    
            }

            string tmpT = "dsd";
        }


        // добавление в список
        private void SetToItemRecordList(string _category, string _name, string _quantity, int _costPrice, int _sellPrice, string _description)
        {
            fullItemList.Add(new ItemRecord(_category, _name, _quantity, _costPrice, _sellPrice, _description));
        }

        // Полный список итемов
        public BindingList<ItemRecord> GetFullItemRecordList()
        {
            return fullItemList;
        }



        public bool FileIsFound()
        {
            return filefound;
        }
    }
}
