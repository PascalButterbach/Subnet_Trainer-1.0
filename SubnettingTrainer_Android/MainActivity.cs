using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System;
using IP_LIBRARY;
using System.Drawing;

namespace SubnettingTrainer_Android
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        IpManager ipManager = new IpManager();
        string[] dataSet;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            GenerateRND();


            FindViewById<EditText>(Resource.Id.editText_networkid).Click += btn_check_click;


        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        void btn_check_click(object sender, EventArgs args)
        {
            CompareUserInput();
        }

        void CompareUserInput()
        {

            Android.Graphics.Color tmp;

            tmp = (FindViewById<EditText>(Resource.Id.editText_networkid).Text == dataSet[2]) ? Android.Graphics.Color.DarkGreen : Android.Graphics.Color.DarkRed;
            FindViewById<TextView>(Resource.Id.textView_networkid).SetBackgroundColor(tmp);

            tmp = (FindViewById<EditText>(Resource.Id.editText_firsthost).Text == dataSet[2]) ? Android.Graphics.Color.DarkGreen : Android.Graphics.Color.DarkRed;
            FindViewById<TextView>(Resource.Id.textView_firsthost).SetBackgroundColor(tmp);

            tmp = (FindViewById<EditText>(Resource.Id.editText_lasthost).Text == dataSet[2]) ? Android.Graphics.Color.DarkGreen : Android.Graphics.Color.DarkRed;
            FindViewById<TextView>(Resource.Id.textView_lasthost).SetBackgroundColor(tmp);

            tmp = (FindViewById<EditText>(Resource.Id.editText_hosttotal).Text == dataSet[2]) ? Android.Graphics.Color.DarkGreen : Android.Graphics.Color.DarkRed;
            FindViewById<TextView>(Resource.Id.textView_hosttotal).SetBackgroundColor(tmp);

            tmp = (FindViewById<EditText>(Resource.Id.editText_broadcast).Text == dataSet[2]) ? Android.Graphics.Color.DarkGreen : Android.Graphics.Color.DarkRed;
            FindViewById<TextView>(Resource.Id.textView_broadcast).SetBackgroundColor(tmp);

            tmp = (FindViewById<EditText>(Resource.Id.editText_subnetmask).Text == dataSet[2]) ? Android.Graphics.Color.DarkGreen : Android.Graphics.Color.DarkRed;
            FindViewById<TextView>(Resource.Id.textView_subnetmask).SetBackgroundColor(tmp);

        }
        void GenerateRND()
        {
            dataSet = ipManager.GetRandomData();

            var itemview_ipcidr =  FindViewById<TextView>(Resource.Id.textView_ip_and_cidr);
            itemview_ipcidr.Text = "Berechne: " + dataSet[0] + "/" + dataSet[7];
            
        }
    }
}