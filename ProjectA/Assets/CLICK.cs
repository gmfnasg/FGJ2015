using UnityEngine;
using System.Collections;

public class CLICK : MonoBehaviour {
	public int sceneId;
	//public string sceneName;
	public string buttonName;
	public Rect r;
	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {

	}

	void OnGUI(){
		if (GUI.Button ( r, buttonName)) 
		{
			Application.LoadLevel(sceneId);
		}
	}
}
