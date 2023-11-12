﻿namespace Store.Entitis
{
    public class Product
    {
        public int Id { get; set; }
        public int BrandId { get; set; }
        public int CountryId { get; set; }
        public int CategoryId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string ImageURL { get; set; }
        public int OrginalPrice { get; set; }
        public int DiscountPrice { get; set; }
        public int IsActive { get; set;}
        public int Count { get; set;}
        public int Like { get; set; }
        public float discountpercent { get; set;}
        public DateTime CreationDate { get; set;}

        public Orders Orders { get; set; }
        public Brands Brands { get; set; }
        public ICollection<Comments> Comments { get; set; }

        public Category Category { get; set; }
        public Country Country { get; set; }
        
    }
}
