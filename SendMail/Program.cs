using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Twilio;
using Twilio.Types;
using Twilio.Rest.Api.V2010.Account;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace SendMail
{
    class Program
    {
     
        static void Main(string[] args)
        {
          //  SendSMSTwiloSample();
            //SendSMS();
            //SendGridMail();
           // sendgridMailTest();
            SendEmail();
            //Test();
        }
        public static void SendSMSTwiloSample()
        {
            string accountSid = "AC1c58148508f9ee9ab57417cbc567a590";
            string authToken = "b44f390b69d505cb1fb16be244c32e49";

            TwilioClient.Init(accountSid, authToken);

            var message = MessageResource.Create(
                body: "is registered successfully.",
                from: new Twilio.Types.PhoneNumber("+18053035636"),
                to: new Twilio.Types.PhoneNumber("+919930666595")
            );

            Console.WriteLine(message.Sid);
        }
        public static void Test()
        {
            var apiKey = "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";
            
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("rajneeshazure@gmail.com", "TestAPIData");
            var subject = "Sending with SendGrid is Fun";
            var to = new EmailAddress("rajneeshazure@gmail.com", "TestAPIData");
            var plainTextContent = "and easy to do anywhere, even with C#";
            var htmlContent = "<strong>and easy to do anywhere, even with C#</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            client.SendEmailAsync(msg);
        }



        //public static void sendgridMailTest()
        //{
        //    string apiKey = "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";

        //    var client = new SendGridClient(apiKey);
        //    ////send an email message using the SendGrid Web API with a console application.  
        //    var msgs = new SendGridMessage()
        //    {
        //        From = new EmailAddress("pankaj.sapkal@xxx.com", "Pankaj Sapkal"),
        //        Subject = "Subject line",
        //        TemplateId = "fb09a5fb-8bc3-4183-b648-dc6d48axxxxx",
        //        ////If you have html ready and dont want to use Template's   
        //        //PlainTextContent = "Hello, Email!",  
        //        //HtmlContent = "<strong>Hello, Email!</strong>",  
        //    };
        //    //if you have multiple reciepents to send mail  
        //    msgs.AddTo(new EmailAddress("pankaj.sapkal@xxx.com", "Pankaj Sapkal"));
        //    //If you have attachment  
        //    var attach = new SendGrid.Helpers.Mail.Attachment();
        //    //attach.Content = Convert.ToBase64String("rawValues");  
        //    attach.Type = "image/png";
        //    attach.Filename = "hulk.png";
        //    attach.Disposition = "inline";
        //    attach.ContentId = "hulk2";
        //    //msgs.AddAttachment(attach.Filename, attach.Content, attach.Type, attach.Disposition, attach.ContentId);  
        //    //Set footer as per your requirement  
        //    msgs.SetFooterSetting(true, "<strong>Regards,</strong><b> Pankaj Sapkal", "Pankaj");
        //    //Tracking (Appends an invisible image to HTML emails to track emails that have been opened)  
        //    //msgs.SetClickTracking(true, true);  
        //    client.SendEmailAsync(msgs);
        //}

        //public static void SendGridMail()
        //{
        //    string _apiKey = "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";
        //    string _fromEmail = "hajela.rajneeshprakash@gmail.com";
        //    string _fromName = "teST";
        //    string email = "Hajela.rajneesh@gmail.com";

        //    SendGridMessage sendGridMessage = new SendGridMessage();
        //    sendGridMessage.
        //    sendGridMessage.From = new EmailAddress(_fromEmail, _fromName);
        //    sendGridMessage.AddTo(new EmailAddress(email));
        //    sendGridMessage.Subject = subject;
        //    sendGridMessage.HtmlContent = "Test Mail";// isHtml ? message : "";
        //    sendGridMessage.PlainTextContent = "Test Mail";// isHtml ? Regex.Replace(message, "<[^>]*>", "") : message;

        //    var client = new SendGridClient(_apiKey);
        //    client.SendEmailAsync(sendGridMessage);
        //}
        public static void SendSMS()
        {
            // Find your Account Sid and Auth Token at twilio.com/user/account
            const string accountSid = "AC1c58148508f9ee9ab57417cbc567a590";
            const string authToken = "b44f390b69d505cb1fb16be244c32e49";
            TwilioClient.Init(accountSid, authToken);

            var to = new PhoneNumber("+91" + 9930666595);
            var message = MessageResource.Create(
                to,
                from: new PhoneNumber("+18053035636"), //  From number, must be an SMS-enabled Twilio number ( This will send sms from ur "To" numbers ).
                body: $"Hello Rajneesh !! Welcome to Asp.Net Core With Twilio SMS API !!");

            //ModelState.Clear();
            //ViewBag.SuccessMessage = "Registered Successfully !!";
        }

        public static void SendEmail()
        {

            string strvalue = "<div class='container'> <div class='col-md-9'>        <div class='row'>            <div class='col-md-7'>                <h5>Order detail 5 - New</h5>            </div>            <div class='col-md-5 text-right'>                Order date 2/6/2021 5:42:02 PM</div>        </div>        <div class='row mt-4'>            <div class='col-md-4'><strong>Shipping address</strong></div>            <div class='col-md-4'><strong>Shipping method</strong></div>            <div class='col-md-4'><strong>Payment method</strong></div>        </div>        <div class='row'>            <div class='col-md-4'>                <strong>rajneesh</strong> <br />                202, B Wing, Green AVenue,, Thane Shil Road, Old Mumbai Pune Highway, Near Dutt Mandir<br />                Thane, Washington, 421204 <br />                Phone: 09930666595            </div>            <div class='col-md-4'>Free</div>            <div class='col-md-4'>CashOnDelivery</div>        </div>        <table class='table table-borerless mt-4'>            <thead>                <tr>                    <th class='pl-0'>Product</th>                    <th class='text-right'>Price</th>                    <th class='text-right'>Quantity</th>                    <th class='text-right'>Discount</th>                    <th class='text-right text-nowrap pr-0'>Row Total</th>                </tr>            </thead>            <tbody>                    <tr>                        <td class='pl-0'>                            <div class='row'>                                <div class='col-md-3'>                                           </div>                                <div class='col-md-9'>                                    <p>Square Neck Back Silver S</p>                                    <p>Quantity 2</p>                                </div>                            </div>                        </td>                        <td class='text-right'>₹29.64</td>                        <td class='text-right'>2</td>                        <td class='text-right'>₹0.00</td>                        <td class='text-right pr-0'>₹59.28</td>                    </tr>            </tbody>        </table>        <div class='row'>            <div class='col-md-6'></div>            <div class='col-md-6'>                <table class='table table-borderless'>                    <tr>                        <td>Subtotal</td>                        <td class='text-right pr-0'>₹59.28</td>                    </tr>                    <tr>                        <td>Shipping</td>                        <td class='text-right pr-0'>₹0.00</td>                    </tr>                    <tr>                        <td>Tax</td>                        <td class='text-right pr-0'>₹0.00</td>                    </tr>                    <tr>                        <td>Discount</td>                        <td class='text-right pr-0'>₹0.00</td>                    </tr>                   <tr>                        <td>Payment Fee</td>                        <td class='text-right pr-0'>₹0.00</td>                    </tr>                    <tr>                        <td><strong>Order Total</strong></td>                        <td class='text-right pr-0'><strong>₹59.28</strong></td>                    </tr>                </table>            </div>        </div>    </div></div></div>";


         
             string smtpAddress = "smtp.gmail.com";
             int portNumber = 587;
             bool enableSSL = true;

             string emailFromAddress = "hajela.rajneesh@gmail.com";//Sender Email Address
             string password = "Rinku@123";//Sender Password
             string emailToAddress = "hajela.rajneeshprakash@gmail.com";//Receiver Email Address
             string subject = "Hello";
             string body = strvalue;

            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress(emailFromAddress);
                mail.To.Add(emailToAddress);
                mail.Subject = subject;
                mail.Body = body;
                mail.IsBodyHtml = true;
                //mail.Attachments.Add(new Attachment("D:\\TestFile.txt"));//--Uncomment this to send any attachment

                using (SmtpClient smtp = new SmtpClient(smtpAddress, portNumber))
                {
                    smtp.Credentials = new NetworkCredential(emailFromAddress, password);
                    smtp.EnableSsl = enableSSL;
                    smtp.Send(mail);
                }
            }

            //string accountSid = "AC1c58148508f9ee9ab57417cbc567a590";
            //string authToken = "b44f390b69d505cb1fb16be244c32e49";

            //TwilioClient.Init(accountSid, authToken);

            //var message = MessageResource.Create(
            //    body: "is registered successfully.",
            //    from: new Twilio.Types.PhoneNumber("+18053035636"),
            //    to: new Twilio.Types.PhoneNumber("+919930666595")
            //);

        }

    }
}
