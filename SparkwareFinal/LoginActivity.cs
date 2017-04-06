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
    [Activity(Label = "SparkwareFinal", MainLauncher = true, Icon = "@drawable/icon")]
    public class LoginActivity : Activity
    {
        Button btnLogin;
        EditText etUsername;
        EditText etPassword;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.login_page);

            btnLogin = FindViewById<Button>(Resource.Id.btnLogin);
            etUsername = FindViewById<EditText>(Resource.Id.etUsername);
            etPassword = FindViewById<EditText>(Resource.Id.etPassword);

            btnLogin.Click += BtnLogin_Click;

            // Create your application here
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            //if (etUsername.Text == "sparkware")
            //{
            //    if(etPassword.Text == "password")
            //    {
                    StartActivity(typeof(MainActivity));
            //    }
            //    else
            //    {
            //        Toast.MakeText(ApplicationContext, "Invalid Username", ToastLength.Long).Show();
            //    }
            //}
            //else
            //{
            //    Toast.MakeText(ApplicationContext, "Invalid Username", ToastLength.Long).Show();
            //}
        }
    }
}