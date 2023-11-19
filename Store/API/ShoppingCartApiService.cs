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
            ShoppingCart.PeymentState = input.PeymentState;
            ShoppingCart.PeymentMethod=input.PeymentMethod;
            ShoppingCart.Count = input.Count;
            ShoppingCart.FixedPrice=input.FixedPrice;

            context.SaveChanges();
            return "سبد خرید کاربر بروزرسانی شد";
        }

        public string DeleteRole(DeleteShoppingCart input)
        {
            var ShoppingCart = context.ShoppingCart.Where(S => S.Id ==input.id).FirstOrDefault();
            context.ShoppingCart.Remove(ShoppingCart);
            context.SaveChanges();
            return "سبد خرید کاربر حذف شد";
        }
    }
}
