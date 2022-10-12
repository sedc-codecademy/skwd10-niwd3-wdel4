using SEDC.Lamazon.Services.Interfaces;
using System;

namespace SEDC.Lamazon.Services.Implementations
{
    public class LocalizationService : BaseService, ILocalizationService
    {
        public string LocalizeString(string value)
        {
            if(value.Equals("food", StringComparison.InvariantCultureIgnoreCase))
            {
                return "Храна";
            }
            else
            {
                return value;
            }
        }
    }
}
