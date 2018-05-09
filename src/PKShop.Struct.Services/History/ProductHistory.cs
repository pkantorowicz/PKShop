using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using PKShop.Core.Events;

namespace PKShop.Struct.Services.History
{
    public class ProductHistory
    {
        public static IList<ProductHistoryData> HistoryData { get; set; }

        public static IList<ProductHistoryData> ProductHistoryToJson(IList<StoredEvent> storedEvents)
        {
            HistoryData = new List<ProductHistoryData>();
            ProductHistoryDeserializer(storedEvents);

            var sortedEvt = HistoryData.OrderBy(x => x.When);
            var list = new List<ProductHistoryData>();
            var last = new ProductHistoryData();

            foreach (var change in sortedEvt)
            {
                var jsEvt = new ProductHistoryData()
                {
                    Id = change.Id == Guid.Empty.ToString() || change.Id == last.Id 
                        ? ""
                        : change.Id,
                    Name = string.IsNullOrWhiteSpace(change.Name) || change.Name == last.Name
                        ? ""
                        : change.Name,
                    Active = change.Active,
                    Cost = change.Cost,
                    Quantity = change.Quantity,
                    Action = string.IsNullOrWhiteSpace(change.Action) ? "" : change.Action,
                    When = change.When,
                    Who = change.Who
                };

                list.Add(jsEvt);
                last = change;
            }
            return list;
        }

        private static void ProductHistoryDeserializer(IEnumerable<StoredEvent> storedEvents)
        {
            foreach (var e in storedEvents)
            {
                var evt = new ProductHistoryData();
                dynamic values;

                switch (e.MessageType)
                {
                    case "ProductCreatedEvent":
                        values = JsonConvert.DeserializeObject<dynamic>(e.Data);
                        evt.Action = "Created";
                        evt.Id = values["Id"];
                        evt.Name = values["Name"];
                        evt.Active = values["Active"];
                        evt.Cost = values["Cost"];
                        evt.Quantity = values["Quantity"];
                        evt.When = values["TimeStamp"];
                        evt.Who = e.User;
                        break;
                    case "ProductUpdatedEvent":
                        values = JsonConvert.DeserializeObject<dynamic>(e.Data);
                        evt.Action = "Updated";
                        evt.Id = values["Id"];
                        evt.Name = values["Name"];
                        evt.Active = values["Active"];
                        evt.Cost = values["Cost"];
                        evt.Quantity = values["Quantity"];
                        evt.When = values["TimeStamp"];
                        evt.Who = e.User;
                        break;
                    case "ProductDeletedEvent":
                        values = JsonConvert.DeserializeObject<dynamic>(e.Data);
                        evt.Action = "Removed";
                        evt.When = values["Timestamp"];
                        evt.Id = values["Id"];
                        evt.Who = e.User;
                        break;
                }
                HistoryData.Add(evt);
            }
        }
    }
}