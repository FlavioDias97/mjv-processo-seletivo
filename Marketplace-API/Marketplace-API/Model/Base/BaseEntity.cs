using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;


namespace MarketplaceAPI.Model.Base
{
    //[DataContract]
    public class BaseEntity
    {
        [Key]
        public long? Id { get; set; }
    }
}
