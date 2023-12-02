using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Store.Entitis;
using Store.Models;

namespace Store.API
{
    [Route("api/ShoppingCart")]
    [ApiController]
    public class ShoppingCartApiService : ControllerBase
    {
        private readonly StoreDbContext context;

        public ShoppingCartApiService(StoreDbContext context)
        {
            this.context = context;
        }
        [HttpGet("GetAllCart")]
        public List<GetAllShoppingCartOutput> GetAllCart()
        {
            var data = context.ShoppingCart.Select(S => new GetAllShoppingCartOutput()
            {   
                Id = S.Id,
                CreateDate = S.CreateDate,
                PeymentState = S.PeymentState,
                PeymentMethod=S.PeymentMethod,
                Count=S.Count,
                FixedPrice=S.FixedPrice,
                IsActive=S.IsActive
            }).ToList();
            return data;
        }
        [HttpPost("AddShoppingCart")]
        public void AddShoppingCart(AddShoppingCartInput input)
        {
            context.ShoppingCart.Add(new ShoppingCart()
            {
                //to do bahare
                // ورودی state درست شود
                CreateDate = DateTime.Now,
                PeymentState ="1",
                PeymentMethod = input.PeymentMethod,
                Count = input.Count,
                FixedPrice = input.FixedPrice,
				IsActive = input.IsActive
			});
            context.SaveChanges();
        }
        [HttpPost("UpdateShoppingCart")]
        public string UpdateShoppingCart(UpdateShoppingCartInput input)
        {
            //to do hame
            //بعدا تحلیل شود

            var ShoppingCart = context.ShoppingCart.Where(S => S.Id ==input.id).FirstOrDefault();
            if (!string.IsNullOrEmpty(input.PeymentState))
            {
                ShoppingCart.PeymentState = input.PeymentState;
            }
            else
            {
                ShoppingCart.PeymentState=input.PeymentState;
            }
            if (!string.IsNullOrEmpty(input.PeymentMethod))
            {
                ShoppingCart.PeymentMethod=input.PeymentMethod;
            }
            else
            {
                ShoppingCart.PeymentMethod = input.PeymentMethod;
            }
            if (input.FixedPrice > 0)
            {
                ShoppingCart.FixedPrice = input.FixedPrice;
            }
            else
            {
                ShoppingCart.FixedPrice=0;
            }
            if (input.Count > 0)
            {
                ShoppingCart.Count = input.Count;
            }
            else {
                ShoppingCart.Count=0;
            }
            context.SaveChanges();
            return "سبد خرید کاربر بروزرسانی شد";
        }
        [HttpPost("Delete")]
		public string Delete(DeleteShoppingCart input)
		{
			if (input.id == 0)
			{
				throw new Exception("");
			}
			else
			{
				var ShoppingCart = context.ShoppingCart.Where(S => S.Id == input.id).FirstOrDefault();
				if (ShoppingCart == null)
				{
					throw new Exception("");
				}
				else
				{
					ShoppingCart.IsActive = 0;
					context.SaveChanges();
					return "محصول با موفقیت غیر فعال شد";
				}
			}
		}
        [HttpPost("DeleteCart")]
		public string DeleteCart(DeleteShoppingCart input)
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
