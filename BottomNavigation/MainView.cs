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
    public class MainView
    {
        public PictureFragment pictureFragment { get; set; }
        public NewsFragment newsFragment { get; set; }
        public SettingFragment settingFragment { get; set; }

        public View pictureLayout { get; set; }
        public View newsLayout { get; set; }
        public View settingLayout { get; set; }

        /*在Tab布局上显示图标的控件*/
        //为了保证照片显示完美，以去掉导航图片
        //public ImageView pictureImage { get; set; }
        //public ImageView newsImage { get; set; }
        //public ImageView settingImage { get; set; }

        public TextView pictureText { get; set; }
        public TextView newsText { get; set; }
        public TextView settingText { get; set; }

        public void clearSelection()
        {
            //pictureImage.SetImageResource(Resource.Drawable.picture_unselected);
            pictureText.SetTextColor(Color.ParseColor("#FFFFFF"));
            //newsImage.SetImageResource(Resource.Drawable.news_unselected);
            newsText.SetTextColor(Color.ParseColor("#FFFFFF"));
            //settingImage.SetImageResource(Resource.Drawable.setting_unselected);
            settingText.SetTextColor(Color.ParseColor("#FFFFFF"));
        }

        public void SetTabSelection(int index)
        {
            switch (index)
            {
                case 0:
                    // 当点击了消息tab时，改变控件的图片和文字颜色  
                    //pictureImage.SetImageResource(Resource.Drawable.picture_selected);
                    pictureText.SetTextColor(Color.DarkRed);
                    break;
                case 1:
                    // 当点击了动态tab时，改变控件的图片和文字颜色  
                    //newsImage.SetImageResource(Resource.Drawable.news_selected);
                    newsText.SetTextColor(Color.DarkOrange);
                    break;
                case 2:
                default:
                    // 当点击了设置tab时，改变控件的图片和文字颜色  
                    //settingImage.SetImageResource(Resource.Drawable.setting_selected);
                    settingText.SetTextColor(Color.DarkBlue);
                    break;
            }
        }

    }
}