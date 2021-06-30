using System;
using System.Collections.Generic;
using System.Text;

namespace convert
{
    class Movie
    {
        int ID;
        string name;
        int price;
        string synopsys;
        string image;
        string seat;
        DateTime date;

        public Movie()
        {
        }

        public Movie(int iD, string name, int price, string synopsys, string image, string seat, DateTime date)
        {
            ID = iD;
            this.name = name;
            this.price = price;
            this.synopsys = synopsys;
            this.image = image;
            this.seat = seat;
            this.date = date;
        }

        public int ID1 { get => ID; set => ID = value; }
        public string Name { get => name; set => name = value; }
        public int Price { get => price; set => price = value; }
        public string Synopsys { get => synopsys; set => synopsys = value; }
        public string Image { get => image; set => image = value; }
        public string Seat { get => seat; set => seat = value; }
        public DateTime Date { get => date; set => date = value; }
    }
}

