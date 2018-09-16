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
using Android.Graphics;

namespace BottomNavigation
{
    public class MyOnPageChangeListener : Android.Support.V4.View.ViewPager.SimpleOnPageChangeListener
    {
        private MainView mainView;

        public MyOnPageChangeListener(MainView _mainView)
        {
            mainView = _mainView;
        }
        public override void OnPageSelected(int position)
        {
            //清除选
            mainView.clearSelection();
            mainView.SetTabSelection(position);
        }
    }
}