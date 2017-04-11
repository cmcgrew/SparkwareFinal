using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Support.V4.App;
using Android.Support.V7.Widget;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace SparkwareFinal
{
    class DiscoverListViewAdapter : BaseAdapter<Innovation>
    {
        private List<Innovation> mInnovations;
        private Context mContext;

        public DiscoverListViewAdapter(Activity context, List<Innovation> innovations)
        {
            mInnovations = innovations;
            mContext = context;
        }

        public override int Count
        {
            get
            {
                return mInnovations.Count;
            }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override Innovation this[int position]
        {
            get
            {
                return mInnovations[position];
            }
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View row = convertView;

            if (row == null)
            {
                row = LayoutInflater.From(mContext).Inflate(Resource.Layout.discover_row, null, false);
            }

            AppCompatImageView innovationImage = row.FindViewById<AppCompatImageView>(Resource.Id.innovationImage);
            innovationImage.SetBackgroundResource(mInnovations[position].ImageId);

            AppCompatTextView innovationTitle = row.FindViewById<AppCompatTextView>(Resource.Id.innovationTitle);
            innovationTitle.Text = mInnovations[position].Title;

            AppCompatTextView innovationDescription = row.FindViewById<AppCompatTextView>(Resource.Id.innovationDescription);
            innovationDescription.Text = mInnovations[position].DescriptionShort;

            AppCompatTextView innovationContributor = row.FindViewById<AppCompatTextView>(Resource.Id.innovationContributor);
            innovationContributor.Text = "Contributor: " + mInnovations[position].Contributor;

            AppCompatTextView innovationLikes = row.FindViewById<AppCompatTextView>(Resource.Id.innovationLikes);
            innovationLikes.Text = "Likes: " + mInnovations[position].NumberOfLikes;

            return row;
        }
        public void Update(List<Innovation> innovations)
        {
            mInnovations.Clear();
            mInnovations.AddRange(innovations);
            NotifyDataSetChanged();
        }


    }
}