package md51a291dd3421c8931a5e6084f6d31333a;


public class DetectDescriptionActivity_VisionTask
	extends android.os.AsyncTask
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onPreExecute:()V:GetOnPreExecuteHandler\n" +
			"n_onProgressUpdate:([Ljava/lang/Object;)V:GetOnProgressUpdate_arrayLjava_lang_Object_Handler\n" +
			"n_doInBackground:([Ljava/lang/Object;)Ljava/lang/Object;:GetDoInBackground_arrayLjava_lang_Object_Handler\n" +
			"n_onPostExecute:(Ljava/lang/Object;)V:GetOnPostExecute_Ljava_lang_Object_Handler\n" +
			"";
		mono.android.Runtime.register ("MicrosoftCognitiveImageTest.DetectDescriptionActivity+VisionTask, MicrosoftCognitiveImageTest, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", DetectDescriptionActivity_VisionTask.class, __md_methods);
	}


	public DetectDescriptionActivity_VisionTask ()
	{
		super ();
		if (getClass () == DetectDescriptionActivity_VisionTask.class)
			mono.android.TypeManager.Activate ("MicrosoftCognitiveImageTest.DetectDescriptionActivity+VisionTask, MicrosoftCognitiveImageTest, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}

	public DetectDescriptionActivity_VisionTask (md51a291dd3421c8931a5e6084f6d31333a.DetectDescriptionActivity p0)
	{
		super ();
		if (getClass () == DetectDescriptionActivity_VisionTask.class)
			mono.android.TypeManager.Activate ("MicrosoftCognitiveImageTest.DetectDescriptionActivity+VisionTask, MicrosoftCognitiveImageTest, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "MicrosoftCognitiveImageTest.DetectDescriptionActivity, MicrosoftCognitiveImageTest, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", this, new java.lang.Object[] { p0 });
	}


	public void onPreExecute ()
	{
		n_onPreExecute ();
	}

	private native void n_onPreExecute ();


	public void onProgressUpdate (java.lang.Object[] p0)
	{
		n_onProgressUpdate (p0);
	}

	private native void n_onProgressUpdate (java.lang.Object[] p0);


	public java.lang.Object doInBackground (java.lang.Object[] p0)
	{
		return n_doInBackground (p0);
	}

	private native java.lang.Object n_doInBackground (java.lang.Object[] p0);


	public void onPostExecute (java.lang.Object p0)
	{
		n_onPostExecute (p0);
	}

	private native void n_onPostExecute (java.lang.Object p0);

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
