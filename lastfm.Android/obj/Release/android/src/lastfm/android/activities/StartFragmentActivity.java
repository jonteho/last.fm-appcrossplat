package lastfm.android.activities;


public class StartFragmentActivity
	extends com.actionbarsherlock.app.SherlockFragmentActivity
	implements
		mono.android.IGCUserPeer,
		com.actionbarsherlock.widget.SearchView.OnQueryTextListener
{
	static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"n_onResume:()V:GetOnResumeHandler\n" +
			"n_onCreateOptionsMenu:(Lcom/actionbarsherlock/view/Menu;)Z:GetOnCreateOptionsMenu_Lcom_actionbarsherlock_view_Menu_Handler\n" +
			"n_onQueryTextChange:(Ljava/lang/String;)Z:GetOnQueryTextChange_Ljava_lang_String_Handler:Xamarin.ActionbarSherlockBinding.Widget.SearchView/IOnQueryTextListenerInvoker, ActionBarSherlock\n" +
			"n_onQueryTextSubmit:(Ljava/lang/String;)Z:GetOnQueryTextSubmit_Ljava_lang_String_Handler:Xamarin.ActionbarSherlockBinding.Widget.SearchView/IOnQueryTextListenerInvoker, ActionBarSherlock\n" +
			"";
		mono.android.Runtime.register ("lastfm.Android.Activities.StartFragmentActivity, lastfm.Android, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", StartFragmentActivity.class, __md_methods);
	}


	public StartFragmentActivity () throws java.lang.Throwable
	{
		super ();
		if (getClass () == StartFragmentActivity.class)
			mono.android.TypeManager.Activate ("lastfm.Android.Activities.StartFragmentActivity, lastfm.Android, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);


	public void onResume ()
	{
		n_onResume ();
	}

	private native void n_onResume ();


	public boolean onCreateOptionsMenu (com.actionbarsherlock.view.Menu p0)
	{
		return n_onCreateOptionsMenu (p0);
	}

	private native boolean n_onCreateOptionsMenu (com.actionbarsherlock.view.Menu p0);


	public boolean onQueryTextChange (java.lang.String p0)
	{
		return n_onQueryTextChange (p0);
	}

	private native boolean n_onQueryTextChange (java.lang.String p0);


	public boolean onQueryTextSubmit (java.lang.String p0)
	{
		return n_onQueryTextSubmit (p0);
	}

	private native boolean n_onQueryTextSubmit (java.lang.String p0);

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
