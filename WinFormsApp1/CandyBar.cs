using System;
using System.Collections.Generic;
using System.Text;

namespace WinFormsApp1
{
    public class CandyBar
    {
        int id;
        string name;
        int price;
        string description;
        string image;

        public CandyBar()
        {
        }

        public CandyBar(int id,string name,int price,string description,string image) 
        {
            this.Id = id;
            this.Name = name;
            this.Price = price;
            this.Description = description;
            this.Image = image;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public int Price { get => price; set => price = value; }
        public string Description { get => description; set => description = value; }
        public string Image { get => image; set => image = value; }
    }
}
