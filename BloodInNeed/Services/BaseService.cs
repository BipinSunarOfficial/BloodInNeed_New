
using BloodInNeed.UI.DBCtx;
using BloodInNeed.UI.Models;

namespace BloodInNeed.UI.Services
{
    public class BaseService
    {
        private readonly BaseDBCtx _baseDBCtx;

        public BaseService(BaseDBCtx baseDBCtx) 
        {
            _baseDBCtx = baseDBCtx ?? throw new ArgumentNullException(nameof(baseDBCtx));
        }

        public IEnumerable<AutoComplete> AutoCompleteGet(string SearchValue, string SearchType)
        {
            var data = _baseDBCtx.AutoCompleteGet(SearchValue, SearchType);
            return data;
        }

    }
}
