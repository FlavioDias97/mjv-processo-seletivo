using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;


namespace MarketplaceAPI.Model.Base
{
    [DataContract]
    public class BaseEntity
    {
        [Key]
        [DataMember(Order = 1, Name = "Código")]
        public long? Id { get; set; }

        [DataMember(Order = 2, Name = "Nome")]
        public string Name { get; set; }
    }
}