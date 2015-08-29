using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Target : MonoBehaviour {
	public float upSpeed = 0.1f;
	public float moveSpeed = 0.1f; 
	public GameObject target;
	public float fixHeight = 10;

	public float moveLimit = 10;

	public static Vector3 newTrunkPos = Vector3.zero;
	public bool folowTrunkUpdatePos = false;
	public bool autoUpdate = false;

	public float createBirdIntertvalTime = 10f;
	public float nextCreatBirdTime = 15f;
	public GameObject[] creatPots = new GameObject[0];
	public GameObject refBird;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (folowTrunkUpdatePos) {
			if(newTrunkPos!=Vector3.zero && newTrunkPos.y>this.gameObject.transform.position.y +fixHeight){
				UpdateUpPos();
			} 
		}else if(autoUpdate){
			UpdateUpPos();
		}
		UpdateMovePos ();

		createBird ();
	}

	void createBird()
	{
		if (Time.time > nextCreatBirdTime) {
			nextCreatBirdTime = Time.time +nextCreatBirdTime;

			if(creatPots.Length>0)
			{
				int index =  Random.Range(0,creatPots.Length);
				if(index >= creatPots.Length)
				{
					index =0;
				}
				GameObject cbp = creatPots[index];
				if(cbp != null)
				{
					CreateBird cb = (CreateBird)cbp.GetComponent("CreateBird");
					cb.Do();
				}
			}
		}
	}

	void UpdateUpPos(){
		Vector3 myPos = this.gameObject.transform.position;
		this.gameObject.transform.position = new Vector3(myPos.x, myPos.y+upSpeed, myPos.z);
	}

	void UpdateMovePos(){
		float move = 0;

		Vector3 targetPos = target.gameObject.transform.position;
		if (Input.GetKey (KeyCode.A)) {
			move = move-moveSpeed;
		}else if(Input.GetKey (KeyCode.D)){
			move = move+moveSpeed;
		}

		if (targetPos.x + moveSpeed > moveLimit && move>0) 
		{
			move = 0;
		}
		if (targetPos.x - moveSpeed < moveLimit * -1 && move<0) 
		{
			move = 0;
		}

		target.gameObject.transform.position = new Vector3(targetPos.x+move, targetPos.y, targetPos.z);

		/*if (targetPos.x > moveLimit) 
		{
			target.gameObject.transform.position = new Vector3(moveLimit, targetPos.y, targetPos.z);
		}
		if (targetPos.x < moveLimit * -1) 
		{
			target.gameObject.transform.position = new Vector3(moveLimit*-1, targetPos.y, targetPos.z);
		}*/
	}
}
