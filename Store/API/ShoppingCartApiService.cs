using Microsoft.IdentityModel.Tokens;
using Store.Entitis;
using Store.Models;

namespace Store.API
{
    public class ShoppingCartApiService
    {
        private readonly StoreDbContext context;

        public ShoppingCartApiService(StoreDbContext context)
        {
            this.context = context;
        }
        public List<GetAllShoppingCartOutput> GetAllRole()
        {
            var data = context.ShoppingCart.Select(S => new GetAllShoppingCartOutput()
            {
                CreateDate = S.CreateDate,
                PeymentState = S.PeymentState,
                PeymentMethod=S.PeymentMethod,
                Count=S.Count,
                FixedPrice=S.FixedPrice,
            }).ToList();
            return data;
        }
        public void AddShoppingCart(AddShoppingCartInput input)
        {
            context.ShoppingCart.Add(new ShoppingCart()
            {
                CreateDate = DateTime.Now,
                PeymentState = input.PeymentState,
                PeymentMethod = input.PeymentMethod,
                Count = input.Count,
                FixedPrice = input.FixedPrice,
            });
            context.SaveChanges();
        }
        public string UpdateShoppingCart(UpdateShoppingCartInput input)
        {

            var ShoppingCart = context.ShoppingCart.Where(S => S.Id ==input.id).FirstOrDefault();
            if (!string.IsNullOrEmpty(input.PeymentState))
            {
                ShoppingCart!.PeymentState = input.PeymentState;
            }
            else
            {
                ShoppingCart!.PeymentState=input.PeymentState;
            }
            if (!string.IsNullOrEmpty(input.PeymentMethod))
            {
                ShoppingCart!.PeymentMethod=input.PeymentMethod;
            }
            else
            {
                ShoppingCart!.PeymentMethod = input.PeymentMethod;
            }
            if (input.FixedPrice > 0)
            {
                ShoppingCart!.FixedPrice = input.FixedPrice;
            }
            else
            {
                ShoppingCart!.FixedPrice=0;
            }
            if (input.Count > 0)
            {
                ShoppingCart!.Count = input.Count;
            }
            else {
                ShoppingCart!.Count=0;
            }
            context.SaveChanges();
            return "سبد خرید کاربر بروزرسانی شد";
        }

        public string DeleteRole(DeleteShoppingCart input)
        {
            if (input.id == 0)
            {
                throw new Exception("ورودی شما اشتباه است");
            }
            else
            {
                var ShoppingCart = context.ShoppingCart.Where(S => S.Id == input.id).FirstOrDefault();
                if (input == null)
                {
                    throw new Exception("محصولی با این مشخصات یافت نشد");
                }
                else
                {
                    context.ShoppingCart.Remove(ShoppingCart);
                    context.SaveChanges();
                    return "سبد خرید کاربر حذف شد";
                }
            }
           
            
        }
    }
}
