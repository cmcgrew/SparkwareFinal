using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Support.V7.Widget;

namespace SparkwareFinal
{
    class PatentListViewAdapter : BaseAdapter<Innovation>
    {

        private List<Innovation> mInnovations;
        private Context mContext;

        public PatentListViewAdapter(Activity context, List<Innovation> innovations)
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
                row = LayoutInflater.From(mContext).Inflate(Resource.Layout.patenttree_row, null, false);
            }

            AppCompatTextView patentHolderName = row.FindViewById<AppCompatTextView>(Resource.Id.name);
            patentHolderName.Text = mInnovations[position].Contributor;

            AppCompatTextView patentDescription = row.FindViewById<AppCompatTextView>(Resource.Id.description);
            patentDescription.Text = mInnovations[position].DescriptionShort;

            AppCompatTextView patentDate = row.FindViewById<AppCompatTextView>(Resource.Id.date);
            patentDate.Text = String.Format("{0:MMMM d, yyy}", mInnovations[position].CreationDate);

            return row;
        }
    }
}