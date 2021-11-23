using BiblePayCommon;
using BiblePayCommonNET;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Web;
using System.Web.Helpers;
using System.Web.UI;
using System.Web.UI.WebControls;
using static Unchained.Common;

namespace Unchained
{ 
    public partial class NewsProofOfConcept : BBPPage
    {
        private int iPageSize = 5;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["PageNo"] != null)
                {
                    ViewState["PageNumber"] = Request.QueryString["PageNo"];
                }
                else
                {
                    ViewState["PageNumber"] = 0;
                }
                GetNews();
            }
        }

        private void GetNews()
        {
            _EntityName = "NewsFeedItem";
            DataTable dtData = BiblePayDLL.Sidechain.RetrieveDataTable3(IsTestNet(this), _EntityName);
           

            PagedDataSource pdsData = new PagedDataSource();
            DataView dv = new DataView(dtData);
            pdsData.DataSource = dv;
            pdsData.AllowPaging = true;
            pdsData.PageSize = iPageSize;
            if (ViewState["PageNumber"] != null)
                pdsData.CurrentPageIndex = Convert.ToInt32(ViewState["PageNumber"]);
            else
                pdsData.CurrentPageIndex = 0;
            if (pdsData.PageCount > 1)
            {
                Repeater2.Visible = true;
                ArrayList alPages = new ArrayList();
                for (int i = 1; i <= pdsData.PageCount; i++)
                    alPages.Add((i).ToString());
                Repeater2.DataSource = alPages;
                Repeater2.DataBind();
            }
            else
            {
                Repeater2.Visible = false;
            }
            Repeater1.DataSource = pdsData;
            Repeater1.DataBind();

        }

        protected void Repeater2_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int PageNo = Convert.ToInt32(e.CommandArgument);
            Response.Redirect($"NewsProofOfConcept.aspx?PageNo={PageNo}");
        }

        //protected string GetNews()
        //{
        //    string StrNews = "";
        //    using (WebClient wc = new WebClient())
        //    {
        //        var json = wc.DownloadString("https://www.australiannationalreview.com/wp-json/wp/v2/posts?per_page=5");

        //        var dynamicObject = Json.Decode(json);
        //        var jsonSettings = new JsonSerializerSettings()
        //        {
        //            DefaultValueHandling = DefaultValueHandling.Ignore,
        //            Formatting = Newtonsoft.Json.Formatting.Indented,
        //            TypeNameHandling = TypeNameHandling.All,
        //            NullValueHandling = NullValueHandling.Include
        //        };

        //        var dataList = JsonConvert.DeserializeObject<List<ExpandoObject>>(json, jsonSettings);

        //        List<News> LstNews = new List<News>();
        //        int Index = 0;
        //        string sHTML = "<table class='news'>";
        //        foreach (var item in dataList)
        //        {
        //            News news = new News();

        //            var Title = dataList[Index].ToList().Where(o => o.Key == "title").FirstOrDefault();

        //            news.Title = ((ExpandoObject)Title.Value).FirstOrDefault(x => x.Key == "rendered").Value.ToString();
        //            news.Link = dataList[Index].ToList().Where(o => o.Key == "link").FirstOrDefault().Value.ToString();
        //            news.Body = ((ExpandoObject)((ExpandoObject)dataList[Index]).ToList()[24].Value)
        //                        .FirstOrDefault(o => o.Key == "og_description").Value.ToString();
        //            LstNews.Add(news);

        //            Index += 1;

        //            sHTML += "<tr><td>";
        //            sHTML += "<a target='_blank' href='" + news.Link + "'><h2 class='headline'>" + news.Title + "</h2></a><br>";
        //            sHTML += "<span class='headline'>" + news.Body + "</span><br><br><a target='_blank' href='" + news.Link + "' style='text-decoration: underline;'>Read more</a><br><br>";
        //            sHTML += "</td>";
        //            sHTML += "</tr>";
        //        }

        //        StrNews = sHTML;
        //    }
        //    return StrNews;
        //}
    }
}