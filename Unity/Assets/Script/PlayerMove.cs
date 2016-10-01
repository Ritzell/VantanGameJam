using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {
	[SerializeField]
	private float MoveSpeed = 10;
	private Coroutine WalkingCoroutine;
	// Use this for initialization
	void Start() {
		WalkingCoroutine = StartCoroutine(Walking());
		StartCoroutine(Debug());
	}

	// Update is called once per frame
	void Update() {

	}

	IEnumerator Debug()
	{
		while (true)
		{
			if (Input.GetKeyDown(KeyCode.Q))
			{
				StopWalking();
			}
			yield return null;
		}
	}

	IEnumerator Walking()
	{
		while (true)
		{
			if (Input.GetKey(KeyCode.A))
			{
				transform.Translate(-MoveSpeed * Time.deltaTime, 0, 0);
			}
			if (Input.GetKey(KeyCode.D))
			{
				transform.Translate(MoveSpeed * Time.deltaTime, 0, 0);
			}
			yield return null;
		}
	}

	public void StopWalking()
	{
		StopCoroutine(WalkingCoroutine);
	}
}
