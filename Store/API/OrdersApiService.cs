using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Store.Entitis;
using Store.Models;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Eventing.Reader;

namespace Store.API
{
    [Route("api/Orders")]
    [ApiController]
    public class OrdersApiService : ControllerBase
    {
        private readonly StoreDbContext context;

        public OrdersApiService(StoreDbContext context)
        {
            this.context = context;
        }
        [HttpGet("GetAllOrders")]
        public List<GetAllOrdersOutput> GetAllOrders()
        {
            var data = context.Orders.Select(o => new GetAllOrdersOutput()
            {
                Id = o.Id,
                IsActive = o.IsActive,
                CreateDate = o.CreateDate,
                count = o.count,
                FixedPrice = o.FixedPrice,
                otal_price_of_discounts = o.otal_price_of_discounts,
                Original_price_payable = o.Original_price_payable,

            }).ToList();
            return data;
        }
        [HttpPost("AddOrders")]
        public bool AddOrders(AddOrdersInput input)
        {
            try
            {
                context.Orders.Add(new Orders()
                {
                    count = input.count,
                    FixedPrice = input.FixedPrice,
                    otal_price_of_discounts = input.otal_price_of_discounts,
                    Original_price_payable = input.Original_price_payable
                });
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        [HttpPost("UpdateOrders")]
        public bool UpdateOrders(UpdateOrdersInput input)
        {
            try
            {
                var Orders = context.Orders.Where(o => o.Id == input.Id).FirstOrDefault();
                if (input.count > 0)
                {
                    Orders.count = input.count;
                }
                else
                {
                    Orders.count = Orders.count;
                }
                if (input.FixedPrice > 0)
                {
                    Orders.FixedPrice = input.FixedPrice;
                }
                else
                {
                    Orders.FixedPrice = Orders.FixedPrice;
                }
                if (input.otal_price_of_discounts > 0)
                {
                    Orders.otal_price_of_discounts = input.otal_price_of_discounts;
                }
                else
                {
                    Orders.otal_price_of_discounts = Orders.otal_price_of_discounts;
                }
                if (input.ShoppingCartId > 0)
                {
                    Orders!.ShoppingCartId = input.ShoppingCartId;
                }
                else
                {
                    Orders.ShoppingCartId = Orders.ShoppingCartId;
                }


                //Orders.Id = input.Id;
                //Orders.StateId = input.StateId;
                //Orders.ProductId = input.ProductId;
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        [HttpPost("Delete")]
        public bool Delete(DeleteOrders input)
        {
            if (input.Id == 0)
            {
                throw new Exception("");
            }
            else
            {
                
                var Orders = context.Orders.Where(o=> o.Id == input.Id).FirstOrDefault();
                if (Orders == null)
                {
                    return false;
                }
                else
                {
                    Orders.IsActive = 0;
                    context.SaveChanges();
                    return true;
                }
            }
        }

        [HttpPost("UpdateCount")]
        public bool UpdateCount(UpdateCountModel input)
        {
            if (input.OrderId == 0)
            {
                throw new Exception("");
            }
            else
            {

                var Orders = context.Orders.Where(o => o.Id ==input.OrderId).FirstOrDefault();
                if (Orders == null)
                {
                    return false;
                }
                else
                {
                    Orders.count =Orders.count+input.Number;
                    context.SaveChanges();
                    return true;
                }
            }
        }
        [HttpPost("DeleteOrders")]
        public string DeleteOrders(DeleteOrders input)
        {
            if (input.Id == 0)
            {
                throw new Exception("ورودی شما خالی است");
            }
            else
            {
                var Orders = context.Orders.Where(o => o.Id == input.Id).FirstOrDefault();
                if (Orders == null)
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
        [HttpPost("InsertOrderToShppoingCard")]
        public bool InsertOrderToShppoingCard(InsertShoppingCart input)
        {
            try
            {
                int result = 0;
                using (SqlConnection conn = new SqlConnection("Integrated Security=true;Persist Security Info=False;Initial Catalog=store;Data Source=. ;TrustServerCertificate=True;"))
                using (SqlCommand cmd = new SqlCommand("dbo.sp_InsertShoppingCard", conn))
                {
                    conn.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@ProductId", input.ProductId));
                    cmd.Parameters.Add(new SqlParameter("@UserId", input.UserId));

                    var outPut = cmd.ExecuteScalar();

                    result = Convert.ToInt32(outPut);

                    conn.Close();

                }
                //if (result == 1)
                //{
                //    return true;
                //}
                //return false;

                return result == 1 ? true : false;

                //return result == 1;

            }
            catch (Exception)
            {
                return false;
            }
        }

        [HttpPost("GetShoppingCard/{UserId}")]
        public List<GetShoppingCard> GetShoppingCard(int UserId)
        {

            {
                List<GetShoppingCard> list = new List<GetShoppingCard>();
                using (SqlConnection conn = new SqlConnection("Integrated Security=true;Persist Security Info=False;Initial Catalog=store;Data Source=. ;TrustServerCertificate=True;"))
                using (SqlCommand cmd = new SqlCommand("dbo.sp_GetShoppingCard", conn))
                {
                    conn.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@UserId", UserId));
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        list.Add(new GetShoppingCard()
                        {
                            OrderId = Convert.ToInt32(reader["OrderId"]),
                            ProductName = (reader["ProductName"]).ToString(),
                            count = Convert.ToInt32(reader["count"]),
                            FixedPrice = Convert.ToInt32(reader["FixedPrice"])

                    }) ;
                    }
                    conn.Close();

                }
                return list;

            }
        }

    }

}
            

