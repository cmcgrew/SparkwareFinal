﻿using Android.App;
using Android.Widget;
using Android.OS;
using Android.Views;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Support.V4.App;
using SparkwareFinal.Fragments;
using SupportFragment = Android.Support.V4.App.Fragment;
using System.Collections.Generic;
using Plugin.Messaging;
using System.Net;
using Android.Content;
using Newtonsoft.Json;

using Android.Content;
namespace SparkwareFinal
{
    [Activity(Label = "SparkwareFinal")]
    public class MainActivity : AppCompatActivity
    {        
        //Variables for the different fragments(pages)
        private SupportFragment mCurrentFragment;
        private HomeFragment mHomeFragment;
        private DiscoverFragment mDiscoverFragment;
        private SubmitIdeaFragment mSubmitIdeaFragment;
        private MyAccountFragment mMyAccountFragment;
        private PatentTreeFragment mPatentTreeFragment;
        protected actEmail emailPage;

        private User mUser = new User();

        //This keeps track of the "stack" of pages so that the back button works correctly... bugs out if not used
        private Stack<SupportFragment> mStackFragment;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Instantiate Fragments
            mHomeFragment = new HomeFragment();
            mDiscoverFragment = new DiscoverFragment();
            mSubmitIdeaFragment = new SubmitIdeaFragment();
            mMyAccountFragment = new MyAccountFragment();
            mPatentTreeFragment = new PatentTreeFragment();

            mStackFragment = new Stack<SupportFragment>();

            
            //var varEmailPage = FindViewById<Toolbar>(Resource.Id.toolbar);
            //SetActionBar(varTopToolbar);
            //ActionBar.Title = "SPARKWARE"

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);

            var toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.Title = "Sparkware";

            // Transactions are needed to change between pages
            var trans = SupportFragmentManager.BeginTransaction();

            // Add fragment to the tranaction and hide it (only 1 is needed to be shown at a time, the last one)
            trans.Add(Resource.Id.fragmentContainer, mPatentTreeFragment, "PatentTreeFragment");
            trans.Hide(mPatentTreeFragment);

            trans.Add(Resource.Id.fragmentContainer, mMyAccountFragment, "MyAccountFragment");
            trans.Hide(mMyAccountFragment);

            trans.Add(Resource.Id.fragmentContainer, mSubmitIdeaFragment, "SubmitIdeaFragment");
            trans.Hide(mSubmitIdeaFragment);

            trans.Add(Resource.Id.fragmentContainer, mDiscoverFragment, "DiscoverFragment");
            trans.Hide(mDiscoverFragment);

            trans.Add(Resource.Id.fragmentContainer, mHomeFragment, "HomeFragment");

            //trans.Add(Resource.Id.fragmentContainer, emailPage, "ActivityEmail");

            // Show fragments
            trans.Commit();

            // Tracks the current fragment being shown, right now it is the home fragment
            mCurrentFragment = mHomeFragment;
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            //Display toolbar icons
            MenuInflater.Inflate(Resource.Menu.top_menus, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            var sendEmail = new Intent(this, typeof(actEmail));
                      if (item.ItemId == Resource.Id.idEmail)
                StartActivity(sendEmail);
            // Depending on which button is clicked, show that fragment
            switch (item.ItemId)
            {
                case Resource.Id.home:
                    ShowFragment(mHomeFragment);
                    SupportActionBar.Title = "Sparkware";
                    return true;
                case Resource.Id.discover:
                    ShowFragment(mDiscoverFragment);
                    SupportActionBar.Title = "Discover";
                    return true;
                case Resource.Id.submitidea:
                    //IList<string> users = Intent.GetStringArrayListExtra("users") ;
                   // Intent submitIdeaFragment = new Intent(this, typeof(SubmitIdeaFragment));
                   // submitIdeaFragment.PutStringArrayListExtra("users", (IList<string>)users);
                    ShowFragment(mSubmitIdeaFragment);
                    SupportActionBar.Title = "Submit Idea";
                    return true;
                case Resource.Id.account:
                    ShowFragment(mMyAccountFragment);
                    SupportActionBar.Title = "My Account";
                    return true;
                case Resource.Id.patentTree:
                    ShowFragment(mPatentTreeFragment);
                    SupportActionBar.Title = "Patent Tree";
                    return true;
                case Resource.Id.logout:
                    StartActivity(typeof(LoginActivity));
                    this.Finish();
                    return true;
                default:
                    return base.OnOptionsItemSelected(item);
            }
        }

        // Hides what ever fragment is currently showing and shows the new fragment and sets it to current fragment
        private void ShowFragment(SupportFragment fragment)
        {
            var trans = SupportFragmentManager.BeginTransaction();

            trans.Hide(mCurrentFragment);
            trans.Show(fragment);
            trans.AddToBackStack(null);
            trans.Commit();

            mStackFragment.Push(mCurrentFragment);
            mCurrentFragment = fragment;
        }

        // Manage when back button is pressed
        public override void OnBackPressed()
        {
            if (SupportFragmentManager.BackStackEntryCount > 0)
            {
                SupportFragmentManager.PopBackStack();
                mCurrentFragment = mStackFragment.Pop();
            }
            else
            {
                base.OnBackPressed();
            }
        }
    }
}

