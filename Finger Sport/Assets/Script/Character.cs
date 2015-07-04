using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour
{
	Animator anim;
	Rigidbody2D rb;
	float jumpTimer = 0;
	const float defaultDeceleration = 0.05f;
	const float defaultAcceleration = 0.2f;
	const float walkThreshold = 5f;
	const float runThreshold = 20f;
	const float walkMaxAnimSpeedOffset = 2f;
	const float runMaxAnimSpeedOffset = 1f;
	const string speedParamName = "Speed";
	
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
		else if (rb.velocity.magnitude > defaultAcceleration) {
			Vector2 decelerationVector = (-1) * rb.velocity;
			decelerationVector.Scale (new Vector2 (defaultDeceleration, 0));
			rb.velocity += decelerationVector;
		} else
			rb.velocity = Vector2.zero;

		if (rb.velocity.magnitude > 0) {
			int speedParam;
			float animSpeedOffset;

			if(rb.velocity.magnitude < walkThreshold){
				speedParam = 1;
				animSpeedOffset = rb.velocity.magnitude / walkThreshold * walkMaxAnimSpeedOffset;
			} else {
				speedParam = 2;
				animSpeedOffset = (rb.velocity.magnitude - walkThreshold) / (runThreshold - walkThreshold) * runMaxAnimSpeedOffset;

				if(animSpeedOffset > runMaxAnimSpeedOffset)
					animSpeedOffset = runMaxAnimSpeedOffset;
			}
			Debug.Log(speedParam + " AnimSpeedOffset : " + animSpeedOffset);
			anim.SetInteger (speedParamName, speedParam);
			anim.speed = animSpeedOffset + 1;
		} else {
			anim.SetInteger (speedParamName, 0);
			anim.speed = 1;
		}

		Debug.Log ("Velocity : " + rb.velocity);
	}
}
