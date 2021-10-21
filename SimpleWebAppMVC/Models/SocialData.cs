namespace SimpleWebAppMVC.Models
{
    public class SocialData
    {
        public int Id { get; set; }

        public string ImageSrc { get; set; }

        public string Description { get; set; }

        public SocialServiceName Service { get; set; }
    }

    public enum SocialServiceName
    {
        Twitter,
        Instagram,
        TicToc
    }
}
