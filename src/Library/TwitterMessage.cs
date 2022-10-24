namespace CompAndDel;
using TwitterUCU;
using System;
public class TwitterMessage
{
    public void Send(string path)
    {
        //aplico creator y envio la imagen a twitter
        var twitter = new TwitterImage();
        Console.WriteLine(twitter.PublishToTwitter("", path));
        
    }
}