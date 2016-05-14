﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CCA.Util;

public partial class SubmitData : System.Web.UI.Page
{
    CCACrypto ccaCrypto = new CCACrypto();
    //string workingKey = "EC502629998AF6C0535CD7208E2E95FD";//put in the 32bit alpha numeric key in the quotes provided here 	
    string workingKey = "30D4818D7945D862559039C8A3570AEA";//put in the 32bit alpha numeric key in the quotes provided here 	
    string ccaRequest = "";
    public string iframeSrc = "";
    public string strEncRequest = "";
    //public string strAccessCode = "AVCV65DE22AU77VCUA"; // put the access code in the quotes provided here.
    public string strAccessCode = "AVSA65DE27BB29ASBB"; // put the access code in the quotes provided here.

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            //Dictionary<string, string> trans = new Dictionary<string, string>();
            //trans["tid"] = DateTime.Now.Ticks.ToString();
            //trans["merchant_id"] = "98456";
            //trans["order_id"] = "123654789";
            //trans["amount"] = "1.00";
            //trans["currency"] = "INR";
            //trans["redirect_url"] = "http://localhost:3000/order";
            //trans["cancel_url"] = "http://localhost:3000/OrderCancel";
            //trans["billing_name"] = "Charli";
            //trans["billing_address"] = "Room no 1101, near Railway station Ambad";
            //trans["billing_city"] = "Indore";
            //trans["billing_state"] = "MP";
            //trans["billing_zip"] = "425001";
            //trans["billing_country"] = "India";
            //trans["billing_tel"] = "9896226054";
            //trans["billing_email"] = "test@gmail.com";
            //trans["delivery_name"] = "Chaplin";
            //trans["delivery_address"] = "room no.701 near bus stand";
            //trans["delivery_city"] = "Hyderabad";
            //trans["delivery_state"] = "Andhra";
            //trans["delivery_zip"] = "425001";
            //trans["delivery_country"] = "India";
            //trans["delivery_tel"] = "9896226054";
            ////trans["integration_type"] = "iframe_normal";
            //trans["promo_code"] = "";
            //trans["customer_identifier"] = "";
            //trans["submit"] = "Checkout";

            foreach (string name in Request.Form)
            {
                if (name != null)
                {
                    if (!name.StartsWith("_"))
                    {
                        ccaRequest = ccaRequest + name + "=" + HttpUtility.UrlEncode(Request.Form[name]) + "&";
                        //Response.Write(name + "=" + Request.Form[name]);
                        //Response.Write("</br>");
                    }
                }
            }

            //foreach (KeyValuePair<string, string> kvp in trans)
            //{
            //    if (kvp.Key != null)
            //    {
            //        if (!kvp.Key.StartsWith("_"))
            //        {
            //            ccaRequest = ccaRequest + kvp.Key + "=" + HttpUtility.UrlEncode(kvp.Value) + "&";
            //            //Response.Write(name + "=" + Request.Form[name]);
            //            //Response.Write("</br>");
            //        }
            //    }
            //}

            strEncRequest = ccaCrypto.Encrypt(ccaRequest, workingKey);

            //iframeSrc = "https://test.ccavenue.com/transaction/transaction.do?command=initiateTransaction&encRequest=" + strEncRequest + "&access_code=" + strAccessCode;

            iframeSrc = string.Format("{0}?command={1}&encRequest={2}&access_code={3}",
                "https://secure.ccavenue.com/transaction/transaction.do",
                "initiateTransaction",
                strEncRequest,
                strAccessCode,
                "JSON",
                "1.1");
        }
    }
}
