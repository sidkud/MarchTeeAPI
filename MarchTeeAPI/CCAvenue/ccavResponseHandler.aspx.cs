using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Collections.Specialized;
using CCA.Util;
using System.Web.Mvc;

public partial class ResponseHandler : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string workingKey = "EC502629998AF6C0535CD7208E2E95FD";//put in the 32bit alpha numeric key in the quotes provided here
        CCACrypto ccaCrypto = new CCACrypto();
        string encResponse = ccaCrypto.Decrypt(Request.Form["encResp"], workingKey);
        NameValueCollection Params = new NameValueCollection();
        string[] segments = encResponse.Split('&');
        foreach (string seg in segments)
        {
            string[] parts = seg.Split('=');
            if (parts.Length > 0)
            {
                string Key = parts[0].Trim();
                string Value = parts[1].Trim();
                Params.Add(Key, Value);
            }
        }

        //for (int i = 0; i < Params.Count; i++)
        //{
        //    Response.Write(Params.Keys[i] + " = " + Params[i] + "<br>");
        //}

        if ((Params["order_status"] == null) || (Params["order_id"] == null))
        {
            // No order status found! What!
            //$this->cancelOrder( Mage::helper( 'ccavenue' )->__( 'The payment was cancelled because the order could not be found at checkout.' ) );
            //Mage_Core_Controller_Varien_Action::_redirect( 'checkout/onepage/failure', array( '_secure ' => true) );
            Response.Redirect("/Home/OrderCancel");
        }

        switch (Params["order_status"])
        {
            // Success!
            case "Success":
                // Payment was successful, so update the order's state, send order email and move to the success page
                //$order = Mage::getModel( 'sales/order' );
                //$order->loadByIncrementId( $responseArray['order_id'] );
                //$order->setState( Mage_Sales_Model_Order::STATE_PROCESSING, true, Mage::helper( 'ccavenue' )->__( 'Payment successful at CC Avenue.' ) );

                //$order->sendNewOrderEmail();
                //$order->setEmailSent( true );

                //$order->save();

                //Mage::getSingleton( 'checkout/session' )->unsQuoteId();

                //Mage_Core_Controller_Varien_Action::_redirect( 'checkout/onepage/success', array( '_secure' => true ) );
                break;

            // Unsuccessful
            case "Aborted":
            case "Failure":
            default:
                // CCAvenue has declined the payment, so cancel the order and redirect to fail page
                //$this->cancelOrder( Mage::helper( 'ccavenue' )->__( 'CC Avenue declined the payment.' ) );
                //Mage_Core_Controller_Varien_Action::_redirect( 'checkout/onepage/failure', array( '_secure' => true) );
                break;
        }
    }
}
