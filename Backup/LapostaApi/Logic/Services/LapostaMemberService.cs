using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Laposta.Entities;

namespace Laposta.Services
{
    public class LapostaMemberService : LapostaResource
    {
        private string listId;
        private Dictionary<string, string> parameters;

        public LapostaMemberService(string listId)
            : base("member")
        {
            this.listId = listId;

            // we need the listId with almost every api call
            this.parameters = new Dictionary<string, string>();
            this.parameters.Add("list_id", listId);
        }

        // create a new Member
        public LapostaMember Create(LapostaMember member)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("list_id", this.listId);
            data.Add("email", member.Email);
            data.Add("ip", member.IP);
            data.Add("source_url", member.SourceUrl);
            if (member.CustomFields != null) 
            {
                foreach (KeyValuePair<string, string> kvp in member.CustomFields)
                {
                    data.Add("custom_fields[" + kvp.Key + "]", kvp.Value);
                }
            }
            var response = base.Connect( "POST", null, this.parameters, data);
            return Mapper<LapostaMember>.MapFromJson(response, "member");
        }

        // update an existing Member
        public LapostaMember Update(string memberId, LapostaMember member)
        {
            // only add changed members
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("list_id", this.listId);
            if (member.Email != null) data.Add("email", member.Email);
            if (member.State != null) data.Add("state", member.State);
            if (member.CustomFields != null)
            {
                foreach (KeyValuePair<string, string> kvp in member.CustomFields)
                {
                    data.Add("custom_fields[" + kvp.Key + "]", kvp.Value);
                }
            }

            List<string> path = new List<string>();
            path.Add(memberId);

            var response = base.Connect("POST", path, this.parameters, data);
            return Mapper<LapostaMember>.MapFromJson(response, "member");
        }

        // a specific Member
        public LapostaMember Get(string memberId)
        {
            List<string> path = new List<string>();
            path.Add(memberId);
            var response = base.Connect("GET", path, this.parameters, null);
            return Mapper<LapostaMember>.MapFromJson(response, "member");
        }

        // get all Members
        public IEnumerable<LapostaMember> All()
        {
            var response = base.Connect("GET", null, this.parameters, null);
            return Mapper<LapostaMember>.MapCollectionFromJson(response, "member");
        }

        // delete a Member
        public LapostaMember Delete(string memberId)
        {
            List<string> path = new List<string>();
            path.Add(memberId);
            var response = base.Connect( "DELETE", path, this.parameters, null);
            return Mapper<LapostaMember>.MapFromJson(response, "member");
        }
    }
}