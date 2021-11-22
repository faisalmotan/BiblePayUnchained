using BiblePayCommon;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.ServiceModel.Syndication;
using System.Web;
using System.Web.Helpers;
using System.Xml;

namespace Unchained.Code
{
    public static class FeedItemMethods
    {
        
        public static List<Entity.NewsFeedItem> Method1(string url, out List<Entity.NewsFeedItem> newsFeedItems)
        {
            List<Entity.NewsFeedItem> lstNewsFeedItems = new List<Entity.NewsFeedItem>();

            try
            { 
                using (WebClient wc = new WebClient())
                {
                    var json = wc.DownloadString(url);

                    var dynamicObject = Json.Decode(json);
                    var jsonSettings = new JsonSerializerSettings()
                    {
                        DefaultValueHandling = DefaultValueHandling.Ignore,
                        Formatting = Newtonsoft.Json.Formatting.Indented,
                        TypeNameHandling = TypeNameHandling.All,
                        NullValueHandling = NullValueHandling.Include
                    };

                    var dataList = JsonConvert.DeserializeObject<List<ExpandoObject>>(json, jsonSettings);
                    int Index = 0;

                    foreach (var item in dataList)
                    {
                        Entity.NewsFeedItem news = new Entity.NewsFeedItem();

                        var Title = dataList[Index].ToList().Where(o => o.Key == "title").FirstOrDefault();

                        news.Title = ((ExpandoObject)Title.Value).FirstOrDefault(x => x.Key == "rendered").Value.ToString();
                        news.URL = dataList[Index].ToList().Where(o => o.Key == "link").FirstOrDefault().Value.ToString();
                        news.Body = ((ExpandoObject)((ExpandoObject)dataList[Index]).ToList()[24].Value)
                                    .FirstOrDefault(o => o.Key == "og_description").Value.ToString();
                        lstNewsFeedItems.Add(news);

                        Index += 1;
                    }
                }
            }
            catch (Exception ex)
            {
  
            }

            newsFeedItems = lstNewsFeedItems;
            return lstNewsFeedItems;
        }


        public static List<Entity.NewsFeedItem> Method2(string url, out List<Entity.NewsFeedItem> newsFeedItems)
        {
            List<Entity.NewsFeedItem> lstNewsFeedItems = new List<Entity.NewsFeedItem>();

            try
            {
                using (WebClient wc = new WebClient())
                {
                    var json = wc.DownloadString(url);
                     
                    XmlReader reader = XmlReader.Create(url);
                    SyndicationFeed feed = SyndicationFeed.Load(reader);
                    reader.Close();
                    foreach (SyndicationItem item in feed.Items)
                    {
                        Entity.NewsFeedItem ObjNewsFeedItems = new Entity.NewsFeedItem();

                        ObjNewsFeedItems.URL = item.Id;
                        
                        if (item.Title !=null)
                            ObjNewsFeedItems.Title = item.Title.Text;

                        if (item.Summary !=null)
                            ObjNewsFeedItems.Body = item.Summary.Text;

                        lstNewsFeedItems.Add(ObjNewsFeedItems);
                    }

                }
            }
            catch (Exception ex)
            {

            }

            newsFeedItems = lstNewsFeedItems;
            return lstNewsFeedItems;
        }





    }
}