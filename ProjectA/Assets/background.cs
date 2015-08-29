using UnityEngine;
using System.Collections;

public class background : MonoBehaviour {
	public float fallSpeed = 0.01f;
	public int fallCount = 0;
	public int fallLimit = 100;
	public bool startFall = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (startFall && fallCount < fallLimit) {
			Vector3 myPos = this.transform.localPosition;
			this.transform.localPosition = new Vector3(myPos.x,myPos.y-fallSpeed,myPos.z);
			fallCount = fallCount+1;
		}else{
			startFall = startFall = false;
			fallCount = 0;
		}
	}
}
