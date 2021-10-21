using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NSubstitute;
using Shouldly;
using SimpleWebAppMVC.Controllers;
using SimpleWebAppMVC.Data;
using SimpleWebAppMVC.Models;
using System;
using System.Collections.Generic;
using Xunit;

namespace SimpleWebAppMVC.Test
{
    public class HomeControllerTests
    {
        protected DbContextOptions<AppDbContext> Options;

        public HomeControllerTests() => Options = new DbContextOptionsBuilder<AppDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

        [Fact]
        public void SocialMedia_WithInputFour_ShouldReturnFourSocialMediaPosts()
        {
             int feedCount = 4;

            var configuration = Substitute.For<IConfiguration>();

            var socialService = Substitute.For<ISocialService>();
            socialService.GetSocialData().ReturnsForAnyArgs(new List<SocialData>() {
                new SocialData(), new SocialData(), new SocialData(), new SocialData(), new SocialData()
            });

            var sut = new HomeController(socialService, configuration);
            var result = sut.SocialMedia(feedCount) as ViewResult;

            var socialFeed = result.ViewData["social-data"] as List<SocialData>;
            socialFeed.Count.ShouldBe(feedCount);
        }

        private static void SetupContext(AppDbContext context)
        {
            context.Tasks.Add(new Models.Task { Id = "1", Date = new DateTime(1970, 1, 1), Description = "Task description", Title = "Task title here", Status = "N/A" });
            context.Tasks.Add(new Models.Task { Id = "2", Date = new DateTime(1970, 1, 10), Description = "Second task description", Title = "Second rask title here", Status = "Started" });
            context.SaveChanges();
        }
    }
}
