using UnityEngine;
using System.Collections;

public class Bird : MonoBehaviour {
	public float moveSpeed;
	public int moveCount = 0;
	public int moveLimit = 1000;

	public GameObject[] birdPics = new GameObject[0];
	public float IntertvalTime = 0.1f;
	public float nextTime = 0f;

	public GameObject[] childPics = new GameObject[0];

	// Use this for initialization
	void Start () {
		if (childPics != null && childPics.Length > 0) 
		{
			int index = Random.Range(0, childPics.Length);
			if(index>= childPics.Length)
			{
				index = 0;
			}
			for(int i = 0;i<childPics.Length;i++)
			{
				if(i==index)
				{
					childPics[i].SetActive(true);
				}
				else
				{
					childPics[i].SetActive(false);
				}
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 myPos = this.transform.position;
		this.transform.position = new Vector3 (myPos.x+moveSpeed, myPos.y, myPos.z);
		moveCount = moveCount + 1;
		if (moveCount >= moveLimit) {
			Destroy(this);		
		}

		if(Time.time > nextTime){
			nextTime = Time.time + IntertvalTime;
			roopPic (birdPics);
		}

	}

	public void roopPic(GameObject[] pics)
	{
		if (pics != null && pics.Length>0) {
			int index = 0;
			for(int i= 0; i<pics.Length; i++)
			{
				if(pics[i].activeSelf)
				{
					index = i+1;
				}
			}
			if(index >= pics.Length){
				index = 0;
			}
			for(int i= 0; i<pics.Length; i++)
			{
				if(i == index){
					pics[i].SetActive(true);
				}else
				{
					pics[i].SetActive(false);
				}
			}
		}
	}


}
