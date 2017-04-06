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

namespace SparkwareFinal
{
    class Achievement
    {
        public Achievement()
        {

        }

        public int Id { get; set; }
        public int Description { get; set; }
        public string Status { get; set; }
        public DateTime EarnedDate { get; set; }
        public string RewardDescription { get; set; }
    }
}