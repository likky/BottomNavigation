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
using Android.Support.V13.App;

namespace BottomNavigation
{
    //已经将原来的using Android.Support.V4.App;更新为using Android.Support.V13.App;
    public class MyFragmentPagerAdapter : FragmentPagerAdapter
    {
        private List<Fragment> fragments = new List<Fragment>();

        public MyFragmentPagerAdapter(FragmentManager fm, List<Fragment> _fragmentList)
            : base(fm)
        {
            fragments = _fragmentList;
        }

        public override Fragment GetItem(int position)
        {
            return fragments[position];
        }

        public override int Count
        {
            get { return fragments.Count(); }
        }
    }
}