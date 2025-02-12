﻿using System;
using System.Data;
using static Unchained.Common;

namespace Unchained
{
    public partial class TicketAdd : BBPPage
    {
        protected new void Page_Load(object sender, EventArgs e)
        {
            if (!gUser(this).LoggedIn)
            {
                UICommon.MsgBox("Not Logged In", "Sorry, you must be logged in to add a new item.", this);
                return;
            }
            this.Title = _ObjectName + " Add";
        }


        protected void btnSave_Click(object sender, EventArgs e)
        {
            _EntityName = "Ticket";
            if (!gUser(this).LoggedIn)
            {
                UICommon.MsgBox("Not Logged In", "Sorry, you must be logged in first.", this);
                return;
            }
            if (txtSubject.Text.Length < 3 || txtBody.Text.Length < 4)
            {
                UICommon.MsgBox("Content Too Short", "Sorry, the content of the Body or the Title must be longer.", this);
                return;
            }

            double nTicketNumber = BiblePayUtilities.GetNextTicketNumber(this);
            string sDisposition = Request.Form["dddispositions"] ?? "";
            string sAssignee= Request.Form["ddAssignees"] ?? "";
            BiblePayCommon.IBBPObject o = (BiblePayCommon.IBBPObject)BiblePayCommon.EntityCommon.GetInstance("BiblePayCommon.Entity+" + _EntityName);
            BiblePayCommon.EntityCommon.SetEntityValue(o, "Title", txtSubject.Text);
            BiblePayCommon.EntityCommon.SetEntityValue(o, "Body", txtBody.Text);
            BiblePayCommon.EntityCommon.SetEntityValue(o, "TicketNumber", (int)nTicketNumber);
            BiblePayCommon.EntityCommon.SetEntityValue(o, "id", Guid.NewGuid().ToString());
            BiblePayCommon.EntityCommon.SetEntityValue(o, "Disposition", "");
            BiblePayCommon.EntityCommon.SetEntityValue(o, "AssignedTo", "");
            BiblePayCommon.EntityCommon.SetEntityValue(o, "UserID", gUser(this).id);
            BiblePayCommon.Common.DACResult r = DataOps.InsertIntoTable(this, IsTestNet(this), o, gUser(this));

            if (r.fError())
               UICommon.MsgBox("Error while inserting object", "Sorry, the object was not saved: " + r.Error, this);

            Response.Redirect("TicketList");
        }
    }
}

