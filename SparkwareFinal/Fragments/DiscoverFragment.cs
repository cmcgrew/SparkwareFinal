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
using static Android.Support.V4.View.ViewPager;
using Android.Graphics;

namespace SparkwareFinal.Fragments
{
    public class DiscoverFragment : Android.Support.V4.App.Fragment
    {
        List<Innovation> innovations;
        Innovation innovation1;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.discover_page, container, false);

            innovations = new List<Innovation>();
            innovation1 = new Innovation();

            innovation1.Title = "Innovation1 Title";
            innovation1.Description = "Innovation1 Description";
            innovation1.NumberOfLikes = 2000;

            innovations.Add(innovation1);

            // Created LinearLayout (Container for image, and text) 
            LinearLayout innovationContainer = new LinearLayout(this.Context);
            innovationContainer.Orientation = Orientation.Horizontal;
            innovationContainer.SetBackgroundResource(Resource.Drawable.customshape);
            LinearLayout.LayoutParams containerParams = new LinearLayout.LayoutParams(LayoutParams.MatchParent, 450);
            innovationContainer.LayoutParameters = containerParams;
            innovationContainer.WeightSum = 100;
            innovationContainer.Id = 0;

            LinearLayout parent = view.FindViewById<LinearLayout>(Resource.Id.discoverLinearLayout);
            parent.AddView(innovationContainer);

            ImageView innovationImageView = new ImageView(this.Context);
            LinearLayout.LayoutParams imageParams = new LinearLayout.LayoutParams(0, LayoutParams.MatchParent, 40.0f);
            innovationImageView.SetBackgroundResource(Resource.Drawable.Icon);
            //innovationImageView.SetBackgroundColor(Color.Green);
            innovationImageView.Visibility = ViewStates.Visible;
          
            innovationContainer.AddView(innovationImageView);


            LinearLayout innovationTextContainer = new LinearLayout(this.Context);
            innovationTextContainer.Orientation = Orientation.Vertical;
            LinearLayout.LayoutParams innovationTextContainerParams = new LinearLayout.LayoutParams(LayoutParams.MatchParent, LayoutParams.MatchParent);
            innovationTextContainer.LayoutParameters = innovationTextContainerParams;
            innovationTextContainer.WeightSum = 100;
            innovationTextContainer.SetBackgroundColor(Color.Green);

            innovationContainer.AddView(innovationTextContainer);

            TextView innovationTitleTextView = new TextView(this.Context);
            innovationTitleTextView.SetTextColor(Color.Black);
            innovationTitleTextView.Text = innovations[0].Title;
            innovationTitleTextView.SetTextSize(ComplexUnitType.Sp, 20.0f);

            innovationTextContainer.AddView(innovationTitleTextView);

            TextView innovationDescriptionTextView = new TextView(this.Context);
            innovationDescriptionTextView.SetTextColor(Color.Black);
            innovationDescriptionTextView.Text = innovations[0].Description;
            innovationDescriptionTextView.SetTextSize(ComplexUnitType.Sp, 15.0f);

            innovationTextContainer.AddView(innovationDescriptionTextView);

            return view;
        }
    }
}