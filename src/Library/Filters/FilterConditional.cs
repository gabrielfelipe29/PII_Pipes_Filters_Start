using System;
using System.Drawing;
using CognitiveCoreUCU;
namespace CompAndDel.Filters;

public class FilterCondicional : IFilter
{
    public bool HasFace { get; set; }
    public IPicture Filter(IPicture image)
    {
        //verifica que tenga cara o no, aplico creator
        CognitiveFace cog = new CognitiveFace(true, Color.GreenYellow);
        cog.Recognize(image.path);
        image.HasFace = cog.FaceFound;
        Console.WriteLine($"Tiene cara: {image.HasFace}");
        return image;
    }

}