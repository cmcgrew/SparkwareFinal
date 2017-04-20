using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Security.Cryptography.X509Certificates;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Threading;
using System.ComponentModel;
using System.IO;
using Android.Graphics;
using System.Collections.Generic;
using Android.Content.PM;
using Android.Provider;
using Java.IO;
using Environment = Android.OS.Environment;
using Uri = Android.Net.Uri;
using System.Collections;
using System.Text;
using System.Drawing;

namespace SparkwareFinal
{
    [Activity(Label = "Email")]
    public class actEmail : Activity

    //    {
    //        protected override void OnCreate(Bundle bundle)
    //        {
    //            base.OnCreate(bundle);

    //            SetContentView(Resource.Layout.email_page);

    //            Button sendBtn = FindViewById<Button>(Resource.Id.myButton);//This was myButton

    //            sendBtn.Click += delegate
    //            {
    //                sendEmail();
    //            };
    //        }

    //        void sendEmail()
    //        {
    //            int imgId = Resource.Drawable.test;
    //            Bitmap bmpImg = BitmapFactory.DecodeResource(Resources, imgId);

    //            MemoryStream stream = new MemoryStream();
    //            bmpImg.Compress(Bitmap.CompressFormat.Png, 0, stream);
    //            byte[] bm = stream.ToArray();

    //            //write bytes back into the stream
    //            MemoryStream imageStream = new MemoryStream(bm);

    //            //Attachment constructor accepts three parameters, stream, imageName, and contentType
    //            Attachment image = new Attachment(imageStream, "test.png", "image/png");

    //            try
    //            {
    //                MailMessage mail = new MailMessage();
    //                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
    //                mail.From = new MailAddress("myemail@gmail.com");
    //                mail.To.Add("myBudsEmail@gmail.com");
    //                mail.Subject = "Email with an attachment";
    //                mail.Body = "Please see the attached picture";
    //                mail.Attachments.Add(image);
    //                SmtpServer.Port = 587;  //gmail default port
    //                SmtpServer.Credentials = new System.Net.NetworkCredential("myGmailUserName", "myGmailPassword");
    //                SmtpServer.EnableSsl = true;
    //                ServicePointManager.ServerCertificateValidationCallback = delegate (object sender, X509Certificate certificate, X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
    //                {
    //                    return true;
    //                };
    //                SmtpServer.Send(mail);
    //                Toast.MakeText(Application.Context, "Mail Sent Sucessufully", ToastLength.Short).Show();
    //            }

    //            catch (Exception ex)
    //            {
    //                Toast.MakeText(Application.Context, ex.ToString(), ToastLength.Long);
    //            }
    //        }

    //    }
    //}

    {
        protected override void OnCreate(Bundle bundle)
{
    base.OnCreate(bundle);

    // Create your application here

    // Set our view from the "main" layout resource

    SetContentView(Resource.Layout.email_page);

    var edtTo = FindViewById<EditText>(Resource.Id.edtTo);
    var edtSubject = FindViewById<EditText>(Resource.Id.edtSubject);
    var edtMessage = FindViewById<EditText>(Resource.Id.edtMessage);
    var btnSend = FindViewById<Button>(Resource.Id.btnSend);


    btnSend.Click += (s, e) =>
    {
        //This is the original code
        Intent email = new Intent(Intent.ActionSend);
        email.PutExtra(Intent.ExtraEmail, edtTo.Text.ToString());
        email.PutExtra(Intent.ExtraSubject, edtSubject.Text.ToString());
        email.PutExtra(Intent.ExtraText, edtMessage.Text.ToString());
        email.SetType("message/rfc822");

        StartActivity(Intent.CreateChooser(email, "Choose an Email client :"));
    };
}
}
}
