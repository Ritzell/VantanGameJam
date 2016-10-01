using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	[SerializeField]
	private float AttackFrequency = 1;
	[SerializeField]
	private GameObject InstanceWeapon;
	// Use this for initialization
	void Start() {
		StartCoroutine(Attack());
	}

	IEnumerator Attack()
	{
		while (true)
		{
			yield return new WaitForSeconds(AttackFrequency);
			Instantiate(InstanceWeapon,transform.position,transform.rotation);
			yield return null;
		}
	}

	// Update is called once per frame
	void Update () {

	}
}
