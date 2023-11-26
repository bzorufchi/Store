using Store.Entitis;
using Store.Models;

namespace Store.API
{
    public class StatesApiService
    {
        private readonly StoreDbContext context;

        public StatesApiService(StoreDbContext context)
        {
            this.context = context;
        }
        public List<GetAllStatesOutput> GetAllStates()
        {
            var data = context.States.Select(S => new GetAllStatesOutput()
            {
                StateName = S.StateName,
                CreateDate = S.CreateDate,
             
            }).ToList();
            return data;
        }
        public void AddStates(AddStatesInput input)
        {
            context.States.Add(new States()
            {

                StateName = input.StateName,
                CreateDate = input.CreateDate,
              
            });
            context.SaveChanges();
        }
        public string UpdateStates(UpdateStatesInput input)
        {
            var States = context.States.Where(S => S.Id == input.Id).FirstOrDefault();
            States.StateName = input.StateName;
            States.CreateDate = input.CreateDate;
            context.SaveChanges();
            return "وضعیت کاربر بروزرسانی شد";
        }

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
