using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Android.Support.V4.App;
using static Android.Support.V4.View.ViewPager;
using Android.Graphics;

namespace SparkwareFinal.Fragments
{
    public class DiscoverFragment : Android.Support.V4.App.Fragment
    {
        List<Innovation> innovations;
        Innovation innovation1;
        Innovation innovation2;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.discover_page, container, false);

            innovations = new List<Innovation>();
            innovation1 = new Innovation();

            innovation1.Title = "Voice Guided Deposits";
            innovation1.DescriptionShort = "Deposit a check through the USAA Mobile App using voice commands.";
            innovation1.DescriptionLong = "Depositing a check through the USAA Mobile App shouldn't be a complicated task, but for our visually impaired members it was nearly impossible. Now, voice commands guide members through the process, telling them to \"push out,\" \"pull in\" or \"move right\" to capture a check's image and deposit it into their account.";
            innovation1.NumberOfLikes = 2000;

            innovation2 = new Innovation();

            innovation2.Title = "This is innovation 2";
            innovation2.DescriptionShort = "Innovation 2 short description";
            innovation2.DescriptionLong = "Innovation 2 short description";
            innovation2.NumberOfLikes = 2000;

            innovations.Add(innovation2);

            LinearLayout parent = view.FindViewById<LinearLayout>(Resource.Id.discoverLinearLayout);
            //LinearLayout innovationContainer = new LinearLayout(this.Context);
            //innovationContainer.Orientation = Orientation.Horizontal;
            //innovationContainer.SetBackgroundResource(Resource.Drawable.customshape);
            //LinearLayout.LayoutParams containerParams = new LinearLayout.LayoutParams(LayoutParams.MatchParent, 450);
            //innovationContainer.LayoutParameters = containerParams;
            //innovationContainer.WeightSum = 100;
            //innovationContainer.Id = 0;

            //LinearLayout innovationContainer2 = new LinearLayout(this.Context);
            //innovationContainer2.Orientation = Orientation.Horizontal;
            //innovationContainer2.SetBackgroundResource(Resource.Drawable.customshape);
            //LinearLayout.LayoutParams containerParams2 = new LinearLayout.LayoutParams(LayoutParams.MatchParent, 450);
            //innovationContainer2.LayoutParameters = containerParams;
            //innovationContainer2.WeightSum = 100;
            //innovationContainer2.Id = 1;

            //parent.AddView(innovationContainer2);


            //parent.AddView(innovationContainer);
            for (int i = 0; i < innovations.Count; i++)
            {
                // Created LinearLayout (Container for image, and text) 
                LinearLayout innovationContainer = new LinearLayout(this.Context);
                innovationContainer.Orientation = Orientation.Horizontal;
                innovationContainer.SetBackgroundResource(Resource.Drawable.customshape);
                LinearLayout.LayoutParams containerParams = new LinearLayout.LayoutParams(LayoutParams.MatchParent, 450);
                innovationContainer.LayoutParameters = containerParams;
                innovationContainer.WeightSum = 100;
                innovationContainer.Id = 0;


                parent.AddView(innovationContainer);

                ImageView innovationImageView = new ImageView(this.Context);
                LinearLayout.LayoutParams imageParams = new LinearLayout.LayoutParams(350, 350);
                imageParams.Gravity = GravityFlags.Center;
                innovationImageView.LayoutParameters = imageParams;
                innovationImageView.SetBackgroundResource(Resource.Drawable.VoiceGuidedDeposits);
                //innovationImageView.SetPadding(10, 10, 10, 10);
                innovationImageView.Visibility = ViewStates.Visible;

                innovationContainer.AddView(innovationImageView);

                LinearLayout innovationTextContainer = new LinearLayout(this.Context);
                innovationTextContainer.Orientation = Orientation.Vertical;
                LinearLayout.LayoutParams innovationTextContainerParams = new LinearLayout.LayoutParams(LayoutParams.MatchParent, LayoutParams.MatchParent);
                innovationTextContainer.LayoutParameters = innovationTextContainerParams;
                innovationTextContainer.WeightSum = 100;
                innovationTextContainer.SetBackgroundColor(Color.Green);

                innovationContainer.AddView(innovationTextContainer);

                TextView innovationTitleTextView = new TextView(this.Context);
                innovationTitleTextView.SetTextColor(Color.Black);
                innovationTitleTextView.Text = innovations[i].Title;
                innovationTitleTextView.SetTypeface(null, TypefaceStyle.Bold);
                innovationTitleTextView.SetTextSize(ComplexUnitType.Sp, 20.0f);

                innovationTextContainer.AddView(innovationTitleTextView);

                TextView innovationDescriptionTextView = new TextView(this.Context);
                innovationDescriptionTextView.SetTextColor(Color.Black);
                innovationDescriptionTextView.Text = innovations[i].DescriptionShort;
                innovationDescriptionTextView.SetTextSize(ComplexUnitType.Sp, 15.0f);

                innovationTextContainer.AddView(innovationDescriptionTextView);

                TextView innovationLikesTitleTextView = new TextView(this.Context);
                innovationLikesTitleTextView.SetTextColor(Color.Black);
                LinearLayout.LayoutParams likesTitleParams = new LinearLayout.LayoutParams(350, 350);
                likesTitleParams.Gravity = GravityFlags.Bottom;
                innovationLikesTitleTextView.LayoutParameters = likesTitleParams;
                innovationLikesTitleTextView.Text = "Likes";
                innovationLikesTitleTextView.SetTextSize(ComplexUnitType.Sp, 15.0f);

                innovationTextContainer.AddView(innovationLikesTitleTextView);
            }

            return view;
        }
    }
}