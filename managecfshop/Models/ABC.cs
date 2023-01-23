using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coffeeShop.Models
{
    public class ABC
    {
        private int id;
        private string userName;
        private string status;
        private DateTime time;
        public int Id { get => id; set => id = value; }
        public string UserName { get => userName; set => userName = value; }
        public string Status { get => status; set => status = value; }
        public DateTime Time { get => time; set => time = value; }


    }
}
