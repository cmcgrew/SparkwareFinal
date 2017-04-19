using System;
using Android.OS;
using Android.Views;
using Android.Widget;
using Plugin.Messaging;// Add this and the one below to your processor directives
using System.Net;
using Android.App;
using Android.Content;

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
            
            Button submitIdeaButton = view.FindViewById<Button>(Resource.Id.btnSubmitIdea);
            submitIdeaButton.Click += SubmitIdeaButton_Click;

            Button checkConnectionButton = view.FindViewById<Button>(Resource.Id.btnCheckConnection);
            checkConnectionButton.Click += CheckConnectionButton_Click;
            return view;
        }

        protected void CheckConnectionButton_Click(object sender, EventArgs e)
        {
            CheckInternetConnection();
        }

        public bool CheckInternetConnection()
        {
            string CheckUrl = "http://google.com";

            try
            {
                HttpWebRequest iNetRequest = (HttpWebRequest)WebRequest.Create(CheckUrl);

                iNetRequest.Timeout = 5000;

                WebResponse iNetResponse = iNetRequest.GetResponse();
                Toast.MakeText(Activity, "...connection established..." + iNetRequest.ToString(), ToastLength.Long).Show();

                // Console.WriteLine ("...connection established..." + iNetRequest.ToString ());
                iNetResponse.Close();

                return true;

            }
            catch (WebException ex)
            {
                Toast.MakeText(Activity, ".....no connection..." + ex.ToString(), ToastLength.Long).Show();
                // Console.WriteLine (".....no connection..." + ex.ToString ());

                return false;
            }
        }

        private void SubmitIdeaButton_Click(object sender, EventArgs e)
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
            //SendEmail();
        }

              
    }
}