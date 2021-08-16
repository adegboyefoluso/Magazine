using Magazine.Data;
using Magazine.MOdel.EventFolder;
using Magazine.MOdel.ImageFolder;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magazine.Service
{
    public class EventServices
    {
        private readonly Guid _UserId;
        public EventServices(Guid userid)
        {
            _UserId = userid;
        }

        public bool CreateEvent(EventCreate model)
        {
            byte[] bytes = null;
            if (model.File != null)
            {
                Stream Fs = model.File.InputStream;
                BinaryReader Br = new BinaryReader(Fs);
                bytes = Br.ReadBytes((Int32)Fs.Length);
            }

            var entity = new Event
            {
                EventName = model.EventName,
                EventDate = model.EventDate,
                EventDetails = model.EventDetails,
                OwnerId = _UserId,
                FileContent = bytes,
                CategoryId = model.CategoryId,
                EventHightlight=model.EventHigghtLight
            };
            using(var ctx =new ApplicationDbContext())
            {
                ctx.Events.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<EventListItem> GetAllEvents()
        {
            using (var ctx= new ApplicationDbContext())
            {
                var events = ctx
                               .Events
                               .Select(e => new EventListItem
                               {
                                   EventId = e.EventId,
                                   EventDate = e.EventDate,
                                   EventName = e.EventName,
                                   FileContent=e.FileContent,
                                   EventDetails=e.EventDetails,
                                   EventHighlight=e.EventHightlight,
                                   CategoryName=e.Category.CategoryName,
                               }).ToList();
                return events;
            }
        }


        public bool UpdateEvent(int EventId, EventCreate model)
        {
            byte[] bytes = null;
            if (model.File != null)
            {
                Stream Fs = model.File.InputStream;
                BinaryReader Br = new BinaryReader(Fs);
                bytes = Br.ReadBytes((Int32)Fs.Length);
            }
            using (var ctx = new ApplicationDbContext())
            {
                var even = ctx
                                .Events
                                .Find(EventId);

                even.EventName = model.EventName;
                even.EventDate = model.EventDate;
                even.EventDetails = model.EventDetails;
                even.CategoryId = model.CategoryId;
                even.FileContent = bytes;

                return ctx.SaveChanges() == 1;
                            
            }
        }

        public EventDetail EventDetails(int eventId)
        {
            using(var ctx=new ApplicationDbContext())
            {
                var even = ctx  
                                .Events
                                .Find(eventId);

                return new EventDetail
                {
                    EventDate = even.EventDate,
                    EventId = even.EventId,
                    EventDetails = even.EventDetails,
                    FileContent = even.FileContent,
                    EventName = even.EventName

                };            
            }
        }

        public IEnumerable<ImageListItem> GetAlLImage(int eventid)
        {
            using(var ctx= new ApplicationDbContext())
            {
                var images = ctx
                                 .Images
                                 .Where(e => e.EventId == eventid)
                                 .Select(e => new ImageListItem()
                                 {
                                     EventId = e.EventId,
                                     FileContent = e.FileContent,
                                     ImageId = e.ImageId,
                                     ImgageInfo = e.ImgageInfo,
                                     EventDetails=e.Event.EventDetails,
                                     Eventhighlight=e.Event.EventHightlight

                                 }).ToList();

                return images;
            }
        }

        public IEnumerable<EventListItem> GetAllEventsByCategory(int categoryId)
        {
            using(var ctx= new ApplicationDbContext())
            {
                var events = ctx
                                .Events
                                .Where(e => e.CategoryId == categoryId)
                                .Select(e => new EventListItem
                                {
                                    EventDate = e.EventDate,
                                    EventId = e.EventId,
                                    EventName = e.EventName,
                                    FileContent = e.FileContent
                                }).ToList();
                return events;
            }
        }
        public  IEnumerable<EventListItem> GetAllEventByDate(DateTime date)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var events = ctx
                                .Events
                                .Where(e => e.EventDate.Month == date.Month)
                                .Select(e => new EventListItem
                                {
                                    EventDate = e.EventDate,
                                    EventName = e.EventName,
                                    FileContent = e.FileContent,
                                    EventId = e.EventId,
                                }).ToList();
                return events;
            }
        }


        
        


    }
}
