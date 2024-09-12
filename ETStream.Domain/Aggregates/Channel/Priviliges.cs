namespace ETStream.Domain.Aggregates.Channel
{
    public class Privileges
    {
        public bool CanPostContent { get; set; }
        public bool CanEditContent { get; set; }
        public bool CanDeleteContent { get; set; }
        public bool CanModerateComments { get; set; }
        public bool CanEditChannel { get; set; }
        public bool CanDeleteChannel { get; set; }
    }
}