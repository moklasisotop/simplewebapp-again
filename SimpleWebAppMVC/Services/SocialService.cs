using System.Collections.Generic;

namespace SimpleWebAppMVC.Models
{
    public interface ISocialService
    {
        List<SocialData> GetSocialData();
    }

    public class SocialService : ISocialService
    {
        public List<SocialData> GetSocialData() => GetSocialFeedData();

        private List<SocialData> GetSocialFeedData()
        {
            return new List<SocialData>
            {
                new SocialData { Id = 1, ImageSrc = "/images/happydays.jpg", Description = "My best day ever!", Service = SocialServiceName.Instagram },
                new SocialData { Id = 2, ImageSrc = "/images/netcore5.png", Description = ".Net 5 Release days is coming...", Service = SocialServiceName.Twitter },
                new SocialData { Id = 3, ImageSrc = "/images/dancedancedance.gif", Description = "Psychopopdance is all the rage", Service = SocialServiceName.TicToc },
            };
        }
    }
}