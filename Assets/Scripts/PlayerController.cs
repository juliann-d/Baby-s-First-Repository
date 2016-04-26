using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

	// creates speed, public allows easy editing
	public float speed;

	private Rigidbody rb;

	// counts number of pickups
	private int count;

	// text displaying pickup count
	public Text countText;

	// text displaying win text after winning
	public Text winText;

	void Start ()
	{
		rb = GetComponent<Rigidbody>();
		count = 0;
		SetCountText();
		winText.text = "";
	}

	void FixedUpdate ()
	{
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

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag ("PickUp"))
		{
			other.gameObject.SetActive (false);
			count = count + 1;
			SetCountText();
		}
	}

	void SetCountText()
	{
		// count text is number of pickups
		countText.text = "Count: " + count.ToString();

		// if all pickups are picked up, you win! nerd.
		if (count >= 5)
		{
			winText.text = "You Win!";
		}
	}
}
