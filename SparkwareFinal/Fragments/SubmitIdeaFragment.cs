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
            submitIdeaButton.Click += SubmitIdeaButon_Click;


            
            return view;

        }


        //I have commented out this portion because we know it works
        //Need to know if we can send emails
        private void SubmitIdeaButon_Click(object sender, EventArgs e)
        {
            ImageView badge1 = new ImageView(Activity);
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
            SendEmail();
        }

        private void SendEmail()
        {
            var emailTask = MessagingPlugin.EmailMessenger;

            if (emailTask.CanSendEmail)//This keeps evaluating to false. Can't figure out why
            {
                // Send simple e-mail to single receiver without attachments, CC, or BCC.
                emailTask.SendEmail("maretemugambi@gmail.com", "Xamarin Messaging Plugin", "Hello from your friends at Xamarin!");
                // emailTask.SetType("message/rfc822");
                {
                    Toast.MakeText(Activity, "Email Sent!", ToastLength.Long).Show();
                };

                // Send a more complex email with the EmailMessageBuilder fluent interface.
                //var email = new EmailMessageBuilder()
                //  .To("maretemugambi@gmail.com")
                //  .Cc("")
                //  .Bcc(new[] {" "})
                //  .Subject("Xamarin Messaging Plugin")
                //  .Body("Hello from your friends at Xamarin!")
                //  .Build();

                //emailTask.SendEmail(email);
            }
            else
            {
                {
                    Toast.MakeText(Activity, "Email Not Sent!", ToastLength.Long).Show();
                };
            }
            
            
        }


        //use this to check if the app is accessing the internet
        //So far there is a connection
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
    }

}