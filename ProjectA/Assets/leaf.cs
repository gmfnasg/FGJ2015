using UnityEngine;
using System.Collections;

public class leaf : MonoBehaviour {
	public float watiTime = 1f;
	public float startTime = 0f;
	public BoxCollider coll;

	// Use this for initialization
	void Start () {
		if (coll != null) {
			coll.enabled = false;
		}
		startTime = Time.time;
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > startTime + watiTime) {
			if(coll!=null && this.transform.parent.gameObject.activeSelf){
				coll.enabled= true;
			}
		}
	}
}
