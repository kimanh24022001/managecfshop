using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageCoffeeShop.Models
{
    public class Bill
    {
        private int id;
        private DateTime dateCheckIn;
        private DateTime? dateCheckOut;
        private string idTable;
        private int totalPrice;

        public int Id { get => id; set => id = value; }
        public DateTime DateCheckIn { get => dateCheckIn; set => dateCheckIn = value; }
        public DateTime? DateCheckOut { get => dateCheckOut; set => dateCheckOut = value; }
        public string IdTable { get => idTable; set => idTable = value; }
        public int TotalPrice { get => totalPrice; set => totalPrice = value; }
    }
}
