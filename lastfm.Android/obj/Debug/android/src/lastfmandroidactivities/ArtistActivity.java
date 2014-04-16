package lastfmandroidactivities;


public class ArtistActivity
	extends com.actionbarsherlock.app.SherlockFragmentActivity
	implements
		mono.android.IGCUserPeer,
		android.support.v4.view.ViewPager.OnPageChangeListener,
		com.actionbarsherlock.app.ActionBar.TabListener
{
	static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"n_onOptionsItemSelected:(Lcom/actionbarsherlock/view/MenuItem;)Z:GetOnOptionsItemSelected_Lcom_actionbarsherlock_view_MenuItem_Handler\n" +
			"n_onPageScrollStateChanged:(I)V:GetOnPageScrollStateChanged_IHandler:Android.Support.V4.View.ViewPager/IOnPageChangeListenerInvoker, Xamarin.Android.Support.v4\n" +
			"n_onPageScrolled:(IFI)V:GetOnPageScrolled_IFIHandler:Android.Support.V4.View.ViewPager/IOnPageChangeListenerInvoker, Xamarin.Android.Support.v4\n" +
			"n_onPageSelected:(I)V:GetOnPageSelected_IHandler:Android.Support.V4.View.ViewPager/IOnPageChangeListenerInvoker, Xamarin.Android.Support.v4\n" +
			"n_onTabReselected:(Lcom/actionbarsherlock/app/ActionBar$Tab;Landroid/support/v4/app/FragmentTransaction;)V:GetOnTabReselected_Lcom_actionbarsherlock_app_ActionBar_Tab_Landroid_support_v4_app_FragmentTransaction_Handler:Xamarin.ActionbarSherlockBinding.App.ActionBar/ITabListenerInvoker, ActionBarSherlock\n" +
			"n_onTabSelected:(Lcom/actionbarsherlock/app/ActionBar$Tab;Landroid/support/v4/app/FragmentTransaction;)V:GetOnTabSelected_Lcom_actionbarsherlock_app_ActionBar_Tab_Landroid_support_v4_app_FragmentTransaction_Handler:Xamarin.ActionbarSherlockBinding.App.ActionBar/ITabListenerInvoker, ActionBarSherlock\n" +
			"n_onTabUnselected:(Lcom/actionbarsherlock/app/ActionBar$Tab;Landroid/support/v4/app/FragmentTransaction;)V:GetOnTabUnselected_Lcom_actionbarsherlock_app_ActionBar_Tab_Landroid_support_v4_app_FragmentTransaction_Handler:Xamarin.ActionbarSherlockBinding.App.ActionBar/ITabListenerInvoker, ActionBarSherlock\n" +
			"";
		mono.android.Runtime.register ("lastfmAndroidActivities.ArtistActivity, lastfm.Android, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", ArtistActivity.class, __md_methods);
	}


	public ArtistActivity () throws java.lang.Throwable
	{
		super ();
		if (getClass () == ArtistActivity.class)
			mono.android.TypeManager.Activate ("lastfmAndroidActivities.ArtistActivity, lastfm.Android, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);


	public boolean onOptionsItemSelected (com.actionbarsherlock.view.MenuItem p0)
	{
		return n_onOptionsItemSelected (p0);
	}

	private native boolean n_onOptionsItemSelected (com.actionbarsherlock.view.MenuItem p0);


	public void onPageScrollStateChanged (int p0)
	{
		n_onPageScrollStateChanged (p0);
	}

	private native void n_onPageScrollStateChanged (int p0);


	public void onPageScrolled (int p0, float p1, int p2)
	{
		n_onPageScrolled (p0, p1, p2);
	}

	private native void n_onPageScrolled (int p0, float p1, int p2);


	public void onPageSelected (int p0)
	{
		n_onPageSelected (p0);
	}

	private native void n_onPageSelected (int p0);


	public void onTabReselected (com.actionbarsherlock.app.ActionBar.Tab p0, android.support.v4.app.FragmentTransaction p1)
	{
		n_onTabReselected (p0, p1);
	}

	private native void n_onTabReselected (com.actionbarsherlock.app.ActionBar.Tab p0, android.support.v4.app.FragmentTransaction p1);


	public void onTabSelected (com.actionbarsherlock.app.ActionBar.Tab p0, android.support.v4.app.FragmentTransaction p1)
	{
		n_onTabSelected (p0, p1);
	}

	private native void n_onTabSelected (com.actionbarsherlock.app.ActionBar.Tab p0, android.support.v4.app.FragmentTransaction p1);


	public void onTabUnselected (com.actionbarsherlock.app.ActionBar.Tab p0, android.support.v4.app.FragmentTransaction p1)
	{
		n_onTabUnselected (p0, p1);
	}

	private native void n_onTabUnselected (com.actionbarsherlock.app.ActionBar.Tab p0, android.support.v4.app.FragmentTransaction p1);

	java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
