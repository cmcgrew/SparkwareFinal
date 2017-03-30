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

using Xamarin.Android;

namespace SparkwareFinal.Fragments
{
    public class SubmitIdeaFragment : Android.Support.V4.App.Fragment
    {
        
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
                
             
        
            
            // Create your fragment here

        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.submitidea_page, container, false);
            
            Button submitIdeaButton = view.FindViewById<Button>(Resource.Id.btnSubmitFeedback);
            submitIdeaButton.Click += SubmitIdeaButon_Click;
            
            return view;

        }

        private void SubmitIdeaButon_Click(object sender, EventArgs e)
        {
           // ImageView badge1 = new ImageView(Activity);
            //badge1  
            AlertDialog.Builder alert = new AlertDialog.Builder(Activity);
            AlertDialog myAlert = alert.Create();
            myAlert.SetTitle("Badge Earned!");
            myAlert.SetMessage("First feedback badge earned!");
            myAlert.SetIcon(Resource.Drawable.badge1);
            myAlert.SetButton("Awesome!", (s, ev) =>
            {
                Toast.MakeText(Activity, "Badge Earned!", ToastLength.Long).Show();
            });

            myAlert.Show();
        }
    }

}