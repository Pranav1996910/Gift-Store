using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorizontalList
{
  public class Product
    {
    public int ID { get; set; }
    public string Name { get; set; }
    public double Value { get; set; }
    public string ImagePath { get; set; }
    public string Description { get; set; }
    public int ItemsLeft { get; set; }
    public string GiftFor { get; set; }
    public string Ocassion { get; set; }

        //public Product(int id, string name, double value, string imagePath, string description, int itemsLeft)
        //{
        //    ID = id;
        //    Name = name;
        //    Value = value;
        //    ImagePath = imagePath;
        //    Description = description;
        //    ItemsLeft = itemsLeft;
        //}
    }
    public class AddedProduct
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public double Value { get; set; }
        public string Image { get; set; }
        public int SelectedItemCount { get; set; }
        public List<int> ItemCountList { get; set; }
        public int ItemsLeft { get; set; }

        public AddedProduct(int id, string name, double value, string image,  int itemsLeft)
        {
            ID = id;
            Name = name;
            Value = value;
            Image = image;
            ItemsLeft = itemsLeft;
            ItemCountList = new List<int>();
            if (itemsLeft > 10)
            {
                for (int i = 1; i <= 10; i++)
                {
                    ItemCountList.Add(i);
                }
                SelectedItemCount = 1;
            }
            else
            {
                for (int i = 1; i <= itemsLeft; i++)
                {
                    ItemCountList.Add(i);
                }
                SelectedItemCount = 1;
            }
        }
    }

}
