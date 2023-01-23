using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageCoffeeShop.Models
{
    public class BillInfor
    {
        private int id;
        private string food;
        private int price;
        private int amount;
        private string selectedNameTable;

        public int Id { get => id; set => id = value; }
        public string Food { get => food; set => food = value; }
        public int Price { get => price; set => price = value; }
        public int Amount { get => amount; set => amount = value; }
        public string SelectedNameTable { get => selectedNameTable; set => selectedNameTable = value; }

    }
}
