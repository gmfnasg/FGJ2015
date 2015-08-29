using UnityEngine;
using System.Collections;

public class leafControl : MonoBehaviour {
	public GameObject leftLeaf;
	public GameObject rightLeaf;

	public bool ranReaf = false;

	// Use this for initialization
	void Start () {
		if (ranReaf) {
			if (Random.Range (1, 3) == 1) {
				leftLeaf.SetActive(false);
			} else {
				rightLeaf.SetActive(false);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
