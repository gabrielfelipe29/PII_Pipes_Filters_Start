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
            IPicture picture = provider.GetPicture("luke.jpg");

            PipeNull pipenull = new PipeNull();

            FilterNegative filter2 = new FilterNegative();
            FilterGreyscale filter1 = new FilterGreyscale();

            PipeSerial piperserial2 = new PipeSerial(filter2, pipenull);
            PipeSerial piperserial1 = new PipeSerial(filter1, piperserial2);


            IPicture image = piperserial1.Send(picture);
            pipenull.Send(image);

            //PictureProvider provider1 = new PictureProvider();
            //provider.SavePicture(image, "nuevaimage.jpg");


        }
    }
}
