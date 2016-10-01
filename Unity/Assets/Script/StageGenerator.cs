using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StageGenerator : MonoBehaviour {
	[SerializeField]
	private Player player;
	private int[] WaveNumber = new int[10];
	private int completeWave = 0;
	// Use this for initialization
	void Start () {
		for (int i = 0; i < WaveNumber.Length; i++) {
			WaveNumber [i] = Random.Range (5, 10);
		}
		StartCoroutine (Generation());
	}


	IEnumerator Generation(){
		int nowWave = 0;
		while (true) {
			if (player.floorob.transform.position.x < player.gameObject.transform.position.x) {
				nowWave++;
			}
			yield return null;
		}
	}
}
