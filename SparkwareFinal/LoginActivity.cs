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
using Newtonsoft.Json;

namespace SparkwareFinal
{
    [Activity(Label = "SparkwareFinal", MainLauncher = true, Icon = "@drawable/icon")]
    public class LoginActivity : Activity
    {
        Button btnLogin;
        EditText etUsername;
        EditText etPassword;
        List<string> badges1 = new List<string>();
        List<string> badges2 = new List<string>();


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

            badges1.Add("false");
            badges1.Add("false");
            badges1.Add("false");
            badges1.Add("false");
            badges1.Add("false");
            user1.Badges = badges1;

            badges2.Add("false");
            badges2.Add("false");
            badges2.Add("false");
            badges2.Add("false");
            badges2.Add("false");
            user2.Badges = badges2;

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

                        //********************************************************************************
                        //Step 1:Download Newtonsoft.JSON and add the library to the top
                        //Step 2: Place the following code with what you want to send
                        //The "u" in "SerializeObject(u)" is the user that was logged in and is being passed
                        //Step 3: Go to SubmitIdeaFragment.cs to see how to retrieve the data
                        Intent mainActivity= new Intent(this, typeof(MainActivity));
                        mainActivity.PutExtra("user", JsonConvert.SerializeObject(u));


                        StartActivity(mainActivity);
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