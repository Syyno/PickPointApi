using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PickPointAPI.Util
{
    public class ApiRoutes
    {
        public const string Root = "api";
        public const string Version = "v1";
        public const string Base = Root + "/" + Version;

        public static class Orders
        {
            public const string GetAll = Base + "/orders";
            public const string Create = Base + "/orders";
            public const string Get = Base + "/orders/{orderId}";
            public const string Update = Base + "/orders/{orderId}";
            public const string Delete = Base + "/orders/{orderId}";
        }

        public static class Postamats
        {
            public const string GetAll = Base + "/postamats";
            public const string Get = Base + "/postamats/{postamatId}";
        }
    }
}
