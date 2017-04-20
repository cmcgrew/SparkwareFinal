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
        public EditText edtFeedBackText;
        public EditText edtEmailText;

        int counter = 0;

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
            submitIdeaButton.Click += StartEmailActivity;

            edtFeedBackText = view.FindViewById<EditText>(Resource.Id.txtEnterFeedback);

            edtEmailText = view.FindViewById<EditText>(Resource.Id.txtEnterEmail);

            return view;
        }

        //I have commented out this portion because we know it works
        //Need to know if we can send emails
        private void SubmitIdeaButon_Click(object sender, EventArgs e)
        {
            if  (edtFeedBackText.Text.Length > 0 && edtEmailText.Text.Length > 0)
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

                while (counter==0)
                {
                    myAlert.Show();                    
                    counter++;
                }

                if (counter > 0)
                {
                    {

                        Toast.MakeText(Activity, "You have already earned this badge. On to the next one!", ToastLength.Long).Show();
                    }
                }

                SendEmail();
            }
            else
            {
                {
                    Toast.MakeText(Activity, "Feedback field cannot be empty!", ToastLength.Long).Show();
                };
            }
        }


        private void SendEmail()
        {
            var emailTask = MessagingPlugin.EmailMessenger;

            if (emailTask.CanSendEmail)
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
            //else
            //{
            //    {
            //        Toast.MakeText(Activity, "Email Not Sent!", ToastLength.Long).Show();
            //    };
            //}           
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

        void StartEmailActivity(object sender, EventArgs e)
        {
            Intent intent = new Intent(this.Activity, typeof(actEmail));
            StartActivity(intent);
        }
    }

}