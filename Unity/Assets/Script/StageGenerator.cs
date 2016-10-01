using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StageGenerator : MonoBehaviour {
	[SerializeField]
	private Player player;
	[SerializeField]
	private GameObject[] Waves;
	private int[] WaveNumber = new int[10];
	[SerializeField]
	private GameObject completeFloor;
	// Use this for initialization
	void Start () {
		for (int i = 0; i < WaveNumber.Length; i++) {
			WaveNumber [i] = Random.Range (0, Waves.Length-1);
		}
		StartCoroutine (Generation());
	}


	IEnumerator Generation(){
		int nowWave = 0;
		while (true) {
			if (player.floorob.transform.position.x < player.gameObject.transform.position.x && player.floorob != completeFloor) {
				nowWave++;
				completeFloor = player.floorob;
				Debug.Log (Waves.Length + " and " + WaveNumber [nowWave]);
				Instantiate (Waves [WaveNumber [nowWave]], new Vector3 (completeFloor.transform.position.x + 35, completeFloor.transform.position.y+1, 0), Quaternion.identity);
			}
			yield return null;
		}
	}
}
