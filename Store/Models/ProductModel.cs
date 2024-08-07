﻿namespace Store.Models
{
    public class GetAllProductOutput
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
        public int IsActive { get; set; }
        public int Count { get; set; }
        public int Like { get; set; }
        public float discountpercent { get; set; }
        public DateTime CreationDate { get; set; }
    }
    public class AddProductInput
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string ImageURL { get; set; }
        public int OrginalPrice { get; set; }
        public int DiscountPrice { get; set; }
        public int IsActive { get; set; }
        public int Count { get; set; }
        public int Like { get; set; }
        public float discountpercent { get; set; }
        public DateTime CreationDate { get; set; }
        public int BrandId { get; set; }
        public int CountryId { get; set; }
        public int CategoryId { get; set; }
    }
    public class UpdateProductInput
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
        public int IsActive { get; set; }
        public int Count { get; set; }
        public int Like { get; set; }
        public float discountpercent { get; set; }
        public DateTime CreationDate { get; set; }
    }
    public class DeleteProduct
    {
        public int Id { get; set; }
    }
    public class GetLastProductsOutput
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int Count { get; set; }
        public int OrginalPrice { get; set; }
        public int DiscountPrice { get; set;}
        public string ImageURL { get; set; }

    }
    public class GetMaxProductLikeOutput
    {
        public int Id { get; set; }
        public int Like { get; set; }
        public string ProductName { get; set; }
        public string ImageURL { get; set; }
        public int Count { get; set; }
        public int OrginalPrice { get; set; }
        public int DiscountPrice { get; set; }
    }

    public class  GetShowAllProductsOutput
    {
       
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ImageURL { get; set; }
        public int Count { get; set; }
        public int OrginalPrice { get; set; }
        
        public string ProductDescription { get; set; }
    
    }
    public class GetShowSingleProducts
    {
        public int Id { get; set; }
        public string BrandName { get; set; }
        public string CountryName{ get; set; }
        public string CategoryName { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string ImageURL { get; set; }
        public int OrginalPrice { get; set; }
        public int DiscountPrice { get; set; }
        public int IsActive { get; set; }
        public int Count { get; set; }
        public int Like { get; set; }
       
    }
    public class InsertProduct
    {
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string ImageURL { get; set; }
        public int OrginalPrice { get; set; }
        public int DiscountPrice { get; set; }
        public int IsActive { get; set; }
        public int Count { get; set; }
      //  public int Like { get; set; }
       // public float discountpercent { get; set; }
       // public DateTime CreationDate { get; set; }
        public int BrandId { get; set; }
        public int CountryId { get; set; }
        public int CategoryId { get; set; }
    }

    public class GetAllCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }    

    }

    public class GetAllCountry
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }

    public class GetAllBrands
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }
}
