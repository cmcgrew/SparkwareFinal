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
        User user1 = new User("sparkware", "password");
        User user2 = new User("abdul", "password2");
        List<User> users = new List<User>();
        bool loginSuccesful = false;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.login_page);

            btnLogin = FindViewById<Button>(Resource.Id.btnLogin);
            etUsername = FindViewById<EditText>(Resource.Id.etUsername);
            etPassword = FindViewById<EditText>(Resource.Id.etPassword);
            users.Add(user1);
            users.Add(user2);


            btnLogin.Click += BtnLogin_Click;

            // Create your application here
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
           
            foreach (User u in users)
            {
                if(loginSuccesful==true)
                {
                    break;
                }
                if (etUsername.Text == u.Login)
                {
                    if (etPassword.Text == u.Password) 
                    {
                        loginSuccesful = true;
                        StartActivity(typeof(MainActivity));
                        break;
                    }
                    else
                    {
                        Toast.MakeText(ApplicationContext, "Invalid username or password", ToastLength.Long).Show();
                    }
                }
                
            }
        }
    }
}