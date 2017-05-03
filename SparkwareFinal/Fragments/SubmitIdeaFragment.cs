using System;
using Android.OS;
using Android.Views;
using Android.Widget;
using Plugin.Messaging;
using System.Net;
using Android.App;
using Android.Content;
using Plugin.TextToSpeech;
using Newtonsoft.Json;

namespace SparkwareFinal.Fragments
{
    public class SubmitIdeaFragment : Android.Support.V4.App.Fragment
    {
        public EditText edtFeedBackText;
        public EditText edtEmailText;
        public Button btnReadEmailText;
        bool receivedBadge = false;

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
            //submitIdeaButton.Click += StartEmailActivity;

            edtFeedBackText = view.FindViewById<EditText>(Resource.Id.txtEnterFeedback);

            edtEmailText = view.FindViewById<EditText>(Resource.Id.txtEnterEmail);

            btnReadEmailText = view.FindViewById<Button>(Resource.Id.btnReadIdea);
            btnReadEmailText.Click += BtnReadEmailText_Click;

            return view;
        }

        private void BtnReadEmailText_Click(object sender, EventArgs e)
        {
            var textToread = edtFeedBackText.Text;
            CrossTextToSpeech.Current.Speak(textToread);
        }

        //I have commented out this portion because we know it works
        //Need to know if we can send emails
        private void SubmitIdeaButon_Click(object sender, EventArgs e)
        {
            if (edtFeedBackText.Text.Length > 0 && edtEmailText.Text.Length > 0)
            {
                AlertDialog.Builder alert = new AlertDialog.Builder(Activity);
                AlertDialog myAlert = alert.Create();
                if (receivedBadge == false)
                {
                    ImageView badge1 = new ImageView(Activity);
                    myAlert.SetTitle("Badge Earned!");
                    myAlert.SetMessage("First feedback badge earned!");
                    myAlert.SetIcon(Resource.Drawable.badge1);
                    myAlert.SetButton("Awesome!", (s, ev) =>
                    {
                        Toast.MakeText(Activity, "Badge Earned!", ToastLength.Long).Show();
                    });
                    receivedBadge = true;
                    Intent intent = new Intent(this.Activity, typeof(MainActivity));
                    intent.PutExtra("badge", receivedBadge);
                }
                else
                {
                    myAlert.SetTitle("Thank you!");
                    myAlert.SetMessage("Thank you for your feedback!");
                    myAlert.SetButton("Continue", (s, ev) =>
                    {
                        Toast.MakeText(Activity, "Thank You", ToastLength.Long).Show();
                    });
                }
                while (counter == 0)
                {
                    myAlert.Show();
                    counter++;
                }

                
                {
                    Intent intent = new Intent(this.Activity, typeof(actEmail));
                    StartActivity(intent);
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