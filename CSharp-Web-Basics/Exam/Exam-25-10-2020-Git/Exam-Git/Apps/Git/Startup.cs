﻿namespace Git
{
    using System.Collections.Generic;
    using Microsoft.EntityFrameworkCore;

    using Data;
    using Services;
    using SUS.HTTP;
    using SUS.MvcFramework;

    public class Startup : IMvcApplication
    {
        public void Configure(List<Route> routeTable)
        {
            new ApplicationDbContext().Database.Migrate();
        }

        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.Add<IUsersService, UsersService>();
            serviceCollection.Add<IRepositoriesServices, RepositoriesServices>();
            serviceCollection.Add<ICommitsServices, CommitsServices>();
        }
    }
}
