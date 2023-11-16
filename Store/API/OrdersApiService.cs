using Store.Entitis;
using Store.Models;

namespace Store.API
{
    public class OrdersApiService
    {
        private readonly StoreDbContext context;

        public OrdersApiService(StoreDbContext context)
        {
            this.context = context;
        }
        public List<GetAllOrdersOutput> GetAllOrders()
        {
            var data = context.Orders.Select(o => new GetAllOrdersOutput()
            {
                CreateDate = o.CreateDate,
                count = o.count,
                FixedPrice=o.FixedPrice,
                otal_price_of_discounts=o.otal_price_of_discounts,
                Original_price_payable = o.Original_price_payable,
              

            }).ToList();
            return data;
        }
        public void AddOrders(AddOrdersInput input)
        {
            context.Orders.Add(new Orders()
            {

                CreateDate = input.CreateDate,
                count = input.count,
                FixedPrice=input.FixedPrice,
                otal_price_of_discounts=input.otal_price_of_discounts,
                Original_price_payable = input.Original_price_payable
            });
            context.SaveChanges();
        }
        public string UpdateOrders(UpdateOrdersInput input)
        {

            var Orders = context.Orders.Where(o => o.Id == input.Id).FirstOrDefault();
            Orders.CreateDate = input.CreateDate;
            Orders.count = input.count;
            Orders.FixedPrice = input.FixedPrice;
            Orders.otal_price_of_discounts = input.otal_price_of_discounts;
            Orders.Original_price_payable = input.Original_price_payable;
            Orders.ShoppingCartId=input.ShoppingCartId;
            Orders.Id = input.Id;
            Orders.StateId = input.StateId;
            Orders.ProductId = input.ProductId;
            context.SaveChanges();
            return "نقش کاربر بروزرسانی شد";
        }

        public string DeleteOrders(DeleteOrders input)
        {
            var Orders = context.Orders.Where(o => o.Id ==input.Id).FirstOrDefault();
            context.Orders.Remove(Orders);
            context.SaveChanges();
            return "نقش کاربر حذف شد";
        }
    }
}
