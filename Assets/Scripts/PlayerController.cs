using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	// creates speed, public allows easy editing
	public float speed;

	private Rigidbody rb;

	void Start () {
		rb = GetComponent<Rigidbody>();
	}
	

	void FixedUpdate () {
		// a float to hold horizontal input
		float moveHorizontal = Input.GetAxis ("Horizontal");
		// a float to hold vertical input
		float moveVertical = Input.GetAxis ("Vertical");

		// a vector3 to hold movement (direction) value
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		// adds force to player object based on horizontal and
		// vertical movement and a set player speed
		rb.AddForce (movement * speed);
	}
}
