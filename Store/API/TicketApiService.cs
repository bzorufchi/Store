using Microsoft.AspNetCore.Mvc;
using Store.Entitis;
using Store.Models;

namespace Store.API
{
    [Route("api/Ticket")]
    [ApiController]
    public class TicketApiService : ControllerBase
    {
        private readonly StoreDbContext context;

        public TicketApiService(StoreDbContext context)
        {
            this.context = context;
        }
        [HttpPost("addTicket")]
        public bool addTicket(addTicketInput input)
        {
            try
            {
                context.Ticket.Add(new Ticket()
                {
                    Email = input.Email,
                    IsFavorite=input.IsFavorite,
                    CreateDate = DateTime.Now
                });
                context.SaveChanges();
                return true;
            }
            catch {
                return false;
            }
        }
    }
}
