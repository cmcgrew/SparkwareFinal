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
using Newtonsoft.Json;


namespace SparkwareFinal.Fragments
{
    public class AchievementFragment : Android.Support.V4.App.Fragment
    {
        string myString = "";
        
        
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            
            // Create your fragment here
        }
      
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            
            View view = inflater.Inflate(Resource.Layout.achievement_page, container, false);

            //mUser = JsonConvert.DeserializeObject<User>(this.Activity.Intent.GetStringExtra("user"));
            var imageView = view.FindViewById<ImageView>(Resource.Id.imageView1);

            //mFragUtility.Arguments = utilBundle;
            //imageView.SetImageResource(Resource.Drawable.locks1);
            


            return view;
        }
    }
}