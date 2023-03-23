using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrjAgendaContatos
{
    internal class Contact
    {
        public string Name { get; set; }
        public Address Address { get; set; }
        public string Phone { get; set; }
        public string? Email { get; set; }

        public Contact(string n, string p, string e)
        {
            this.Name = n;
            this.Address = new Address();
            this.Phone = p;
            this.Email = e;
        }

        public void EditPhone(string p)
        {
            this.Phone = p;
        }
        public void EditEmail(string e)
        {
            this.Email = e;
        }

        public override string ToString()
        {
            return  $"    Nome: {Name}\n" +
                    $"Telefone: {Phone}\n" +
                    $"  E-mail: {Email}\n" +
                    $"{Address}";
        }

        public string ToBackup()
        {
            return $"{Name}|{Phone}|{Email}|{Address.ToBackup()}";
        }
    }
}
