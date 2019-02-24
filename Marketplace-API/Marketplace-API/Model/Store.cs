using MarketplaceAPI.Model.Base;

namespace MarketplaceAPI.Model
{
    public class Store : BaseEntity
    {

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
