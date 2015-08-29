using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CreateTrunk : MonoBehaviour {
	public GameObject refTrunk;
	public GameObject zeroPoint;
	public List<GameObject> trunksList = new List<GameObject>();
	public GameObject lastTrunk;
	public GameObject target;

	public float updateRate = 0.1f;
	public float nextTime = 0f;

	public GameObject refLeaf;
	public int createLeafInTertval = 2;
	public int createTrunkCount=0;

	public GameObject allTargets;
	public bool folowTrunk = false;

	public static int score=0;
	public Rect r;
	public GUIStyle style;
	
	// Use this for initialization
	void Start () {
		score = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.F1)){
			//doCreateTrunk();
		}
		if(Time.time > nextTime){
			doCreateTrunk();
			nextTime = Time.time + updateRate; 
		}
	}

	public void updateCarmeraPos(Vector3 newPos){
		Vector3 mcPos = allTargets.transform.position;

		//auto update
		if (allTargets != null && folowTrunk) {
			allTargets.transform.position = new Vector3(mcPos.x, newPos.y, mcPos.z);
		}


		Target.newTrunkPos = newPos;
	}

	public void doCreateTrunk(){
		if(refTrunk!=null){
			
			GameObject ep = null;
			if(lastTrunk == null){
				ep = zeroPoint; 
			}else{
				GameObject r = lastTrunk.transform.FindChild("rotation").gameObject;
				if(r!=null){
					ep = r.transform.FindChild("EndPoint").gameObject;
				}
				
			}
			if(ep != null){
				GameObject newTrunk = GameObject.Instantiate(refTrunk,ep.transform.position,Quaternion.identity) as GameObject;
				lastTrunk = newTrunk;
				Quaternion q = Quaternion.identity;
				Vector3 lookV3 = newTrunk.transform.position - target.transform.position;
				
				//get need turn left or right
				float a = Vector3.Dot(lookV3, transform.right);
				
				
				float ang = Vector3.Angle(lookV3, Vector3.up);
				if(a>0){
					ang = ang *-1; 
				}
				q.eulerAngles = new Vector3(0, 0, ang);
				newTrunk.transform.rotation = q;	
				//lastTrunk.transform.LookAt(target.transform.position);

				updateCarmeraPos(newTrunk.transform.position);

				Vector3 endPos = ep.transform.position;


				createTrunkCount = createTrunkCount+1;
				createLeaf(endPos);
			}
		}
	}


	public void createLeaf(Vector3 pos){
		if (refLeaf != null) {
			if(createTrunkCount>createLeafInTertval){
				createTrunkCount = 0;
				GameObject newLeaf = GameObject.Instantiate(refLeaf,pos,Quaternion.identity) as GameObject;
			}

		}
	}

	void OnGUI(){
		if (style != null) {
			GUI.Label (r, "Scero:" + score, style);
		} else {
			GUI.Label (r, "Scero:" + score);
		}
		
	}
}
