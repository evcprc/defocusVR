using UnityEngine;
using System.Collections;

public class disableScreenSaver : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
			Screen.sleepTimeout = SleepTimeout.NeverSleep;

	 
	
	}
}
