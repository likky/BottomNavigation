using Android.App;
using Android.Widget;
using Android.OS;
using Android.Views;
using System.Threading;
using System.Net;
using System;


namespace BottomNavigation
{
    public class PictureFragment : Android.App.Fragment
    {
        private TextView text1;
        private TextView text2;
        private TextView text3;
        private TextView text4;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);
            View view = inflater.Inflate(Resource.Layout.picture_layout, container, false);

            text1 = view.FindViewById<TextView>(Resource.Id.brand);
            text2 = view.FindViewById<TextView>(Resource.Id.manufacturer);
            text3 = view.FindViewById<TextView>(Resource.Id.modelNumber);
            text4 = view.FindViewById<TextView>(Resource.Id.version);

            text1.Text = "品牌：" + Build.Brand;
            text2.Text = "制造商：" + Build.Manufacturer;
            text3.Text = "型号：" + Build.Model;
            text4.Text = "Android 版本：" + Build.VERSION.Release;

            return view;
        }

    }
}