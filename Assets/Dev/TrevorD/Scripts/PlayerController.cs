using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public int walkSpeed;
	public int sprintSpeed;
	public int jumpHeight;
	public int maxJumps;
	public Transform groundCheck;
	public float groundCheckRadius;
	public LayerMask groundLayer;
	
	private int numJumps;
	private Rigidbody playerBody;

	void Start () {
		numJumps = 0;
		playerBody = GetComponent<Rigidbody> ();
	}

	void Update () {
		if (grounded())
			numJumps = 0;

		//Using literal binds for now
		//Also Movements are based on velocity pushes, will change to transforms later
		if (Input.GetKeyDown(KeyCode.Space) && canJump() && grounded()) 
		{
			playerBody.velocity = new Vector3(playerBody.velocity.x, jumpHeight, playerBody.velocity.z);
			numJumps++;
		}
		if (Input.GetKeyDown(KeyCode.Space) && canJump() && !grounded()) 
		{
			playerBody.velocity = new Vector3(playerBody.velocity.x, jumpHeight, playerBody.velocity.z);
			numJumps++;
		}
		if (Input.GetKey(KeyCode.W)) 
		{
			if (Input.GetKey(KeyCode.LeftShift)){
				playerBody.velocity = new Vector3(playerBody.velocity.x, playerBody.velocity.y, sprintSpeed);
			}else{
				playerBody.velocity = new Vector3(playerBody.velocity.x, playerBody.velocity.y, walkSpeed);
			}
		}
		if (Input.GetKey(KeyCode.S)) 
		{
			if (Input.GetKey(KeyCode.LeftShift)){
				playerBody.velocity = new Vector3(playerBody.velocity.x, playerBody.velocity.y, -sprintSpeed);
			}else{
				playerBody.velocity = new Vector3(playerBody.velocity.x, playerBody.velocity.y, -walkSpeed);
			}
		}
		if (Input.GetKey(KeyCode.D)) 
		{
			if (Input.GetKey(KeyCode.LeftShift)){
				playerBody.velocity = new Vector3(sprintSpeed, playerBody.velocity.y, playerBody.velocity.z);
			}else{
				playerBody.velocity = new Vector3(walkSpeed, playerBody.velocity.y, playerBody.velocity.z);
			}
		}
		if (Input.GetKey(KeyCode.A)) 
		{
			if (Input.GetKey(KeyCode.LeftShift)){
				playerBody.velocity = new Vector3(-sprintSpeed, playerBody.velocity.y, playerBody.velocity.z);
			}else{
				playerBody.velocity = new Vector3(-walkSpeed, playerBody.velocity.y, playerBody.velocity.z);
			}
		}
	}

	private bool grounded()
	{
		return Physics.CheckSphere (groundCheck.position, groundCheckRadius, groundLayer);
	}
	private bool canJump()
	{
		return numJumps < maxJumps;
	}
	private float absoluteVelocityX(){
		float absolute = Mathf.Abs (GetComponent<Rigidbody2D> ().velocity.x);
		if (absolute < 0)
			absolute = -absolute;
		return absolute;
	}
}
