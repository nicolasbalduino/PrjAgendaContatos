using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrjAgendaContatos
{
    internal class Address
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }

        public Address()
        {
            
        }

        public void EditStreet(string s)
        {
            this.Street = s;
        }
        public void EditCity(string c)
        {
            this.City = c;
        }
        public void EditState(string s)
        {
            this.State = s;
        }
        public void EditPostalCode(string p)
        {
            this.PostalCode = p;
        }
        public void EditCountry(string c)
        {
            this.Country = c;
        }

        public override string ToString()
        {
            return "Endereço: " +
                    "\n  Logradouro: " + Street +
                    "\n      Cidade: " + City + 
                    "\n      Estado: " + State + 
                    "\n         CEP: " + PostalCode +
                    "\n        País: " + Country + "\n\n";
        }
    }
}
