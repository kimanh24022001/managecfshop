using System.Data;

namespace ManageCoffeeShop.Models
{
    public class SelectMenu
    {
        private int id;
        private string nameFood;
        private int countFood;
        private float priceFood;
        private string category;
        private string uploadFile;
        private int addToCart;

        public int Id { get => id; set => id = value; }
        public string NameFood { get => nameFood; set => nameFood = value; }
        public int CountFood { get => countFood; set => countFood = value; }
        public float PriceFood { get => priceFood; set => priceFood = value; }
        public string Category { get => category; set => category = value; }
        public string UploadFile { get => uploadFile; set => uploadFile = value; }
        public int AddToCart { get => addToCart; set => addToCart = value; }
    }
}
