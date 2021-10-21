using Microsoft.Extensions.DependencyInjection;
using SimpleWebAppMVC.Data;
using System;
using System.Net.Http;
using Xunit;

namespace SimpleWebAppMVC.Test.Setup
{
    [Collection("Setup Integrationtests")]
    public class TestFixture : IClassFixture<CustomWebApplicationFactory>
    {
        protected readonly HttpClient Client;  
        protected readonly AppDbContext Context;
        protected readonly IServiceProvider ServiceProvider;

        public TestFixture(CustomWebApplicationFactory factory)
        {
            factory.Server.PreserveExecutionContext = true;
            Client = factory.CreateClient();           
            ServiceProvider = factory.Services.CreateScope().ServiceProvider;
            Context = ServiceProvider.GetRequiredService<AppDbContext>();
        }
    }

    [CollectionDefinition("Setup Integrationtests")]
    public class TestFixtureCollection : ICollectionFixture<object>
    {
    }
}