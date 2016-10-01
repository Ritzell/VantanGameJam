using UnityEngine;
using System.Collections;

public class SpeedUpSprite : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine (MoveUp ());
	}
	
	IEnumerator MoveUp(){
		float time = 0;
		while (true) {
			time += Time.deltaTime;
			transform.Translate (0,2*Time.deltaTime,0);
			transform.GetComponent<SpriteRenderer> ().color = new Color (1,1,1,transform.GetComponent<SpriteRenderer> ().color.a - Time.deltaTime);
			if (time > 1) {
				Destroy (gameObject);
				yield break;
			}
			yield return null;
		}
	}
}
