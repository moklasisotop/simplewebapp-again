using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NSubstitute;
using Shouldly;
using SimpleWebAppMVC.Controllers;
using SimpleWebAppMVC.Data;
using SimpleWebAppMVC.Helpers;
using SimpleWebAppMVC.Models;
using SimpleWebAppMVC.Test.Setup;
using System;
using System.Collections.Generic;
using System.Net;
using Xunit;

namespace SimpleWebAppMVC.Test
{
    [AutoRollback]
    public class TasksApiControllerIntegrationTests : TestFixture
    {
        public TasksApiControllerIntegrationTests(CustomWebApplicationFactory factory) : base(factory) { }

        [Fact]
        public async void Post_WithValidInput_ShouldReturn201()
        { 
            var response = await Client.PostAsync("api/tasks", HttpContentHelper.GetJsonContent(
                new Task { Id = "05db8fae-f6ff-4958-817f-b7f8652133bb", Date = new DateTime(), Description = "MyDesc", Title = "MuchTitle", Status = "N/A" }
                ));

            response.StatusCode.ShouldBe(HttpStatusCode.Created);
        }
    }
}
