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
    class Innovation
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string DescriptionLong { get; set; }
        public string DescriptionShort { get; set; }
        public int ImageId { get; set; }
        public int NumberOfLikes { get; set; }
        public DateTime CreationDate { get; set; }
        //public List<string> Comments { get; set; }
    }
}