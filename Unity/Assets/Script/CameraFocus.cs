using UnityEngine;
using System.Collections;

public class CameraFocus : MonoBehaviour {
	[SerializeField]
	private GameObject FocusTarget;

	public static bool isStop = false;
	// Use this for initialization
	void Start () {
		transform.position = new Vector3 (FocusTarget.transform.position.x + 2, FocusTarget.transform.position.y + 2.5f,transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public IEnumerator MoveToFocusTarget(){
		if (FocusTarget.transform.position.x + 2 > transform.position.x) {
			for (float time = 0; time < 1f; time += Time.deltaTime) {
				if (isStop) {
					yield break;
				} else {
					transform.position = Vector3.Slerp (transform.position, new Vector3 (FocusTarget.transform.position.x + 2, 2.5f, transform.position.z), time);
					yield return null;
				}
			}
			yield return null;
		}
	}
}
