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
        View view;
        List<Innovation> filteredList;
        DiscoverListViewAdapter innovationAdapter;
        ListView mListView;
        Spinner discoverSpinner;
        Innovation innovation1;
        Innovation innovation2;
        Innovation innovation3;
        Innovation innovation4;
        Innovation innovation5;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            view = inflater.Inflate(Resource.Layout.discover_page, container, false);

            InstantiateVariables();

            mListView = view.FindViewById<ListView>(Resource.Id.discoverListView);

            discoverSpinner = view.FindViewById<Spinner>(Resource.Id.discoverSpinner);
            discoverSpinner.ItemSelected += spinner_ItemSelected;

            var adapter = ArrayAdapter.CreateFromResource(this.Context, Resource.Array.DiscoverFilter, Android.Resource.Layout.SimpleSpinnerItem);
            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            discoverSpinner.Adapter = adapter;

            filteredList = innovations;
            innovationAdapter = new DiscoverListViewAdapter(this.Activity, filteredList);

            mListView.Adapter = innovationAdapter;

            mListView.ItemClick += MListView_ItemClick;

            return view;
        }

        private void MListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            Toast.MakeText(this.Context, filteredList[e.Position].Title, ToastLength.Short).Show();
            Intent enrollmentActivity = new Intent(this.Context, typeof(EnrollmentActivity));
            //activity2.PutExtra("InnovationID", filteredList[e.Position].Id);
            StartActivity(enrollmentActivity);
        }

        private void spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            var spinner = sender as Spinner;
            filteredList = new List<Innovation>();

            if (spinner.GetItemAtPosition(e.Position).Equals("Most Popular"))
            {
                filteredList = innovations.OrderByDescending(x => x.NumberOfLikes).ToList();
                innovationAdapter.Update(filteredList);
                this.Activity.RunOnUiThread(() => innovationAdapter.NotifyDataSetChanged());
            }

            else if (spinner.GetItemAtPosition(e.Position).Equals("Newest"))
            {
                filteredList = innovations.OrderByDescending(x => x.CreationDate).ToList();
                innovationAdapter.Update(filteredList);
                this.Activity.RunOnUiThread(() => innovationAdapter.NotifyDataSetChanged());
            }

            else if (spinner.GetItemAtPosition(e.Position).Equals("Oldest"))
            {
                filteredList = innovations.OrderBy(x => x.CreationDate).ToList();
                innovationAdapter.Update(filteredList);
                this.Activity.RunOnUiThread(() => innovationAdapter.NotifyDataSetChanged());
            }

            else
            {
                //do nothing
            }
        }

        //private void DisplayInnovations(View view, List<Innovation> filteredList)
        //{
        //    List<LinearLayout> containers = new List<LinearLayout>();
        //    //containers.Clear();
        //    List<TextView> likeButton = new List<TextView>();
        //    //likeButton.Clear();
        //    bool[] likeButtonList = new bool[filteredList.Count];
        //    //Array.Clear(likeButtonList, 0, filteredList.Count);


        //    parent = view.FindViewById<LinearLayout>(Resource.Id.discoverLinearLayout);
        //    scrollView = new ScrollView(this.Context);
        //    LinearLayout.LayoutParams scrollParams = new LinearLayout.LayoutParams(LayoutParams.MatchParent, LayoutParams.MatchParent);
        //    scrollView.LayoutParameters = scrollParams;
        //    parent.AddView(scrollView);

        //    tableLayout = new TableLayout(this.Context);
        //    LinearLayout.LayoutParams tableParams = new LinearLayout.LayoutParams(LayoutParams.MatchParent, LayoutParams.MatchParent);
        //    tableLayout.LayoutParameters = tableParams;
        //    scrollView.AddView(tableLayout);

        //    for (int i = 0; i < filteredList.Count; i++)
        //    {
        //        likeButtonList[i] = false;
        //        // Created LinearLayout (Container for image, and text) 
        //        LinearLayout innovationContainer = new LinearLayout(this.Context);
        //        containers.Add(innovationContainer);
        //        containers[i].Orientation = Orientation.Horizontal;
        //        containers[i].SetBackgroundResource(Resource.Drawable.customshape);
        //        LinearLayout.LayoutParams containerParams = new LinearLayout.LayoutParams(LayoutParams.MatchParent, 450);
        //        containers[i].LayoutParameters = containerParams;
        //        containers[i].WeightSum = 100;


        //        tableLayout.AddView(containers[i]);

        //        ImageView innovationImageView = new ImageView(this.Context);
        //        LinearLayout.LayoutParams imageParams = new LinearLayout.LayoutParams(350, LayoutParams.MatchParent);
        //        imageParams.SetMargins(0, 0, 0, 25);
        //        innovationImageView.LayoutParameters = imageParams;
        //        innovationImageView.SetBackgroundResource(filteredList[i].ImageId);//Resource.Drawable.VoiceGuidedDeposits);
        //        innovationImageView.Visibility = ViewStates.Visible;

        //        containers[i].AddView(innovationImageView);

        //        LinearLayout innovationTextContainer = new LinearLayout(this.Context);
        //        innovationTextContainer.Orientation = Orientation.Vertical;
        //        LinearLayout.LayoutParams innovationTextContainerParams = new LinearLayout.LayoutParams(LayoutParams.MatchParent, LayoutParams.MatchParent);
        //        innovationTextContainerParams.SetMargins(25, 0, 0, 0);
        //        innovationTextContainer.LayoutParameters = innovationTextContainerParams;
        //        innovationTextContainer.WeightSum = 100;
        //        //innovationTextContainer.SetBackgroundColor(Color.Green);

        //        containers[i].AddView(innovationTextContainer);

        //        TextView innovationTitleTextView = new TextView(this.Context);
        //        innovationTitleTextView.SetTextColor(Color.Black);
        //        innovationTitleTextView.Text = filteredList[i].Title;
        //        innovationTitleTextView.SetTypeface(null, TypefaceStyle.Bold);
        //        innovationTitleTextView.SetTextSize(ComplexUnitType.Sp, 20.0f);

        //        innovationTextContainer.AddView(innovationTitleTextView);

        //        TextView innovationDescriptionTextView = new TextView(this.Context);
        //        innovationDescriptionTextView.SetTextColor(Color.Black);
        //        innovationDescriptionTextView.Text = filteredList[i].DescriptionShort;
        //        innovationDescriptionTextView.SetTextSize(ComplexUnitType.Sp, 15.0f);

        //        innovationTextContainer.AddView(innovationDescriptionTextView);

        //        TextView innovationContributorTextView = new TextView(this.Context);
        //        innovationContributorTextView.SetTextColor(Color.Black);
        //        LinearLayout.LayoutParams innovationContributorParams = new LinearLayout.LayoutParams(LayoutParams.MatchParent, LayoutParams.WrapContent);
        //        innovationContributorParams.TopMargin = 30;
        //        innovationContributorTextView.LayoutParameters = innovationContributorParams;
        //        innovationContributorTextView.Text = $"Contributor: {filteredList[i].Contributor}";
        //        innovationContributorTextView.SetTextSize(ComplexUnitType.Sp, 15.0f);

        //        innovationTextContainer.AddView(innovationContributorTextView);

        //        TextView likesTextView = new TextView(this.Context);
        //        innovationContributorTextView.SetTextColor(Color.Black);
        //        LinearLayout.LayoutParams likesParams = new LinearLayout.LayoutParams(LayoutParams.MatchParent, LayoutParams.WrapContent);
        //        likesParams.TopMargin = 80;
        //        likesTextView.LayoutParameters = likesParams;
        //        likesTextView.Text = $"Likes: {filteredList[i].NumberOfLikes.ToString()}";
        //        likesTextView.SetTextSize(ComplexUnitType.Sp, 15.0f);
        //        likeButton.Add(likesTextView);

        //        innovationTextContainer.AddView(likesTextView);

        //        //RatingBar ratingbar = new RatingBar(this.Context);
        //        //ratingbar.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.WrapContent, ViewGroup.LayoutParams.WrapContent);
        //        //ratingbar.Rating = 0;
        //        //ratingbar.NumStars = 5;
        //        //ratingbar.StepSize = 1.0f;
        //        //ratingbar.Visibility = ViewStates.Visible;
        //        //ratingbar.SetBackgroundColor(Color.Black);
        //        //ratingbar.RatingBarChange += (o, e) =>
        //        //{
        //        //    Toast.MakeText(this.Context, "New Rating: " + ratingbar.Rating.ToString(), ToastLength.Short).Show();
        //        //};

        //        //innovationTextContainer.AddView(ratingbar);
        //        var j = i;
        //        containers[j].Click += delegate
        //        {
        //            //Continer click code goes here
        //            Toast.MakeText(this.Context, "Title: " + filteredList[j].Title, ToastLength.Short).Show();
        //            selectedInnovaiton = filteredList[j];
        //            //var activity2 = new Intent(this, typeof(EnrollActivity));
        //            //activity2.PutExtra("MyData", "Data from Activity1");
        //            //StartActivity(activity2);
        //        };

        //        likeButton[j].Click += delegate
        //        {
        //            if (likeButtonList[j] == false)
        //            {
        //                filteredList[j].NumberOfLikes++;
        //                likeButtonList[j] = true;
        //                likeButton[j].Text = $"Likes: {filteredList[j].NumberOfLikes.ToString()}";
        //            }
        //            else
        //            {
        //                filteredList[j].NumberOfLikes--;
        //                likeButtonList[j] = false;
        //                likeButton[j].Text = $"Likes: {filteredList[j].NumberOfLikes.ToString()}";
        //            }
        //        };
        //    }
        //}

        private void InstantiateVariables()
        {
            innovations = new List<Innovation>();
            innovation1 = new Innovation();

            innovation1.Title = "Voice Guided Deposits";
            innovation1.Contributor = "USAA";
            innovation1.CreationDate = new DateTime(2017, 4, 9);
            innovation1.ImageId = (int)typeof(Resource.Drawable).GetField("VoiceGuidedDeposits").GetValue(null);
            innovation1.DescriptionShort = "Deposit a check through the USAA Mobile App using voice commands.";
            innovation1.DescriptionLong = "Depositing a check through the USAA Mobile App shouldn't be a complicated task, but for our visually impaired members it was nearly impossible. Now, voice commands guide members through the process, telling them to \"push out,\" \"pull in\" or \"move right\" to capture a check's image and deposit it into their account.";
            innovation1.NumberOfLikes = 2000;

            innovations.Add(innovation1);

            innovation2 = new Innovation();

            innovation2.Title = "This is innovation 2";
            innovation2.Contributor = "Chris McGrew";
            innovation2.CreationDate = new DateTime(2017, 2, 10);
            innovation2.ImageId = (int)typeof(Resource.Drawable).GetField("globe").GetValue(null);
            innovation2.DescriptionShort = "Innovation 2 short description";
            innovation2.DescriptionLong = "Innovation 2 short description";
            innovation2.NumberOfLikes = 1000;

            innovations.Add(innovation2);

            innovation3 = new Innovation();

            innovation3.Title = "This is innovation 3";
            innovation3.Contributor = "Melvin Montenegro";
            innovation3.CreationDate = new DateTime(2017, 4, 9);
            innovation3.ImageId = (int)typeof(Resource.Drawable).GetField("idea").GetValue(null);
            innovation3.DescriptionShort = "Innovation 3 short description";
            innovation3.DescriptionLong = "Innovation 3 short description";
            innovation3.NumberOfLikes = 10;

            innovations.Add(innovation3);

            innovation4 = new Innovation();

            innovation4.Title = "This is innovation 4";
            innovation4.Contributor = "Marete";
            innovation4.CreationDate = new DateTime(2016, 1, 12);
            innovation4.ImageId = (int)typeof(Resource.Drawable).GetField("Icon").GetValue(null);
            innovation4.DescriptionShort = "Innovation 4 short description";
            innovation4.DescriptionLong = "Innovation 4 short description";
            innovation4.NumberOfLikes = 1500;

            innovations.Add(innovation4);

            innovation5 = new Innovation();

            innovation5.Title = "This is innovation 5";
            innovation5.CreationDate = new DateTime(2016, 5, 11);
            innovation5.Contributor = "Abdul";
            innovation5.ImageId = (int)typeof(Resource.Drawable).GetField("home").GetValue(null);
            innovation5.DescriptionShort = "Innovation 5 short description";
            innovation5.DescriptionLong = "Innovation 5 long description";
            innovation5.NumberOfLikes = 500;

            innovations.Add(innovation5);
        }

        private void FilterResults()
        {

            //var query = from c in innovations
            //            orderby c.NumberOfLikes descending
            //            select c;

            //List<Innovation> filteredList = new List<Innovation>();
            //filteredList = query.ToList<Innovation>();

            // Clear List
            //filteredList.Clear();
        }
    }
}