using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {
	[SerializeField]
	private float Acceleration = 1;
	[SerializeField]
	private float JumpPower = 1;

	private bool isOnFloor = true;
	private Coroutine WalkingCoroutine;
	private Vector3 screenPos;
	// Use this for initialization
	void Start() {
		StartCoroutine(Walking());
		StartCoroutine (Jump ());
	}

	void Update(){
		screenPos = Camera.main.WorldToScreenPoint (transform.position);
	}

	void OnCollisionEnter(Collision col){
		if(col.gameObject.layer == (int)Layer.Floor){
			isOnFloor = true;
		}
	}

	void OnCollisionExit(Collision col){
		if(col.gameObject.layer == (int)Layer.Floor){
			isOnFloor = false;
		}
	}

	IEnumerator Walking()
	{
		
		while (true) {
			float x = Input.GetAxis ("Horizontal");
			Rigidbody rigidbody = GetComponent<Rigidbody> ();
			if (!(x < 0 && screenPos.x < 20)) {//画面の左端にいなければ
				rigidbody.AddForce (x * Vector3.right * Acceleration, ForceMode.VelocityChange);//移動
			} else {
				rigidbody.velocity = Vector3.zero;
			}

			if (x > 0 && screenPos.x > Screen.width / 3) {//画面の左半分半ばに入ればカメラが付いていく。
				FindObjectOfType<CameraFocus> ().MoveToFocusTarget ();
			}
			yield return null;
		}
	}

	IEnumerator Jump(){
		while (true) {
			Rigidbody rigidbody = GetComponent<Rigidbody>();
			if (Input.GetKeyDown (KeyCode.Space) && isOnFloor) {
				rigidbody.AddForce (JumpPower * Vector3.up, ForceMode.Force);
			}
			yield return null;
		}
	}

	public void StopWalking()
	{
		StopCoroutine(WalkingCoroutine);
	}
}
