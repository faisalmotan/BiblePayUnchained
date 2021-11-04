using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Unchained
{
    public class News
    {
        public string Title { get; set; }
        public string Link { get; set; }
        public string Body { get; set; }
        

    }

    public partial class NewsProofOfConcept : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected string GetNews()
        {
            string StrNews = "";
            using (WebClient wc = new WebClient())
            {
                var json = wc.DownloadString("https://www.australiannationalreview.com/wp-json/wp/v2/posts?per_page=5");

                var dynamicObject = Json.Decode(json);
                var jsonSettings = new JsonSerializerSettings()
                {
                    DefaultValueHandling = DefaultValueHandling.Ignore,
                    Formatting = Newtonsoft.Json.Formatting.Indented,
                    TypeNameHandling = TypeNameHandling.All,
                    NullValueHandling = NullValueHandling.Include
                };

                var dataList = JsonConvert.DeserializeObject<List<ExpandoObject>>(json, jsonSettings);

                List<News> LstNews = new List<News>();
                int Index = 0;
                string sHTML = "<table class='news'>";
                foreach (var item in dataList)
                {
                    News news = new News();

                    var Title = dataList[Index].ToList().Where(o => o.Key == "title").FirstOrDefault();

                    news.Title = ((ExpandoObject)Title.Value).FirstOrDefault(x => x.Key == "rendered").Value.ToString();
                    news.Link = dataList[Index].ToList().Where(o => o.Key == "link").FirstOrDefault().Value.ToString();
                    news.Body = ((ExpandoObject)((ExpandoObject)dataList[Index]).ToList()[24].Value)
                                .FirstOrDefault(o => o.Key == "og_description").Value.ToString();
                    LstNews.Add(news); 

                    Index += 1;

                    sHTML += "<tr><td>";
                    sHTML += "<a target='_blank' href='" + news.Link + "'><h2 class='headline'>" + news.Title + "</h2></a><br>";
                    sHTML += "<span class='headline'>" + news.Body + "</span><br><br><a target='_blank' href='" + news.Link + "' style='text-decoration: underline;'>Read more</a><br><br>";
                    sHTML += "</td>";
                    sHTML += "</tr>";
                }

                StrNews = sHTML;
            }
            return StrNews;
        }
    }
}