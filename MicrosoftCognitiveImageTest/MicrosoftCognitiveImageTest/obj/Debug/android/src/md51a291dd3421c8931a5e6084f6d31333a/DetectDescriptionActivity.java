package md51a291dd3421c8931a5e6084f6d31333a;


public class DetectDescriptionActivity
	extends android.support.v7.app.AppCompatActivity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("MicrosoftCognitiveImageTest.DetectDescriptionActivity, MicrosoftCognitiveImageTest, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", DetectDescriptionActivity.class, __md_methods);
	}


	public DetectDescriptionActivity ()
	{
		super ();
		if (getClass () == DetectDescriptionActivity.class)
			mono.android.TypeManager.Activate ("MicrosoftCognitiveImageTest.DetectDescriptionActivity, MicrosoftCognitiveImageTest, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);

	private java.util.ArrayList refList;
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
