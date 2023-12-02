using Microsoft.AspNetCore.Mvc;
using Store.Entitis;
using Store.Models;

namespace Store.API
{
    [Route("api/States")]
    [ApiController]
    public class StatesApiService : ControllerBase
    {
        private readonly StoreDbContext context;

        public StatesApiService(StoreDbContext context)
        {
            this.context = context;
        }
        [HttpGet("GetAllStates")]
        public List<GetAllStatesOutput> GetAllStates()
        {
            var data = context.States.Select(S => new GetAllStatesOutput()
            {
                Id = S.Id,
                StateName = S.StateName,
                CreateDate = S.CreateDate,
				IsActive = S.IsActive

			}).ToList();
            return data;
        }
        [HttpPost("AddStates")]
        public bool AddStates(AddStatesInput input)
        {
            // برای گرفتن زمان حال حاضر
            try
            {
				input.CreateDate = DateTime.Now;

				context.States.Add(new States()
				{

					StateName = input.StateName,
					CreateDate = input.CreateDate,
					IsActive = input.IsActive
				});
				context.SaveChanges();
                return true;
			}
            catch (Exception)
            {
                return false;
            }
        }
        [HttpPost("UpdateStates")]
        public bool UpdateStates(UpdateStatesInput input)
        {
            try
            {
				var States = context.States.Where(S => S.Id == input.Id).FirstOrDefault();
				if (!string.IsNullOrEmpty(input.StateName))
				{
					States.StateName = input.StateName;

				}
				else
				{
					States.StateName = States.StateName;
				}
				context.SaveChanges();
				return true;
			}
            catch (Exception)
            {
                return false;   
            }
			}
        [HttpPost("Delete")]
		public string Delete(DeleteStatesInput input)
		{
			if (input.Id == 0)
			{
				throw new Exception("");
			}
			else
			{
				var State = context.States.Where(S => S.Id == input.Id).FirstOrDefault();
				if (State == null)
				{
					throw new Exception("");
				}
				else
				{
					State.IsActive = 0;
					context.SaveChanges();
					return "محصول با موفقیت غیر فعال شد";
				}
			}
		}
        [HttpPost("DeleteُState")]
		public string DeleteُState(DeleteStatesInput input)
        {
            if (input.Id == 0) {
                throw new Exception("ورودی شما اشتباه است");
            }
            else
            {
                var State = context.States.Where(S => S.Id == input.Id).FirstOrDefault();
                if (State == null)
                {
                    throw new Exception("  کامنتی با این مشخصات یافت نشد");
                }
                else
                {
                    context.States.Remove(State);
                    context.SaveChanges();
                    return "وضعیت کاربر حذف شد";
                }
            }
           
           
        }
    }
}
