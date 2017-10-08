using UnityEngine;
using System.Collections;

public class screenShotHeaven : MonoBehaviour {

	///to do screenshot, you must be in play mode...

	/// <summary>
	/// The key to bind to.
	/// </summary>
	public KeyCode key = KeyCode.BackQuote;


	///<summary>
	/// Supersampling value.
	/// </summary>
	public int superSize = 2;
	public bool canHoldDown = false;
	int counter = 0;

	void Update () {
	if ((canHoldDown && Input.GetKey(key)) || (!canHoldDown && Input.GetKeyDown (key))){
			Debug.Log("*click*");
			ScreenCapture.CaptureScreenshot("SCREENSHOT_" + counter + ".png", superSize);
			counter = counter + 1;
	}
}

}