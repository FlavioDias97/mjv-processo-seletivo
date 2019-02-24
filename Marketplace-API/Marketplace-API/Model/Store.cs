using MarketplaceAPI.Model.Base;
using System.Runtime.Serialization;

namespace MarketplaceAPI.Model
{
    [DataContract]
    public class Store : BaseEntity
    {
        [DataMember(Order = 2, Name = "Nome Fantasia")]
        public string FantasyName { get; set; }

        [DataMember(Order = 3, Name = "CNPJ")]
        public string Cnpj { get; set; }

        [DataMember(Order = 4, Name = "Razão Social")]
        public string CorporateName { get; set; }

        [DataMember(Order = 5, Name = "Endereço Completo")]
        public string Address { get; set; }

        [DataMember(Order = 6, Name = "Telefone do Responsável")]
        public string Phone { get; set; }

        [DataMember(Order = 7, Name = "Nome do Responsável")]
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
