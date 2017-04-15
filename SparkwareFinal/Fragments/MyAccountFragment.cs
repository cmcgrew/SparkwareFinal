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
using Android.Support.V4.View;
using Android.Support.V4.App;
using Android.Graphics;
using Android.Graphics.Drawables;

namespace SparkwareFinal.Fragments
{
    public class MyAccountFragment : Android.Support.V4.App.Fragment
    {
        private FragmentTabHost mTabHost;
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            base.OnActivityCreated(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.myaccount_page, container, false);

            mTabHost = view.FindViewById<FragmentTabHost>(Resource.Id.tabhost); 

            mTabHost.Setup(this.Activity, ChildFragmentManager, Resource.Id.realtabcontent);

            mTabHost.AddTab(mTabHost.NewTabSpec("myaccount").SetIndicator("My Account"), Java.Lang.Class.FromType(typeof(SubmitIdeaFragment)), null);
            mTabHost.AddTab(mTabHost.NewTabSpec("submissions").SetIndicator("Submissions"), Java.Lang.Class.FromType(typeof(HomeFragment)), null);
            mTabHost.AddTab(mTabHost.NewTabSpec("badges").SetIndicator("Badges"), Java.Lang.Class.FromType(typeof(PatentTreeFragment)), null);

            return view;
        }
    }
}