using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Android.Preferences;

namespace BottomNavigation
{
    public class SettingFragment : PreferenceFragment, ISharedPreferencesOnSharedPreferenceChangeListener, Preference.IOnPreferenceClickListener
    {
        private ISharedPreferences preferences;
        Intent intent = new Intent();
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            //项目结构下的Resources目录下添加一个xml文件夹
            AddPreferencesFromResource(Resource.Xml.preferences);

            preferences = PreferenceManager.GetDefaultSharedPreferences(this.Activity);
            OnSharedPreferenceChanged(preferences, "icon");
            //FindPreference("share").OnPreferenceChangeListener = this;
            //必须要注册点击监听，否则点击没有任何反应！
            FindPreference("share").OnPreferenceClickListener = this;
            FindPreference("version").OnPreferenceClickListener = this;


        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            return base.OnCreateView(inflater, container, savedInstanceState);
        }

        public override void OnResume()
        {
            base.OnResume();
            //必须在这里进行注册，否则分享后跳转回来后未注册，不会执行通知和免提的代码。
            preferences.RegisterOnSharedPreferenceChangeListener(this);
            //Activity.GetPreferences(FileCreationMode.Private).RegisterOnSharedPreferenceChangeListener(this);
        }

        public override void OnPause()
        {
            base.OnPause();
            //Activity.GetPreferences(FileCreationMode.Private).UnregisterOnSharedPreferenceChangeListener(this);
            PreferenceManager.SharedPreferences.UnregisterOnSharedPreferenceChangeListener(this);
        }

        public bool OnPreferenceClick(Preference preference)
        {
            if (preference.Key == "share")
            {//调用系统自带的分享功能
                intent.SetAction(Intent.ActionSend);
                intent.PutExtra(Intent.ExtraText, GetString(Resource.String.shareValue));
                intent.SetType("text/plain");
                StartActivity(Intent.CreateChooser(intent, GetString(Resource.String.share)));
            }
            if (preference.Key == "version")
            {
                //Intent intent = new Intent(this.Activity, typeof(VersionActivity));
                //this.Activity.StartActivity(intent);
            }

            return true;
        }

        public void OnSharedPreferenceChanged(ISharedPreferences sharedPreferences, string key)
        {

            if (key == "icon")
            {
                Preference preference1 = FindPreference(key);
                if (preference1.GetType() == typeof(SwitchPreference))
                {
                    var switchPreference = (SwitchPreference)preference1;
                    if (switchPreference.Checked)
                    {
                        ISharedPreferences preferences = this.Activity.GetSharedPreferences("installer", FileCreationMode.Private);
                        ISharedPreferencesEditor editor = preferences.Edit();
                        editor.PutInt("enableNotification", 1);
                        editor.Commit();
                    }
                    else
                    {
                        ISharedPreferences preferences = this.Activity.GetSharedPreferences("installer", FileCreationMode.Private);
                        ISharedPreferencesEditor editor = preferences.Edit();
                        editor.PutInt("enableNotification", 0);
                        editor.Commit();
                    }
                }
            }
        }
    }
}