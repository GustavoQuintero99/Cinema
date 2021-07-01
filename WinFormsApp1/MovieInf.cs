using System;
using System.Collections.Generic;
using System.Text;

namespace WinFormsApp1
{
    class MovieInf
    {


        int ID;
        string name;
        string synopsys;
        string image;

        public MovieInf()
        {
        }

        public MovieInf(int iD, string name, string synopsys, string image)
        {
            ID = iD;
            this.name = name;
            this.synopsys = synopsys;
            this.image = image;
        }

        public int ID1 { get => ID; set => ID = value; }
        public string Name { get => name; set => name = value; }
        public string Synopsys { get => synopsys; set => synopsys = value; }
        public string Image { get => image; set => image = value; }
    }
}
