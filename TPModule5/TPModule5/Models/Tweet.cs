using System;
using System.Collections.Generic;
using System.Text;

namespace TPModule5.Models
{
    public class Tweet
    {
        public int TweetId { get; set; }
        public String CreationDate { get; set; }
        public String Text { get; set; }
        public User User { get; set; }

        public Tweet(int tweetId, string creationDate, string text, User user)
        {
            TweetId = tweetId;
            CreationDate = creationDate;
            Text = text;
            User = user;
        }
    }
}
