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
using Android.Graphics;
using Android.Graphics.Drawables;

namespace SparkwareFinal.Fragments
{
    public class MyAccountFragment : Android.Support.V4.App.Fragment
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        //public override void OnActivityCreated(Bundle savedInstanceState)
        //{
        //    base.OnActivityCreated(savedInstanceState);

        //    Activity activity = this.Activity;
        //    ActionBar actionBar = activity.ActionBar;
        //    var colorDrawable = new ColorDrawable(Color.Coral);
        //    //activity.ActionBar.SetBackgroundDrawable(colorDrawable);

        //    var titleId = activity.Resources.GetIdentifier("action_bar_title", "id", "android");
        //    var abTitle = activity.FindViewById<TextView>(titleId);
        //    abTitle.SetTextColor(Color.Black);
        //}

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.myaccount_page, container, false);

            return view;
        }
    }
}