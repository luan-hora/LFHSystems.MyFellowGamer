﻿using LFHSystems.MyFellowGamer.Model;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using LFHSystems.MyFellowGamer.Utils.Extensions;
using LFHSystems.MyFellowGamer.Utils.API;

namespace LFHSystems.MyFellowGamer.Business
{
    public class PublisherBusiness : BaseBusiness<PublisherModel>
    {
        public PublisherBusiness(IConfiguration configuration) : base(configuration)
        {
        }

        public PublisherModel CreateNewPublisher(PublisherModel pObj)
        {
            pObj.CreationDate = DateTime.Now;

            StringContent content = new StringContent(pObj.ToJson(), Encoding.UTF8, "application/json");
            string response = APIConsume.ApiPostAsync($"{_configuration.GetSection("ApiAddresses:WebApiMFG").Value}/Publisher/Insert", content).Result;

            return pObj;
        }

        public List<PublisherModel> GetExistingPublishers(PublisherModel pObj)
        {
            List<PublisherModel> ret;

            StringContent content = new StringContent(pObj.ToJson(), Encoding.UTF8, "application/json");
            string response = APIConsume.ApiGetAsync($"{_configuration.GetSection("ApiAddresses:WebApiMFG").Value}/Publisher/GetExistingPublishers").Result;
            ret = Newtonsoft.Json.JsonConvert.DeserializeObject<List<PublisherModel>>(response);

            return ret;
        }

        public override bool ValidateModel(PublisherModel pObj)
        {
            return true;
        }

        public override void GenericMethod(PublisherModel pObj)
        {
        }
    }
}
