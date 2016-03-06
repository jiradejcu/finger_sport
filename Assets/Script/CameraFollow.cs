using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{
	public GameObject target;
	public float xOffset;
	
	// Update is called once per frame
	void Update ()
	{
		transform.position = new Vector3 (target.transform.position.x + xOffset, transform.position.y, transform.position.z);
	}
}
