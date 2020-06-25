using System;
using System.Collections.Generic;
using System.Text;
using TPModule5.Models;

namespace TPModule5.Services
{
    interface ITwitterService
    {

        bool Authenticate(User user);
        List<Tweet> GetTweets(); 

    }
}
