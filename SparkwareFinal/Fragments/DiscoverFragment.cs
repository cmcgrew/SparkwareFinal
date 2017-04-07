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
        List<LinearLayout> containers;
        List<TextView> likeButton;
        bool[] likeButtonList;
        //bool likeClicked;
        TableLayout tableLayout;
        LinearLayout parent;
        ScrollView scrollView;
        Innovation innovation1;
        Innovation innovation2;
        Innovation innovation3;
        Innovation innovation4;
        Innovation innovation5;
        Innovation selectedInnovaiton;


        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.discover_page, container, false);

            

            InstantiateVariables();

            //For DropDown list https://developer.xamarin.com/api/type/Xamarin.Forms.Picker/

            DisplayInnovations(view);






            return view;
        }

        private void DisplayInnovations(View view)
        {
            containers = new List<LinearLayout>();
            likeButton = new List<TextView>();
            likeButtonList = new bool[innovations.Count];


            parent = view.FindViewById<LinearLayout>(Resource.Id.discoverLinearLayout);
            scrollView = new ScrollView(this.Context);
            LinearLayout.LayoutParams scrollParams = new LinearLayout.LayoutParams(LayoutParams.MatchParent, LayoutParams.MatchParent);
            scrollView.LayoutParameters = scrollParams;
            parent.AddView(scrollView);

            tableLayout = new TableLayout(this.Context);
            LinearLayout.LayoutParams tableParams = new LinearLayout.LayoutParams(LayoutParams.MatchParent, LayoutParams.MatchParent);
            tableLayout.LayoutParameters = tableParams;
            scrollView.AddView(tableLayout);

            tableLayout.RemoveAllViews();

            for (int i = 0; i < innovations.Count; i++)
            {
                likeButtonList[i] = false;
                // Created LinearLayout (Container for image, and text) 
                LinearLayout innovationContainer = new LinearLayout(this.Context);
                containers.Add(innovationContainer);
                containers[i].Orientation = Orientation.Horizontal;
                containers[i].SetBackgroundResource(Resource.Drawable.customshape);
                LinearLayout.LayoutParams containerParams = new LinearLayout.LayoutParams(LayoutParams.MatchParent, 450);
                containers[i].LayoutParameters = containerParams;
                containers[i].WeightSum = 100;


                tableLayout.AddView(containers[i]);

                ImageView innovationImageView = new ImageView(this.Context);
                LinearLayout.LayoutParams imageParams = new LinearLayout.LayoutParams(350, LayoutParams.MatchParent);
                imageParams.SetMargins(0, 0, 0, 25);
                innovationImageView.LayoutParameters = imageParams;
                innovationImageView.SetBackgroundResource(innovations[i].ImageId);//Resource.Drawable.VoiceGuidedDeposits);
                innovationImageView.Visibility = ViewStates.Visible;

                containers[i].AddView(innovationImageView);

                LinearLayout innovationTextContainer = new LinearLayout(this.Context);
                innovationTextContainer.Orientation = Orientation.Vertical;
                LinearLayout.LayoutParams innovationTextContainerParams = new LinearLayout.LayoutParams(LayoutParams.MatchParent, LayoutParams.MatchParent);
                innovationTextContainerParams.SetMargins(25, 0, 0, 0);
                innovationTextContainer.LayoutParameters = innovationTextContainerParams;
                innovationTextContainer.WeightSum = 100;
                //innovationTextContainer.SetBackgroundColor(Color.Green);

                containers[i].AddView(innovationTextContainer);

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

                TextView innovationContributorTextView = new TextView(this.Context);
                innovationContributorTextView.SetTextColor(Color.Black);
                LinearLayout.LayoutParams innovationContributorParams = new LinearLayout.LayoutParams(LayoutParams.MatchParent, LayoutParams.WrapContent);
                innovationContributorParams.TopMargin = 30;
                innovationContributorTextView.LayoutParameters = innovationContributorParams;
                innovationContributorTextView.Text = $"Contributor: {innovations[i].Contributor}";
                innovationContributorTextView.SetTextSize(ComplexUnitType.Sp, 15.0f);

                innovationTextContainer.AddView(innovationContributorTextView);

                TextView likesTextView = new TextView(this.Context);
                innovationContributorTextView.SetTextColor(Color.Black);
                LinearLayout.LayoutParams likesParams = new LinearLayout.LayoutParams(LayoutParams.MatchParent, LayoutParams.WrapContent);
                likesParams.TopMargin = 80;
                likesTextView.LayoutParameters = likesParams;
                likesTextView.Text = $"Likes: {innovations[i].NumberOfLikes.ToString()}";
                likesTextView.SetTextSize(ComplexUnitType.Sp, 15.0f);
                likeButton.Add(likesTextView);

                innovationTextContainer.AddView(likesTextView);

                //RatingBar ratingbar = new RatingBar(this.Context);
                //ratingbar.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.WrapContent, ViewGroup.LayoutParams.WrapContent);
                //ratingbar.Rating = 0;
                //ratingbar.NumStars = 5;
                //ratingbar.StepSize = 1.0f;
                //ratingbar.Visibility = ViewStates.Visible;
                //ratingbar.SetBackgroundColor(Color.Black);
                //ratingbar.RatingBarChange += (o, e) =>
                //{
                //    Toast.MakeText(this.Context, "New Rating: " + ratingbar.Rating.ToString(), ToastLength.Short).Show();
                //};

                //innovationTextContainer.AddView(ratingbar);
                var j = i;
                containers[j].Click += delegate
                {
                    //Continer click code goes here
                    Toast.MakeText(this.Context, "Title: " + innovations[j].Title, ToastLength.Short).Show();
                    selectedInnovaiton = innovations[j];
                    //var activity2 = new Intent(this, typeof(EnrollActivity));
                    //activity2.PutExtra("MyData", "Data from Activity1");
                    //StartActivity(activity2);
                };

                likeButton[j].Click += delegate
                {
                    if (likeButtonList[j] == false)
                    {
                        innovations[j].NumberOfLikes++;
                        likeButtonList[j] = true;
                        likeButton[j].Text = $"Likes: {innovations[j].NumberOfLikes.ToString()}";
                    }
                    else
                    {
                        innovations[j].NumberOfLikes--;
                        likeButtonList[j] = false;
                        likeButton[j].Text = $"Likes: {innovations[j].NumberOfLikes.ToString()}";
                    }
                };
            }
        }

        private void InstantiateVariables()
        {
            innovations = new List<Innovation>();
            innovation1 = new Innovation();

            innovation1.Title = "Voice Guided Deposits";
            innovation1.Contributor = "USAA";
            innovation1.ImageId = (int)typeof(Resource.Drawable).GetField("VoiceGuidedDeposits").GetValue(null);
            innovation1.DescriptionShort = "Deposit a check through the USAA Mobile App using voice commands.";
            innovation1.DescriptionLong = "Depositing a check through the USAA Mobile App shouldn't be a complicated task, but for our visually impaired members it was nearly impossible. Now, voice commands guide members through the process, telling them to \"push out,\" \"pull in\" or \"move right\" to capture a check's image and deposit it into their account.";
            innovation1.NumberOfLikes = 2000;

            innovations.Add(innovation1);

            innovation2 = new Innovation();

            innovation2.Title = "This is innovation 2";
            innovation2.Contributor = "Chris McGrew";
            innovation2.ImageId = (int)typeof(Resource.Drawable).GetField("globe").GetValue(null);
            innovation2.DescriptionShort = "Innovation 2 short description";
            innovation2.DescriptionLong = "Innovation 2 short description";
            innovation2.NumberOfLikes = 2000;

            innovations.Add(innovation2);

            innovation3 = new Innovation();

            innovation3.Title = "This is innovation 3";
            innovation3.Contributor = "Melvin Montenegro";
            innovation3.ImageId = (int)typeof(Resource.Drawable).GetField("idea").GetValue(null);
            innovation3.DescriptionShort = "Innovation 3 short description";
            innovation3.DescriptionLong = "Innovation 3 short description";
            innovation3.NumberOfLikes = 1000;

            innovations.Add(innovation3);

            innovation4 = new Innovation();

            innovation4.Title = "This is innovation 4";
            innovation4.Contributor = "Marete";
            innovation4.ImageId = (int)typeof(Resource.Drawable).GetField("Icon").GetValue(null);
            innovation4.DescriptionShort = "Innovation 4 short description";
            innovation4.DescriptionLong = "Innovation 4 short description";
            innovation4.NumberOfLikes = 1000;

            innovations.Add(innovation4);

            innovation5 = new Innovation();

            innovation5.Title = "This is innovation 5";
            innovation5.Contributor = "Abdul";
            innovation5.ImageId = (int)typeof(Resource.Drawable).GetField("home").GetValue(null);
            innovation5.DescriptionShort = "Innovation 5 short description";
            innovation5.DescriptionLong = "Innovation 5 long description";
            innovation5.NumberOfLikes = 2000;

            innovations.Add(innovation5);
        }

        private void FilterResults()
        {

            var query = from c in innovations
                        orderby c.NumberOfLikes descending
                        select c;

            List<Innovation> filteredList = new List<Innovation>();
            filteredList = query.ToList<Innovation>();

            // Clear List
            //filteredList.Clear();
        }
    }
}