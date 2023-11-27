using Store.Entitis;
using Store.Models;
using System.Diagnostics.Eventing.Reader;

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
            if (input.count > 0)
            {
                Orders!.count = input.count;
            }
            else{
                Orders!.count = input.count;
            }
            if (input.FixedPrice > 0)
            {
                Orders!.FixedPrice = input.FixedPrice;
            }
            else
            {
                Orders!.FixedPrice = input.FixedPrice;
            }
            if (input.otal_price_of_discounts > 0)
            {
                Orders!.otal_price_of_discounts = input.otal_price_of_discounts;
            }
            else
            {
                Orders!.otal_price_of_discounts = input.otal_price_of_discounts;
            }
            if (input.ShoppingCartId > 0)
            {
                Orders!.ShoppingCartId = input.ShoppingCartId;
            }
            else
            {
                Orders!.ShoppingCartId = input.ShoppingCartId;
            }
           
          
            //Orders.Id = input.Id;
            //Orders.StateId = input.StateId;
            //Orders.ProductId = input.ProductId;
            context.SaveChanges();
            return "نقش کاربر بروزرسانی شد";
        }

        public string DeleteOrders(DeleteOrders input)
        {
            if (input.Id == 0)
            {
                throw new Exception("ورودی شما خالی است");
            }
            else
            {
                var Orders = context.Orders.Where(o => o.Id == input.Id).FirstOrDefault();
                if(Orders == null)
                {
                    throw new Exception("سفارشی با این مشخصات یافت نشد");
                }
                else
                {
                    context.Orders.Remove(Orders);
                    context.SaveChanges();
                    return "نقش کاربر حذف شد";
                }
            }
            
            
        }
    }
}
