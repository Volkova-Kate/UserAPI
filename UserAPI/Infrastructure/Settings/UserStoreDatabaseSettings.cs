using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserAPI.Infrastructure.Settings
{
    public class UserStoreDatabaseSettings: IUserStoreDatabaseSettings
    //используется для хранения значений свойств UserstoreDatabaseSettings файла appsettings.json
    {
        public string UsersCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
