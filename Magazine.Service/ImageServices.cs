using Magazine.Data;
using Magazine.MOdel.ImageFolder;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magazine.Service
{
    public class ImageServices
    {
        private readonly Guid _UserId;
        public ImageServices(Guid userid)
        {
            _UserId = userid;
        }


        public bool  CreateImage (ImageCreate model)
        {
            byte[] bytes = null;
            if (model.File != null)
            {
                Stream Fs = model.File.InputStream;
                BinaryReader Br = new BinaryReader(Fs);
                bytes = Br.ReadBytes((Int32)Fs.Length);
            }
            var image = new Image()
            {
                EventId = model.EventId,
                ImgageInfo = model.ImgageInfo,
                FileContent = bytes,

            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Images.Add(image);
                return ctx.SaveChanges() == 1;
            }

        }

        public IEnumerable<ImageListItem> GetAllImage()
        {
            using(var ctx= new ApplicationDbContext())
            {
                var images = ctx
                                .Images
                                .Select(e => new ImageListItem
                                {
                                    EventId = e.EventId,
                                    FileContent = e.FileContent,
                                    ImageId = e.ImageId,
                                    ImgageInfo = e.ImgageInfo,

                                }).ToList();
                return images;
            }
        }

        public ImageDetail GetImageDetail(int imageId)
        {
            using (var ctx= new ApplicationDbContext())
            {
                var image = ctx
                                .Images
                                .Find(imageId);


                return new ImageDetail
                {
                    EventId = image.EventId,
                    FileContent = image.FileContent,
                    ImageId = image.ImageId,
                    ImgageInfo = image.ImgageInfo,
                };
            }
        }
      
    }
}
