using UnityEngine;
using System.Collections;

public class bullet : MonoBehaviour {
	void Update () {
		transform.LookAt(FindObjectOfType<Player>().transform);
		transform.Translate(0,0,5*Time.deltaTime);
	}
}
