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
        int x = 0;
        bool isRadioButtonPressed = false;
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);




            // Create your fragment here

        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.submitidea_page, container, false);
            //joins c# and axml
            Button submitIdeaButton = view.FindViewById<Button>(Resource.Id.btnSubmitFeedback);

            RadioButton otherRB = view.FindViewById<RadioButton>(Resource.Id.OtherRadioButton);
            RadioButton investmentRB = view.FindViewById<RadioButton>(Resource.Id.InvestmentRadioButton);
            RadioButton insuranceRB = view.FindViewById<RadioButton>(Resource.Id.InsuranceRadioButton);
            RadioButton bankingRB = view.FindViewById<RadioButton>(Resource.Id.BankingRadioButton);
            if (otherRB.Checked== true || investmentRB.Checked == true || insuranceRB.Checked == true || bankingRB.Checked == true)
            {
                isRadioButtonPressed = true;
            }

            //delegate composer that says "when submitIdeaButton is clicked then do SubmitIdeaButton_Click method"
            submitIdeaButton.Click += SubmitIdeaButon_Click;

            return view;

        }
        //click event for feedback that validates information and sends user feedback as badge or thank you
        private void SubmitIdeaButon_Click(object sender, EventArgs e)
        {
            //builds an alert box that will give a badge if it is their first feeback
            AlertDialog.Builder alert = new AlertDialog.Builder(Activity);
            AlertDialog myAlert = alert.Create();

            if (isRadioButtonPressed == true)
            {
                
                if (x == 0)
                {
                    myAlert.SetTitle("Badge Earned!");
                    myAlert.SetMessage("First feedback badge earned");
                    myAlert.SetIcon(Resource.Drawable.badge1);
                    myAlert.SetButton("Awesome", (s, ev) =>
                    {
                        Toast.MakeText(Activity, "Badge Earned!", ToastLength.Long).Show();
                    });
                    x++;
                }
                else
                {
                    myAlert.SetTitle("Thank you for your feedback!");
                    myAlert.SetMessage("Your feedback is valuable");
                    myAlert.SetButton("Okay", (s, ev) =>
                    {
                        Toast.MakeText(Activity, "Feedback sent!", ToastLength.Long).Show();
                    });
                }
                myAlert.Show();

            }
            else
            {
                myAlert.SetTitle("Please select a category");
                myAlert.SetIcon(Resource.Drawable.badge1);
                myAlert.SetButton("Okay", (s, ev) =>
                {
                   
                });
                
            }
        }
          
            
    }

}