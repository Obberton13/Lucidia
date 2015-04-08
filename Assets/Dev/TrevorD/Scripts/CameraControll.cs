using UnityEngine;
using System.Collections;

public class CameraControll : MonoBehaviour {

	private PlayerController player;
	private Vector3 viewPos;
	
	
	public void Start () {
		player = FindObjectOfType<PlayerController> ();
	}
	
	
	public void Update () {
		viewPos = new Vector3(player.transform.position.x, transform.position.y, (player.transform.position.z - 16));
		transform.position = viewPos;
	}
}
