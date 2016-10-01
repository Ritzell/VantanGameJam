using UnityEngine;
using System.Collections;

public enum ItemDate{
	Up,
	VeryUp
}
public class Item : MonoBehaviour {
	public ItemDate itemDate;
	private float UpLevel = 1.5f;
	private float VeryUpLevel = 2;

	void OnCollisionEnter(){
		Player player = FindObjectOfType<Player> ();
		player.StartCoroutine (player.SpeedUp((int)itemDate == (int)ItemDate.Up ? UpLevel : VeryUpLevel));
		Destroy (gameObject);
	}
}
