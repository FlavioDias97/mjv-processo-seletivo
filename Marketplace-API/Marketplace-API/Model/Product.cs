﻿using System.ComponentModel.DataAnnotations;


namespace MarketplaceAPI.Model
{
    public class Product{

        [Key]
        public long? Id { get; set; }

        public string ProductName { get; set; }

        public string Description { get; set; }

        public string Category { get; set; }

        public string Image { get; set; }

        public int Price { get; set; }

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