using FitApp.Helpers;
using FitApp.Services.Abstract;
using FitAppApi;
using System.Linq;
using System.Threading.Tasks;

namespace FitApp.Services
{
    public class UserModelService : AListDataStore<Users>
    {
        public UserModelService() :
            base()
        {
        }

        public override async Task<Users> AddItemToService(Users item)
        {
            return await _service.UsersPOSTAsync(item);
        }

        public override async Task<bool> DeleteItemFromService(Users item)
        {
            return await _service.UsersDELETEAsync(item.UserID).HandleRequest();
        }

        public override async Task<Users> Find(Users item)
        {
            return await _service.UsersGETAsync(item.UserID);
        }

        public override async Task<Users> Find(int id)
        {
            return await _service.UsersGETAsync(id);
        }

        public override async Task RefreshListFromService()
        {
            items = _service.UsersAllAsync().Result.ToList();
        }

        public override async Task<bool> UpdateItemInService(Users item)
        {
            return await _service.UsersPUTAsync(item.UserID, item).HandleRequest();
        }
    }
}
