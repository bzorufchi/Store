﻿using Store.Entitis;

namespace Store.Models
{
    public class GetAllOrdersOutput
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public int?  count { get; set; }
        public int? FixedPrice { get; set; }
        public int? otal_price_of_discounts { get; set; }
        public int? Original_price_payable { get; set; }
        public int IsActive { get; set; }



    }
    public class AddOrdersInput
    {
        public DateTime CreateDate { get; set; }
        public int count { get; set; }
        public int FixedPrice { get; set; }
        public int otal_price_of_discounts { get; set; }
        public int Original_price_payable { get; set; }
        public int IsActive { get; set; }
    }
    public class UpdateOrdersInput
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int StateId { get; set; }
        public int ShoppingCartId { get; set; }
        public DateTime CreateDate { get; set; }
        public int count { get; set; }
        public int FixedPrice { get; set; }
        public int otal_price_of_discounts { get; set; }
        public int Original_price_payable { get; set; }
        public int IsActive { get; set; }

    }
    public class DeleteOrders
    {
        public int Id { get; set; }
    }

    public class InsertShoppingCart
    {

        public int ProductId { get; set; }
        public int UserId { get; set; }

    }

    public class GetShoppingCard
    {
        public int OrderId { get; set; }
        public string ProductName { get; set; }
        public int count { get; set; }
        public int FixedPrice { get; set; }
    }
    public class UpdateCountModel
    {
        public int OrderId { get; set; }
        public int Number { get; set; }
    }
}