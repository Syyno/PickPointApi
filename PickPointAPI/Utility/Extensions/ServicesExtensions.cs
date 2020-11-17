using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using PickPointAPI.Services;
using PickPointAPI.Util;

namespace PickPointAPI.Extensions
{
    public static class ServicesExtensions
    {
        public static void AddData(this IServiceCollection services)
        {
            services.AddSingleton<OrdersStorage>();
            services.AddSingleton<PostamatsStorage>();
            services.AddScoped<IOrderOperations, OrderOperations>();
            services.AddScoped<IPostamatOperations, PostamatOperations>();
            services.AddScoped<DataManager>();
        }
    }
}
