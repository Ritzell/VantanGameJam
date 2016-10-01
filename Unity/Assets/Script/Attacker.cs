using UnityEngine;
using System.Collections;

public class Attacker : MonoBehaviour {
	[SerializeField]
	private float Power = 0;
	[SerializeField]
	private int[] AttackTargetLayerNumber;
	[SerializeField]
	private bool isDestroy = false;
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter(Collider col)
	{

		foreach(int layerNumber in AttackTargetLayerNumber)
		{
			if(col.gameObject.layer == layerNumber)
			{
				goto isTarget;
			}
		}
		return;

		isTarget:
		if (col.gameObject.GetComponent<Character>())
		{
			col.gameObject.SendMessage("ApplyDamage", Power);
			if (isDestroy)
			{
				Destroy(gameObject);
			}
		}
	}
}
