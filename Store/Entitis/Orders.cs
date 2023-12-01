﻿namespace Store.Entitis
{
    public class Orders
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
		public ShoppingCart ShoppingCart { get; set; }

        public ICollection<States> states { get; set; }
         public ICollection<Product> products { get; set; }
    }
}
