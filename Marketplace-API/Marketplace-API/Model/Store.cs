using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MarketplaceAPI.Model
{
    public class Store{
        //public Store(long id, string fantasyName, string cnpj, string corporateName, string address, string phone, string responsible)
        //{
        //    Id = id;
        //    FantasyName = fantasyName;
        //    Cnpj = cnpj;
        //    CorporateName = corporateName;
        //    Address = address;
        //    Phone = phone;
        //    Responsible = responsible;
        //}

        [Key]
        public long? Id { get; set; }

        public string FantasyName { get; set; }

        public string Cnpj { get; set; }

        public string CorporateName { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public string Responsible { get; set; }



        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
