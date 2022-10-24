namespace CompAndDel;
using TwitterUCU;

public class TwitterFilter : IFilter
{
    private TwitterMessage msg = new TwitterMessage();

    public IPicture Filter(IPicture image)
    {
        //envio imagen a twitter
        msg.Send(image.path);
        return image;
    }

}