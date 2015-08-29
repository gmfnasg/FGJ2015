using UnityEngine;
using System.Collections;

public class child : MonoBehaviour {
	public AudioSource audioSoure;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision col){

		if (col.gameObject.tag == "body" || col.gameObject.tag == "player") {

			CreateTrunk.score = CreateTrunk.score+1;
			if(audioSoure!=null){
				audioSoure.Play();
			}
			Destroy(this.transform.gameObject);	
		}else
		{
			Debug.Log("child hit " + col.gameObject.name + ", tag:"+col.gameObject.tag);
		}
	}

}
