using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Laposta.Entities;

namespace Laposta.Services
{
    public class LapostaWebhookService : LapostaResource
    {
        private string listId;
        private Dictionary<string, string> parameters;

        public LapostaWebhookService(string listId)
            : base("webhook")
        {
            this.listId = listId;

            // we need the listId with almost every api call
            this.parameters = new Dictionary<string, string>();
            this.parameters.Add("list_id", listId);
        }

        // create a new Webhook
        public LapostaWebhook Create(LapostaWebhook webhook)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("list_id", this.listId);
            data.Add("event", webhook.Event);
            data.Add("url", webhook.Url);
            data.Add("blocked", LapostaUtil.convertBool(webhook.Blocked));
            var response = base.Connect("POST", null, this.parameters, data);
            return Mapper<LapostaWebhook>.MapFromJson(response, "webhook");
        }

        // update an existing Webhook
        public LapostaWebhook Update(string webhookId, LapostaWebhook webhook)
        {
            // only add changed webhooks
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("list_id", this.listId);
            if (webhook.Event != null) data.Add("event", webhook.Event);
            if (webhook.Url != null) data.Add("url", webhook.Url);
            if (webhook.Blocked != null) data.Add("blocked", LapostaUtil.convertBool(webhook.Blocked));
                        
            List<string> path = new List<string>();
            path.Add(webhookId);
            var response = base.Connect("POST", path, this.parameters, data);
            return Mapper<LapostaWebhook>.MapFromJson(response, "webhook");
        }

        // a specific Webhook
        public LapostaWebhook Get(string webhookId)
        {
            List<string> path = new List<string>();
            path.Add(webhookId);
            var response = base.Connect("GET", path, this.parameters, null);
            return Mapper<LapostaWebhook>.MapFromJson(response, "webhook");
        }

        // get all Webhooks
        public IEnumerable<LapostaWebhook> All()
        {            var response = base.Connect("GET", null, this.parameters,null);
            return Mapper<LapostaWebhook>.MapCollectionFromJson(response, "webhook");
        }

        // delete a Webhook
        public LapostaWebhook Delete(string webhookId)
        {
            List<string> path = new List<string>();
            path.Add(webhookId);
            var response = base.Connect("DELETE", path, this.parameters, null);
            return Mapper<LapostaWebhook>.MapFromJson(response, "webhook");
        }
    }
}