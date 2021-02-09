

namespace CrtSetList.MyClasses
{
    public class ItemRecord
    {
        public string category;     // 1 категория
        public string name;         // 2 название итема
        public string quantity;     // 3 quantity
        public int costPrice;       // 4 цена покупки
        public int sellPrice;       // 5 цена продажи
        public string description;  // 6 описание


        public ItemRecord() { }

        public ItemRecord(string _category, string _name, string _quantity, int _costPrice, int _sellPrice, string _description) {

            category    = _category;
            name        = _name;
            quantity    = _quantity;
            costPrice   = _costPrice;
            sellPrice   = _sellPrice;
            description = _description;
        
        }

        public string Category
        {
            get { return category;}
            set { category = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }


        public string Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }


        public int CostPrice
        {
            get { return costPrice; }
            set { costPrice = value; }
        }

        public int SellPrice
        {
            get { return sellPrice; }
            set { sellPrice = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

    }



}
