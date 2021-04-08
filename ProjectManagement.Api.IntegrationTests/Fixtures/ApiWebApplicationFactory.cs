using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using ProjectManagement.Shared;

namespace ProjectManagement.Api.IntegrationTests.Fixtures
{
    public class ApiWebApplicationFactory<TStartup> : WebApplicationFactory<ProjectManagement.Api.Startup>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                var serviceProvider = new ServiceCollection().AddEntityFrameworkInMemoryDatabase().BuildServiceProvider();

                services.AddDbContext<PMContext>(options =>
                {
                    options.UseInMemoryDatabase("ProjectManagementTestData");
                });

                var objBSP = services.BuildServiceProvider();

                using (var scope = objBSP.CreateScope())
                {
                    var scopedServices = scope.ServiceProvider;
                    var db = scopedServices.GetRequiredService<PMContext>();
                    db.Database.EnsureCreated();
                    PMContext.Initialize(scopedServices);
                }
            });
        }
    }
}
