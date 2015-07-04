using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour
{
	private Animator anim;
	private float jumpTimer = 0;
	
	void Start ()
	{
		anim = GetComponentInChildren <Animator> ();
	}

	void Update ()
	{
		float acceleration = Time.deltaTime;
		if (Input.GetKey (KeyCode.RightArrow))
			acceleration = -acceleration;

//		if(anim.GetInteger("Speed") < 0)
//			acceleration = anim.GetInteger("Speed");

//		anim.SetInteger ("Speed", anim.GetInteger("Speed") - acceleration);
	}
}
