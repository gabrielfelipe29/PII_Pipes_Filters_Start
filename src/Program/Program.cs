using System;
using CompAndDel.Pipes;
using CompAndDel.Filters;

namespace CompAndDel
{
    class Program
    {
        static void Main(string[] args)
        {
            PictureProvider provider = new PictureProvider();
            IPicture picture = provider.GetPicture("beer.jpg");

            PipeNull pipenull = new PipeNull();
            FilterCondicional filtrocondicional = new FilterCondicional();
            FilterNegative filtronegativo = new FilterNegative();
            FilterGreyscale filtrogreyscale = new FilterGreyscale();
            TwitterFilter filtrotwitter = new TwitterFilter();

            PipeSerial pipeserial4 = new PipeSerial(filtrotwitter, pipenull);
            PipeSerial pipeserial3 = new PipeSerial(filtronegativo, pipenull);
            PipeFork pipefork = new PipeFork(pipeserial4, pipeserial3);

            PipeSerial pipeserial2 = new PipeSerial(filtrocondicional, pipefork);
            PipeSerial pipeserial1 = new PipeSerial(filtrogreyscale, pipeserial2);


            IPicture image = pipeserial1.Send(picture);


            //guarda la ultima imagen
            PictureProvider provider1 = new PictureProvider();
            provider.SavePicture(pipenull.Send(image), "imagenfinal.jpg");


        }
    }
}
