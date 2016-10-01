using UnityEngine;
using System.Collections;

public class bullet : MonoBehaviour {
	[SerializeField]
	private float straightDistance = 5f;
	[SerializeField]
	private float bulletSpeed = 5;

	void Start () {
		StartCoroutine (homing ());
		StartCoroutine (Remove ());
	}

	IEnumerator homing(){
		GameObject player = FindObjectOfType<Player> ().gameObject;
		while (Vector3.Distance(player.transform.position , transform.position) > straightDistance) {
			transform.LookAt(player.transform);
			transform.Translate(0,0,bulletSpeed*Time.deltaTime);
			yield return null;
		}
		while (true) {
			transform.Translate(0,0,bulletSpeed*Time.deltaTime);
			yield return null;
		}
	}

	IEnumerator Remove(){
		yield return new WaitForSeconds (6);
		Destroy (gameObject);
	}
}
