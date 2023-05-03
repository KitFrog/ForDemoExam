using DataModels.IRepositories;
using DataModels.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DataModels
{
    public class DataManager
    {
        public IDateOnlyRep? DateOnlyRep { get; }
        public IEventRep EventRep { get; }
        public IMessageRep MessageRep { get; }
        public IPlaceRep PlaceRep { get; }
        public IUserRep UserRep { get; }
        private DataManager(IEventRep eventRep, IMessageRep messageRep, IPlaceRep placeRep, IUserRep userRep)
        {
            EventRep = eventRep;
            MessageRep = messageRep;
            PlaceRep = placeRep;
            UserRep = userRep;
        }

        public static DataManager Get(DataProvider data)
        {
            switch (data)
            {
                default:
                    throw new DataMisalignedException("No data");
                case DataProvider.SqlServer:
                    throw new Exception("Debugging and (structured) exception handling - tracking down and fixing programming errors in an application under development.");
                case DataProvider.SqLite:
                    var dir = Path.GetDirectoryName(DataContext.DataSource);
                    if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);
                    var context = new DataContext();
                    context.Database.EnsureCreated();
                    return new DataManager(new EventRep(context), new MessageRep(context), new PlaceRep(context), new UserRep(context));
            }
        }
    }
}
