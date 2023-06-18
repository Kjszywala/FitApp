using FitApp.Services;
using FitAppApi;
using System.Linq;

namespace FitApp.BusinessLogic
{
    public class CalculateBmi
    {
        #region Methods

        public static double? CalculateBmiMethod(double? weightEntry, double? heightEntry)
        {
            return weightEntry / (heightEntry * heightEntry) * 10000;
        }

        public static double? GetYourBmi(int i)
        {
            var userModelService = new UserModelService();
            var users = userModelService.GetItemsAsync().Result;
            var user = new Users();
            foreach (var item in users)
            {
                if (item.UserID == i)
                    user = item;
            }
            var height = user.Height;
            var weight = user.Weight;
            return CalculateBmi.CalculateBmiMethod(weight, height);
        }

        #endregion
    }
}
