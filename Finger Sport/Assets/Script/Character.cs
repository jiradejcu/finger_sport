using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour
{
	Animator anim;
	Rigidbody2D rb;
	float jumpTimer = 0;
	const float defaultDeceleration = 0.05f;
	const float defaultAcceleration = 0.2f;
	
	void Start ()
	{
		anim = GetComponentInChildren <Animator> ();
		rb = GetComponent<Rigidbody2D> ();
	}

	void FixedUpdate ()
	{
		float acceleration = 0;
		if (Input.GetKey (KeyCode.RightArrow))
			acceleration = defaultAcceleration;

		if (acceleration > 0)
			rb.velocity += new Vector2 (acceleration, 0);
		else if(rb.velocity.magnitude > defaultAcceleration) {
			Vector2 decelerationVector = (-1) * rb.velocity;
			decelerationVector.Scale(new Vector2(defaultDeceleration, 0));
			rb.velocity += decelerationVector;
		} else
			rb.velocity = Vector2.zero;

		Debug.Log(rb.velocity);
	}
}
