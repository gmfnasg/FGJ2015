using UnityEngine;
using System.Collections;

public class NinjaControl : MonoBehaviour {
	public float moveX =0f;
	public float moveSpeed = 1;
	public float upPower = 10;
	public float nowUpPower = 0;
	public float moveY = 0;
	public float upSpeed = 1;
	public float downSpeed = 1; 
	Vector3 newPos = Vector3.zero;

	public GameObject left, right, up, down;

	public AudioSource jumpAudioSoure;

	public int endSceneId;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {



		Vector3 myPos = this.transform.position;
		if (nowUpPower > 0) {
			nowUpPower = Mathf.Max(0, nowUpPower-1);
			moveY = upSpeed;
			switchPicth(0);
		}else{
			moveY = downSpeed*-1;
			switchPicth(1);
		}

		if (Input.GetKey (KeyCode.LeftArrow)) {
			moveX = moveX - moveSpeed;
			switchPicth(2);
		}
		if (Input.GetKey (KeyCode.RightArrow)) {
			moveX = moveX + moveSpeed;
			switchPicth(3);
		}

		float newX = myPos.x + moveX;
		float newY = myPos.y + moveY;

		newPos = new Vector3(newX, newY, myPos.z);
		this.transform.position =newPos;

	}

	void OnCollisionEnter(Collision col){
		if (nowUpPower <= 0 && col.gameObject.tag=="leaf") {
			nowUpPower = upPower;
			if(jumpAudioSoure!=null){
				jumpAudioSoure.Play();
			}
		}

		if (col.gameObject.tag=="dead") {
			Debug.LogWarning("Dead");
			Destroy(this.gameObject);
			Application.LoadLevel(endSceneId);
		}
		/*if (col.gameObject.tag == "bird") {
			Destroy(col.gameObject);	
		}*/
	}

	void switchPicth(int id) //up0 down1 left2 right3
	{
		switch (id)
		{
		case 0:
			up.SetActive(true);
			down.SetActive(false);
			left.SetActive(false);
			right.SetActive(false);
			break;

		case 1:
			up.SetActive(false);
			down.SetActive(true);
			left.SetActive(false);
			right.SetActive(false);
			break;

		case 2:
			up.SetActive(false);
			down.SetActive(false);
			left.SetActive(true);
			right.SetActive(false);
			break;

		case 3:
			up.SetActive(false);
			down.SetActive(false);
			left.SetActive(false);
			right.SetActive(true);
			break;
		}

	}


}
