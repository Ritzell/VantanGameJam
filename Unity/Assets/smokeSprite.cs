using UnityEngine;
using System.Collections;

public class smokeSprite : MonoBehaviour {
	[SerializeField]
	private Sprite[] smoke;

	private Coroutine smokeCoroutine;

	public void StartSmoke(){
		smokeCoroutine=StartCoroutine (smokeSprites());
	}

	// Update is called once per frame
	public IEnumerator smokeSprites(){
		int i = 0;
		while (true) {
			GetComponent<SpriteRenderer> ().sprite = smoke [i];
			i++;
			if (i == 5) {
				i = 5;
				goto next;
			}
			yield return new WaitForSeconds (0.15f);
		}

		next:
		while (true) {
			GetComponent<SpriteRenderer> ().sprite = smoke [i];
			i++;
			if (i > smoke.Length-1) {
				i = 5;
			}
			yield return new WaitForSeconds (0.1f);
		}
	}


	public void stopSmoke(){
		GetComponent<SpriteRenderer> ().sprite = null;
		StopCoroutine (smokeCoroutine);
	}
}
