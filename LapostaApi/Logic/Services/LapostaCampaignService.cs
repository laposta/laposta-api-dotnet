using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Laposta.Entities;

namespace Laposta.Services
{
    public class LapostaCampaignService : LapostaResource
    {
        public LapostaCampaignService()
            : base("campaign")
        {
        }

        public LapostaCampaign Create(LapostaCampaign campaign)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("type", campaign.Type);
            data.Add("name", campaign.Name);
            data.Add("subject", campaign.Subject);
            data.Add("from[name]", campaign.From.Name);
            data.Add("from[email]", campaign.From.Email);
            if (!string.IsNullOrEmpty(campaign.ReplyTo))
            {
                data.Add("reply_to", campaign.ReplyTo);
            }
            foreach (var listId in campaign.ListIds.Where(x => x != null))
            {
                data.Add("list_ids[]", listId);
            }
            object value;
            if (campaign.Stats.TryGetValue("ga", out value))
            {
                data.Add("stats[ga]", value.ToString());

            }
            if (campaign.Stats.TryGetValue("mtrack", out value))
            {
                data.Add("stats[mtrack]", value.ToString());
            }
            var response = base.Connect("POST", null, null, data);
            return Mapper<LapostaCampaign>.MapFromJson(response, "campaign");
        }

        public LapostaCampaign Update(string campaignId, LapostaCampaign campaign)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();

            data.Add("campaign_id", campaignId);
            if (!string.IsNullOrEmpty(campaign.Name)) data.Add("name", campaign.Name);
            if (!string.IsNullOrEmpty(campaign.Subject)) data.Add("subject", campaign.Subject);
            if (campaign.From != null)
            {
                if (!string.IsNullOrEmpty(campaign.From.Name)) data.Add("from[name]", campaign.From.Name);
                if (!string.IsNullOrEmpty(campaign.From.Email)) data.Add("from[email]", campaign.From.Email);
            }
            if (!string.IsNullOrEmpty(campaign.ReplyTo)) data.Add("reply_to", campaign.ReplyTo);

            foreach (var listId in campaign.ListIds.Where(x => x != null))
            {
                data.Add("list_ids[]", listId);
            }
            object value;
            if (campaign.Stats.TryGetValue("ga", out value))
            {
                data.Add("stats[ga]", value.ToString());

            }
            if (campaign.Stats.TryGetValue("mtrack", out value))
            {
                data.Add("stats[mtrack]", value.ToString());
            }

            List<string> path = new List<string>();
            path.Add(campaignId);
            var response = base.Connect("POST", path, null, data);
            return Mapper<LapostaCampaign>.MapFromJson(response, "campaign");
        }

        public LapostaCampaign Get(string campaignId)
        {
            List<string> path = new List<string>();
            path.Add(campaignId);
            var response = base.Connect("GET", path, null, null);
            return Mapper<LapostaCampaign>.MapFromJson(response, "campaign");
        }

        public LapostaCampaign Content(string campaignId)
        {
            List<string> path = new List<string>();
            path.Add(campaignId);
            path.Add("content");
            var response = base.Connect("GET", path, null, null);
            return Mapper<LapostaCampaign>.MapFromJson(response, "campaign");
        }

        public LapostaCampaign FillContent(LapostaCampaign campaign)
        {
            List<string> path = new List<string>();
            path.Add(campaign.CampaignId);
            path.Add("content");

            Dictionary<string, string> data = new Dictionary<string, string>();

            if (!string.IsNullOrEmpty(campaign.ImportUrl))
            {
                if(Uri.IsWellFormedUriString(campaign.ImportUrl, UriKind.Absolute))
                {
                    data.Add("import_url", campaign.ImportUrl);
                }
            }
            if (!string.IsNullOrEmpty(campaign.Html))
            {
                data.Add("html", campaign.Html);
            }
            var response = base.Connect("POST", path, null, data);
            return Mapper<LapostaCampaign>.MapFromJson(response, "campaign");
        }

        public IEnumerable<LapostaCampaign> All()
        {
            var response = base.Connect("GET", null, null, null);
            return Mapper<LapostaCampaign>.MapCollectionFromJson(response, "campaign");
        }

        public LapostaCampaign Delete(string campaignId)
        {
            List<string> path = new List<string>();
            path.Add(campaignId);
            var response = base.Connect("DELETE", path, null, null);
            return Mapper<LapostaCampaign>.MapFromJson(response, "campaign");
        }

        public LapostaCampaign Send(string campaignId)
        {
            List<string> path = new List<string>();
            path.Add(campaignId);
            path.Add("action");
            path.Add("send");
            var response = base.Connect("POST", path, null, null);
            return Mapper<LapostaCampaign>.MapFromJson(response, "campaign");
        }

        public LapostaCampaign Schedule(string campaignId,DateTime timestamp)
        {
            List<string> path = new List<string>();
            path.Add(campaignId);
            path.Add("action");
            path.Add("schedule");

            Dictionary<string, string> data = new Dictionary<string, string>();

            if (timestamp != null)
            {    
                data.Add("delivery_requested", timestamp.ToString("yyyy-MM-dd HH:mm:ss"));
            }

            var response = base.Connect("POST", path, null, data);
            return Mapper<LapostaCampaign>.MapFromJson(response, "campaign");
        }

        public LapostaCampaign Test(string campaignId,string email)
        {
            List<string> path = new List<string>();
            path.Add(campaignId);
            path.Add("action");
            path.Add("testmail");

            Dictionary<string, string> data = new Dictionary<string, string>();
            try
            {
                var mail = new System.Net.Mail.MailAddress(email);
                if(email == mail.Address)
                {
                    data.Add("email", mail.Address);
                }
            }catch(Exception) { throw new LapostaException(System.Net.HttpStatusCode.BadRequest, null, "mail not valid"); }

            var response = base.Connect("POST", path, null, data);
            return Mapper<LapostaCampaign>.MapFromJson(response, "campaign");
        }
    }
}