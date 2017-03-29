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
using Android.Graphics.Drawables;

namespace SparkwareFinal.Fragments
{
    public class DiscoverFragment : Android.Support.V4.App.Fragment
    {
        List<Innovation> innovations;
        TableLayout tableLayout;
        LinearLayout parent;
        ScrollView scrollView;
        Innovation innovation1;
        Innovation innovation2;
        Innovation innovation3;
        Innovation innovation4;
        Innovation innovation5;


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

            innovations.Add(innovation1);

            innovation2 = new Innovation();

            innovation2.Title = "This is innovation 2";
            innovation2.DescriptionShort = "Innovation 2 short description";
            innovation2.DescriptionLong = "Innovation 2 short description";
            innovation2.NumberOfLikes = 2000;

            innovations.Add(innovation2);

            innovation3 = new Innovation();

            innovation3.Title = "This is innovation 3";
            innovation3.DescriptionShort = "Innovation 3 short description";
            innovation3.DescriptionLong = "Innovation 3 short description";
            innovation3.NumberOfLikes = 2000;

            innovations.Add(innovation3);

            innovation4 = new Innovation();

            innovation4.Title = "This is innovation 4";
            innovation4.DescriptionShort = "Innovation 4 short description";
            innovation4.DescriptionLong = "Innovation 4 short description";
            innovation4.NumberOfLikes = 2000;

            innovations.Add(innovation4);

            innovation5 = new Innovation();

            innovation5.Title = "This is innovation 5";
            innovation5.DescriptionShort = "Innovation 5 short description";
            innovation5.DescriptionLong = "Innovation 5 short description";
            innovation5.NumberOfLikes = 2000;

            innovations.Add(innovation5);

            parent = view.FindViewById<LinearLayout>(Resource.Id.discoverLinearLayout);
            scrollView = new ScrollView(this.Context);
            LinearLayout.LayoutParams scrollParams = new LinearLayout.LayoutParams(LayoutParams.MatchParent, LayoutParams.MatchParent);
            scrollView.LayoutParameters = scrollParams;
            parent.AddView(scrollView);

            tableLayout = new TableLayout(this.Context);
            LinearLayout.LayoutParams tableParams = new LinearLayout.LayoutParams(LayoutParams.MatchParent, LayoutParams.MatchParent);
            tableLayout.LayoutParameters = tableParams;
            scrollView.AddView(tableLayout);

            DisplayInnovations();

            return view;
        }

        private void DisplayInnovations()
        {
            for (int i = 0; i < innovations.Count; i++)
            {
                // Created LinearLayout (Container for image, and text) 
                LinearLayout innovationContainer = new LinearLayout(this.Context);
                innovationContainer.Orientation = Orientation.Horizontal;
                innovationContainer.SetBackgroundResource(Resource.Drawable.customshape);
                LinearLayout.LayoutParams containerParams = new LinearLayout.LayoutParams(LayoutParams.MatchParent, 450);
                //containerParams.SetMargins(0, 0, 0, 1000);
                innovationContainer.LayoutParameters = containerParams;
                innovationContainer.WeightSum = 100;
                //innovationContainer.Id = 0;


                tableLayout.AddView(innovationContainer);

                ImageView innovationImageView = new ImageView(this.Context);
                LinearLayout.LayoutParams imageParams = new LinearLayout.LayoutParams(350, LayoutParams.MatchParent);
                imageParams.SetMargins(0, 0, 0, 25);
                innovationImageView.LayoutParameters = imageParams;
                innovationImageView.SetBackgroundResource(Resource.Drawable.VoiceGuidedDeposits);
                innovationImageView.Visibility = ViewStates.Visible;

                innovationContainer.AddView(innovationImageView);

                LinearLayout innovationTextContainer = new LinearLayout(this.Context);
                innovationTextContainer.Orientation = Orientation.Vertical;
                LinearLayout.LayoutParams innovationTextContainerParams = new LinearLayout.LayoutParams(LayoutParams.MatchParent, LayoutParams.MatchParent);
                innovationTextContainerParams.SetMargins(25, 0, 0, 0);
                innovationTextContainer.LayoutParameters = innovationTextContainerParams;
                innovationTextContainer.WeightSum = 100;
                //innovationTextContainer.SetBackgroundColor(Color.Green);

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

                RatingBar ratingbar = new RatingBar(this.Context);
                ratingbar.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.WrapContent, ViewGroup.LayoutParams.WrapContent);
                ratingbar.Rating = 0;
                ratingbar.NumStars = 5;
                ratingbar.StepSize = 1.0f;
                ratingbar.Visibility = ViewStates.Visible;
                ratingbar.SetBackgroundColor(Color.Black);
                ratingbar.RatingBarChange += (o, e) =>
                {
                    Toast.MakeText(this.Context, "New Rating: " + ratingbar.Rating.ToString(), ToastLength.Short).Show();
                };

                innovationTextContainer.AddView(ratingbar);
            }
        }
    }
}