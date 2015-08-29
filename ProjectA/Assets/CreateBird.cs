using UnityEngine;
using System.Collections;

public class CreateBird : MonoBehaviour {
	public int moveTo = 1;
	public GameObject refBird;
	public float waitTime = 5;
	// Use this for initialization
	void Start () {
		waitTime = 5;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Do()
	{
		if (refBird != null && Time.time > waitTime) {
			GameObject newBird = GameObject.Instantiate(refBird, this.transform.position, Quaternion.identity) as GameObject;
			Bird b = (Bird)newBird.GetComponent("Bird");
			if(b!=null){
				b.moveSpeed = b.moveSpeed*moveTo;
			}
		}
	}
}
