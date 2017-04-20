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
            var btnPicSend = FindViewById<Button>(Resource.Id.btnPicSend);

            btnPicSend.Click += (s, e) =>
            {
                //This is the original code
                Intent email = new Intent(Intent.ActionSend);
                email.PutExtra(Intent.ExtraEmail, edtTo.Text.ToString());
                email.PutExtra(Intent.ExtraSubject, edtSubject.Text.ToString());
                email.PutExtra(Intent.ExtraText, edtMessage.Text.ToString());
                email.SetType("message/rfc822");

                StartActivity(Intent.CreateChooser(email, "Choose an Email client :"));
            };


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
