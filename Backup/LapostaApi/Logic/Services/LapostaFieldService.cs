using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Laposta.Entities;

namespace Laposta.Services
{
    public class LapostaFieldService : LapostaResource
    {
        private string listId;
        private Dictionary<string, string> parameters;

        public LapostaFieldService(string listId)
            : base("field")
        {
            this.listId = listId;

            // we need the listId with almost every api call
            this.parameters = new Dictionary<string, string>();
            this.parameters.Add("list_id", listId);
        }

        // create a new Field
        public LapostaField Create(LapostaField field)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("list_id", this.listId);
            data.Add("name", field.Name);
            data.Add("datatype", field.Datatype);
            data.Add("required", LapostaUtil.convertBool(field.Required));
            data.Add("in_form",  LapostaUtil.convertBool(field.InForm));
            data.Add("in_list",  LapostaUtil.convertBool(field.InList));
            var response = base.Connect("POST", null,this.parameters, data);
            return Mapper<LapostaField>.MapFromJson(response, "field");
        }

        // update an existing Field
        public LapostaField Update(string fieldId, LapostaField field)
        {
            // only add changed fields
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("list_id", this.listId);
            if (field.Name != null) data.Add("name", field.Name);
            if (field.Datatype != null) data.Add("datatype", field.Datatype);
            if (field.Required != null) data.Add("required", LapostaUtil.convertBool(field.Required));
            if (field.InForm != null) data.Add("in_form", LapostaUtil.convertBool(field.InForm));
            if (field.InList != null) data.Add("in_list", LapostaUtil.convertBool(field.InList));
            
            List<string> path = new List<string>();
            path.Add(fieldId);
            var response = base.Connect("POST", path, this.parameters, data);
            return Mapper<LapostaField>.MapFromJson(response, "field");
        }

        // a specific Field
        public LapostaField Get(string fieldId)
        {
            List<string> path = new List<string>();
            path.Add(fieldId);
            var response = base.Connect("GET", path, this.parameters, null);
            return Mapper<LapostaField>.MapFromJson(response, "field");
        }

        // get all Fields
        public IEnumerable<LapostaField> All()
        {
            var response = base.Connect("GET", null, this.parameters, null);
            return Mapper<LapostaField>.MapCollectionFromJson(response, "field");
        }

        // delete a Field
        public LapostaField Delete(string fieldId)
        {
            List<string> path = new List<string>();
            path.Add(fieldId);
            var response = base.Connect("DELETE", path, this.parameters , null);
            return Mapper<LapostaField>.MapFromJson(response, "field");
        }
    }
}