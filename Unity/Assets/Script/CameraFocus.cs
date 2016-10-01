using UnityEngine;
using System.Collections;

public class CameraFocus : MonoBehaviour {
	[SerializeField]
	private GameObject FocusTarget;
	// Use this for initialization
	void Start () {
		transform.position = new Vector3 (FocusTarget.transform.position.x + 2, FocusTarget.transform.position.y + 2.5f,transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void MoveToFocusTarget(){
		transform.position = new Vector3 (FocusTarget.transform.position.x + 2, 2.5f,transform.position.z);
	}
}
