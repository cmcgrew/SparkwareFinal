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
            enrollmentActivity.PutExtra("InnovationID", filteredList[e.Position].Id);
            StartActivity(enrollmentActivity);
        }

        private void spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            var spinner = sender as Spinner;
            filteredList = new List<Innovation>();
            InstantiateVariables();
            filteredList = innovations;

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
            else if (spinner.GetItemAtPosition(e.Position).Equals("Oldest"))
            {
                filteredList = innovations.OrderBy(x => x.CreationDate).ToList();
                innovationAdapter.Update(filteredList);
                this.Activity.RunOnUiThread(() => innovationAdapter.NotifyDataSetChanged());
            }
            else if (spinner.GetItemAtPosition(e.Position).Equals("USAA Innovations"))
            {
                filteredList = innovations.Where(x => x.Contributor == "USAA").ToList();
                innovationAdapter.Update(filteredList);
                this.Activity.RunOnUiThread(() => innovationAdapter.NotifyDataSetChanged());
            }
            else if (spinner.GetItemAtPosition(e.Position).Equals("Member Innovations"))
            {
                filteredList = innovations.Where(x => x.Contributor != "USAA").ToList();
                innovationAdapter.Update(filteredList);
                this.Activity.RunOnUiThread(() => innovationAdapter.NotifyDataSetChanged());
            }
            else
            {
                //do nothing
            }
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