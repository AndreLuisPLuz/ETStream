namespace ETStream.Domain.Aggregates.Channel
{
    public class Privileges
    {
        public required bool CanPostContent { get; set; }
        public required bool CanEditContent { get; set; }
        public required bool CanDeleteContent { get; set; }
        public required bool CanModerateComments { get; set; }
        public required bool CanEditChannel { get; set; }
        public required bool CanDeleteChannel { get; set; }
    }
}