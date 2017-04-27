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
    class User
    {
        private string login = "";
        private string password = "";
        private List<string> badges=new List<string>();
        private bool isLoggedIn = new bool();
        
        public string Login { get; set; }
        public string Password { get; set; }
        public List<string> Badges { get; set; }

        public User()
        {

        }
        public User(string login, string password)
        {
            this.Login = login;
            this.Password= password;
            string[] input = { "false", "false", "false", "false", "false"};
            this.badges.AddRange(input);
        }
    }
}