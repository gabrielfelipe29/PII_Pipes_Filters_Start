namespace CompAndDel;
using System;
using CognitiveCoreUCU;

public class ImageHandler
{
    private PictureProvider provider;

    public void SaveImage(IPicture picture, string path)
    {
        // guarda la imagen en el path indicado
        provider = new PictureProvider();
        provider.SavePicture(picture, path);

    }

    public string GeneratePath()
    {
        //genera un path en formato de fecha 
        return DateTime.Now.ToString("yyyyMMdd_hhmmssfff") + ".jpg";
    }

}