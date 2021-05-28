using System;
using System.Collections.Generic;
using System.Text;

namespace WinFormsApp1
{
    public class Account
    {
        int id;
        string name;
        string phone;
        string email;
        string password;
        int membership;

        public Account(int id, string name, string phone, string email, string password, int membership)
        {
            this.Id = id;
            this.Name = name;
            this.Phone = phone;
            this.Email = email;
            this.Password = password;
            this.Membership = membership;
        }

        public Account()
        {
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }
        public int Membership { get => membership; set => membership = value; }
    }
}
