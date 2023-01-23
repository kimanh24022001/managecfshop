using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ManageCoffeeShop.Model
{
    public class Category
    {
        private int id;
        private string nameCategory;
        private string uploadFile;
        public int Id { get => id; set => id = value; }
        public string NameCategory { get => nameCategory; set => nameCategory = value; }
        public string UploadFile { get => uploadFile; set => uploadFile = value; }

    }
}
