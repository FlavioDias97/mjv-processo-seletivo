using MarketplaceAPI.Model.Base;
using System.Runtime.Serialization;

namespace MarketplaceAPI.Model
{
    [DataContract]
    public class Product : BaseEntity
    {
        //[DataMember(Order = 2, Name = "Nome do Produto")]
        //public string ProductName { get; set; }

        [DataMember(Order = 3, Name = " Descrição")]
        public string Description { get; set; }

        [DataMember(Order = 4, Name = "Categoria")]
        public string Category { get; set; }

        [DataMember(Order = 5, Name = "Imagem")]
        public string Image { get; set; }

        [DataMember(Order = 6, Name = "Preço")]
        public int Price { get; set; }

        [DataMember(Order = 7, Name = "Quantidade em estoque")]
        public int Quantity { get; set; }

        [DataMember(Order = 8, Name = "Id da loja")]
        public int store_id { get; set; }



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
