using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TPModule5.Models
{
    [Table("Tweets")]
    public class Tweet
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TweetId { get; set; }
        public String CreationDate { get; set; }
        public String Text { get; set; }
        public virtual User User { get; set; }

        public Tweet(int tweetId, string creationDate, string text, User user)
        {
            TweetId = tweetId;
            CreationDate = creationDate;
            Text = text;
            User = user;
        }
    }
}
