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
            var States = context.States.Where(S => S.Id == input.Id).FirstOrDefault();
            context.States.Remove(States);
            context.SaveChanges();
            return "وضعیت کاربر حذف شد";
        }
    }
}
