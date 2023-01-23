using System.Data;

namespace ManageCoffeeShop.Models
{
    public class Table
    {
        private int id;
        private string nameTable;
        private string statusTable;
        private string uploadFile;
        private string selectedNameTable;
        public int Id { get => id; set => id = value; }
        public string NameTable { get => nameTable; set => nameTable = value; }
        public string StatusTable { get => statusTable; set => statusTable = value; }
        public string UploadFile { get => uploadFile; set => uploadFile = value; }
        public string SelectedNameTable { get => selectedNameTable; set => selectedNameTable = value; }



    }
}
