using System.Drawing;

namespace PracticeCoreSPD.Areas.Decorator.Core
{
    public class DecoratorBase : IPhoto
    {
        private IPhoto photo;

        public DecoratorBase(IPhoto photo)
        {
            this.photo = photo;
        }
        public virtual Bitmap GetPhoto()
        {
            return photo.GetPhoto();
        }
    }
}
