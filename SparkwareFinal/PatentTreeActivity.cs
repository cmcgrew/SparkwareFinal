using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace SparkwareFinal
{
    [Activity(Label = "PatentTreeActivity")]
    public class PatentTreeActivity : Activity
    {
        List<Innovation> innovations;
        Innovation innovation1;
        Innovation innovation2;
        Innovation innovation3;
        Innovation innovation4;
        Innovation innovation5;
        List<Innovation> selectedInnovation;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            InstantiateVariables();
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.patenttreeinfo_page);

            //ImageView patentTreeImage = FindViewById<ImageView>(Resource.Id.patentTreeImage);
            //TextView patentTreeDescriptionLong = FindViewById<TextView>(Resource.Id.patentTreeDescriptionLong);

            //int innovationId = Intent.GetIntExtra("InnovationID", 0);

            //selectedInnovation = innovations.Where(x => x.Id == innovationId).ToList();

            //patentTreeImage.SetBackgroundResource(selectedInnovation[0].ImageId);
            //patentTreeDescriptionLong.Text = selectedInnovation[0].DescriptionLong;
        }

        private void InstantiateVariables()
        {
            innovations = new List<Innovation>();
            innovation1 = new Innovation();

            innovation1.Id = 1;
            innovation1.Title = "Voice Guided Deposits";
            innovation1.Contributor = "USAA";
            innovation1.CreationDate = new DateTime(2017, 4, 9);
            innovation1.ImageId = (int)typeof(Resource.Drawable).GetField("VoiceGuidedDeposits").GetValue(null);
            innovation1.DescriptionShort = "Deposit a check through the USAA Mobile App using voice commands.";
            innovation1.DescriptionLong = "Depositing a check through the USAA Mobile App shouldn't be a complicated task, but for our visually impaired members it was nearly impossible. Now, voice commands guide members through the process, telling them to \"push out,\" \"pull in\" or \"move right\" to capture a check's image and deposit it into their account.";
            innovation1.NumberOfLikes = 2000;

            innovations.Add(innovation1);

            innovation2 = new Innovation();

            innovation2.Id = 2;
            innovation2.Title = "This is innovation 2";
            innovation2.Contributor = "Chris McGrew";
            innovation2.CreationDate = new DateTime(2017, 2, 10);
            innovation2.ImageId = (int)typeof(Resource.Drawable).GetField("globe").GetValue(null);
            innovation2.DescriptionShort = "Innovation 2 short description";
            innovation2.DescriptionLong = "Innovation 2 short description";
            innovation2.NumberOfLikes = 1000;

            innovations.Add(innovation2);

            innovation3 = new Innovation();

            innovation3.Id = 3;
            innovation3.Title = "This is innovation 3";
            innovation3.Contributor = "Melvin Montenegro";
            innovation3.CreationDate = new DateTime(2017, 4, 9);
            innovation3.ImageId = (int)typeof(Resource.Drawable).GetField("idea").GetValue(null);
            innovation3.DescriptionShort = "Innovation 3 short description";
            innovation3.DescriptionLong = "Innovation 3 short description";
            innovation3.NumberOfLikes = 10;

            innovations.Add(innovation3);

            innovation4 = new Innovation();

            innovation4.Id = 4;
            innovation4.Title = "This is innovation 4";
            innovation4.Contributor = "Marete";
            innovation4.CreationDate = new DateTime(2016, 1, 12);
            innovation4.ImageId = (int)typeof(Resource.Drawable).GetField("Icon").GetValue(null);
            innovation4.DescriptionShort = "Innovation 4 short description";
            innovation4.DescriptionLong = "Innovation 4 short description";
            innovation4.NumberOfLikes = 1500;

            innovations.Add(innovation4);

            innovation5 = new Innovation();

            innovation5.Id = 5;
            innovation5.Title = "This is innovation 5";
            innovation5.CreationDate = new DateTime(2016, 5, 11);
            innovation5.Contributor = "Abdul";
            innovation5.ImageId = (int)typeof(Resource.Drawable).GetField("home").GetValue(null);
            innovation5.DescriptionShort = "Innovation 5 short description";
            innovation5.DescriptionLong = "Innovation 5 long description";
            innovation5.NumberOfLikes = 500;

            innovations.Add(innovation5);
        }
    }
}