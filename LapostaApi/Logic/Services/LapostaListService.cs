using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Laposta.Entities;

namespace Laposta.Services
{
    public class LapostaListService : LapostaResource
    {
        public LapostaListService()
            : base("list")
        { }

        // create a new list
        public LapostaList Create(LapostaList list)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("name", list.Name);
            data.Add("remarks", list.Remarks);
            data.Add("subscribe_notification_email", list.SubscribeNotificationEmail);
            data.Add("unsubscribe_notification_email", list.UnsubscribeNotificationEmail);

            var response = base.Connect("POST", null, null, data);
            return Mapper<LapostaList>.MapFromJson(response, "list");
        }

        // update an existing list
        public LapostaList Update(string listId, LapostaList list)
        {
            // only add changed fields
            Dictionary<string, string> data = new Dictionary<string, string>();
            if (list.Name != null) data.Add("name", list.Name);
            if (list.Remarks != null) data.Add("remarks", list.Remarks);
            if (list.SubscribeNotificationEmail != null) data.Add("subscribe_notification_email", list.SubscribeNotificationEmail);
            if (list.UnsubscribeNotificationEmail != null) data.Add("unsubscribe_notification_email", list.UnsubscribeNotificationEmail);

            List<string> path = new List<string>();
            path.Add(listId);

            var response = base.Connect( "POST", path, null, data);
            return Mapper<LapostaList>.MapFromJson(response, "list");
        }

        // a specific list
        public LapostaList Get(string listId)
        {
            List<string> path = new List<string>();
            path.Add(listId);            
            var response = base.Connect("GET" , path, null,null);
            return Mapper<LapostaList>.MapFromJson(response, "list");
        }

        // get all lists
        public IEnumerable<LapostaList> All()
        {
            var response = base.Connect( "GET", null,null,null);
            return Mapper<LapostaList>.MapCollectionFromJson(response, "list");
        }

        // delete a list
        public LapostaList Delete(string listId)
        {
            List<string> path = new List<string>();
            path.Add(listId);            
            var response = base.Connect("DELETE", path, null,null);
            return Mapper<LapostaList>.MapFromJson(response, "list");
        }
    }
}