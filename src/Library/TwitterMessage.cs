namespace CompAndDel;
using TwitterUCU;
using System;
public class TwitterMessage
{
    public void Send(string path)
    {
        var twitter = new TwitterImage();
        Console.WriteLine(twitter.PublishToTwitter("", path));
        
    }
}