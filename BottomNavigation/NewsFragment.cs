using Android.App;
using Android.Widget;
using Android.OS;
using Android.Views;

namespace BottomNavigation
{
    public class NewsFragment : Android.App.Fragment
    {
        private TextView textView;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.news_layout, container, false);

            textView = view.FindViewById<TextView>(Resource.Id.news);
            textView.Text = "这是第2个界面";

            return view;
        }

    }
}