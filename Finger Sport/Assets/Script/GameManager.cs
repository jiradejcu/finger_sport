using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
	public float xOffset;
	const int floorCount = 5;
	Queue<GameObject> floorQueue;
	GameObject floorPrototype;
	float floorWidth;
	int floorIndex;
	const string startFloorName = "BG_start";
	const string tileFloorName = "BG_tile";

	// Use this for initialization
	void Start ()
	{
		floorQueue = new Queue<GameObject> ();
		floorPrototype = Resources.Load<GameObject> ("Prefabs/FloorPrototype");
		floorWidth = floorPrototype.GetComponent<BoxCollider2D> ().size.x;
		CreateStartFloor (new Vector3 (0f, 0f));
		for (floorIndex = 1; floorIndex < floorCount;) {
			CreateTileFloor (new Vector3 (floorWidth * floorIndex++, 0f));
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Camera.main.transform.position.x > floorQueue.Peek ().transform.position.x + xOffset) {
			CreateTileFloor (new Vector3 (floorWidth * floorIndex++, 0f));
			GameObject firstFloor = floorQueue.Dequeue ();
			Destroy (firstFloor);
		}
	}
	
	void CreateStartFloor (Vector3 position)
	{
		CreateFloor(position, startFloorName);
	}
	
	void CreateTileFloor (Vector3 position)
	{
		CreateFloor(position, tileFloorName);
	}

	void CreateFloor (Vector3 position, string floorName)
	{
		GameObject floorObject = Instantiate (floorPrototype, position, Quaternion.identity) as GameObject;
		GameObject floorSprite = Instantiate (Resources.Load<GameObject> ("Prefabs/" + floorName));
		floorSprite.transform.SetParent (floorObject.transform);
		floorSprite.transform.localPosition = Vector3.zero;
		floorQueue.Enqueue (floorObject);
	}
}
