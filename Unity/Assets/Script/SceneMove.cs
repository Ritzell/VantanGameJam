using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneMove : MonoBehaviour {
	public Scene TargetScene;
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			SceneManager.LoadSceneAsync ((int)TargetScene);
		}
	}
}
