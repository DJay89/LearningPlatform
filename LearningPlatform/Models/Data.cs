using System.Runtime.Serialization;

namespace LearningPlatform.Models
{
    public class Data
    {
        [IgnoreDataMember]
        public int Id { get; set; }

        [IgnoreDataMember]
        public int UserId { get; set; }
        public bool IsTextUnderstood { get; set; }
        public int WPM { get; set; }
        public int WordCount { get; set; }
        public string Mode { get; set; }

        public User User { get; set; }
    }
}
