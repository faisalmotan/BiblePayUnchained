using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static Unchained.Common;


namespace Unchained
{
    public partial class AddNewsFeedItem : BBPPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            _EntityName = "NewsFeedSource";

            DataTable dt = BiblePayDLL.Sidechain.RetrieveDataTable3(IsTestNet(this), _EntityName);

            string Test = "";

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
              _EntityName = "NewsFeedSource";

            DataTable dt = BiblePayDLL.Sidechain.RetrieveDataTable3(IsTestNet(this), _EntityName);


            BiblePayCommon.IBBPObject o = (BiblePayCommon.IBBPObject)BiblePayCommon.EntityCommon.GetInstance("BiblePayCommon.Entity+" + _EntityName);
            BiblePayCommon.EntityCommon.SetEntityValue(o, "FeedName", "Test");
            //BiblePayCommon.EntityCommon.SetEntityValue(o, "Body", txtBody.Text);
            //BiblePayCommon.EntityCommon.SetEntityValue(o, "TicketNumber", (int)nTicketNumber);
            BiblePayCommon.EntityCommon.SetEntityValue(o, "id", Guid.NewGuid().ToString());
            //BiblePayCommon.EntityCommon.SetEntityValue(o, "Disposition", "");
            //BiblePayCommon.EntityCommon.SetEntityValue(o, "AssignedTo", "");
             BiblePayCommon.EntityCommon.SetEntityValue(o, "UserID", gUser(this).id);
            BiblePayCommon.Common.DACResult r = DataOps.InsertIntoTable(this, IsTestNet(this), o, gUser(this));

        }
    }
}