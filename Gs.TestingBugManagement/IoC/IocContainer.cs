using Gs.TestingBugManagement.Models;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Gs.TestingBugManagement.IOC
{
    public static class IoC
    {
        //public static AppDbContext AppDbContext => IocContainer.Provider.GetRequiredService<AppDbContext>();
        public static AppDbContext AppDbContext { get; set; }
    }

    public static class IocContainer
    {
        public static IServiceProvider Provider { get; set; }
    }
}
