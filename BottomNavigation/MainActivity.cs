using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Graphics;
using Android.Support.V4.App;
using Android.Support.V13.App;
using Android.Support.V4.View;
using System.Collections.Generic;
using Android.Support.V7.App;

namespace BottomNavigation
{
    [Activity(Label = "@string/app_name", MainLauncher = true, Theme = "@style/AppTheme")]
    public class MainActivity : AppCompatActivity, View.IOnClickListener
    {
        private ViewPager viewPager;
        private Android.Support.V13.App.FragmentPagerAdapter adapter;
        //private List<Android.Support.V4.App.Fragment> fragments = new List<Android.Support.V4.App.Fragment>();
        private List<Android.App.Fragment> fragments = new List<Android.App.Fragment>();
        private MainView mainView;

        /*在这里获取到每个需要用到的控件的实例，并给它们设置好必要的点击事件。*/
        private void InitViews()
        {
            mainView = new MainView();
            mainView.pictureLayout = FindViewById(Resource.Id.picture_layout);
            mainView.newsLayout = FindViewById(Resource.Id.news_layout);
            mainView.settingLayout = FindViewById(Resource.Id.setting_layout);

            mainView.pictureText = (TextView)FindViewById(Resource.Id.picture_text);
            mainView.newsText = (TextView)FindViewById(Resource.Id.news_text);
            mainView.settingText = (TextView)FindViewById(Resource.Id.setting_text);

            mainView.pictureLayout.SetOnClickListener(this);
            mainView.newsLayout.SetOnClickListener(this);
            mainView.settingLayout.SetOnClickListener(this);
        }
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            viewPager = FindViewById<ViewPager>(Resource.Id.viewpager);
            // 初始化布局元素  
            InitViews();

            mainView.pictureFragment = new PictureFragment();
            mainView.newsFragment = new NewsFragment();
            mainView.settingFragment = new SettingFragment();

            fragments.Add(mainView.pictureFragment);
            fragments.Add(mainView.newsFragment);
            fragments.Add(mainView.settingFragment);
            //已经将原来的using Android.Support.V4.App;更新为using Android.Support.V13.App;
            //adapter = new MyFragmentPagerAdapter(SupportFragmentManager, fragments);
            adapter = new MyFragmentPagerAdapter(FragmentManager, fragments);
            viewPager.Adapter = adapter;
            viewPager.AddOnPageChangeListener(new MyOnPageChangeListener(mainView));
            //默认选择第一个
            mainView.SetTabSelection(0);
        }

        public void OnClick(View v)
        {
            int currentIndex = 0;
            switch (v.Id)
            {
                case Resource.Id.picture_layout:
                    // 当点击了消息tab时，选中第1个tab  
                    currentIndex = 0;
                    break;
                case Resource.Id.news_layout:
                    // 当点击了动态tab时，选中第3个tab  
                    currentIndex = 1;
                    break;
                case Resource.Id.setting_layout:
                    // 当点击了设置tab时，选中第4个tab  
                    currentIndex = 2;
                    break;
                default:
                    break;
            }
            mainView.SetTabSelection(currentIndex);
            viewPager.SetCurrentItem(currentIndex, false);
        }


    }
}

