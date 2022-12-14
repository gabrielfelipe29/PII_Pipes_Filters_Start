using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CompAndDel;

namespace CompAndDel.Pipes
{
    public class PipeSerial : IPipe
    {
        protected IFilter filtro;
        protected IPipe nextPipe;

        private ImageHandler imageHandler = new ImageHandler();
        private TwitterMessage twitterMessage = new TwitterMessage();

        public string path { get; private set; }

        public IPicture picture { get; private set; }
        /// <summary>
        /// La cañería recibe una imagen, le aplica un filtro y la envía a la siguiente cañería
        /// </summary>
        /// <param name="filtro">Filtro que se debe aplicar sobre la imagen</param>
        /// <param name="nextPipe">Siguiente cañería</param>
        public PipeSerial(IFilter filtro, IPipe nextPipe)
        {
            this.nextPipe = nextPipe;
            this.filtro = filtro;
        }
        /// <summary>
        /// Devuelve el proximo IPipe
        /// </summary>
        public IPipe Next
        {
            get { return this.nextPipe; }
        }
        /// <summary>
        /// Devuelve el IFilter que aplica este pipe
        /// </summary>
        public IFilter Filter
        {
            get { return this.filtro; }
        }
        /// <summary>
        /// Recibe una imagen, le aplica un filtro, guarda la imagen, la sube a twitter y la envía al siguiente Pipe
        /// </summary>
        /// <param name="picture">Imagen a la cual se debe aplicar el filtro</param>
        public IPicture Send(IPicture pic)
        {
            //aplica filtro, genera un path para guardar la imagen y la guarda
            picture = this.filtro.Filter(pic);
            path = imageHandler.GeneratePath();

            imageHandler.SaveImage(picture, path);
            picture.path = path;

            return this.nextPipe.Send(picture);
        }
    }
}
