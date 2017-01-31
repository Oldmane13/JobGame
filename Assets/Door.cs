using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {

	public static bool doorKey;
	public bool open = false;
	public bool close;
	public bool inTrigger;
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag == "Player"){
			inTrigger = true;
		}
	}
	
	void OnTriggerExit2D(Collider2D other)
	{
		inTrigger = false;
	}
	
	void Update()
	{
		if (inTrigger)
		{
			if (doorKey)
			{
				open = true;
				if (Input.GetKeyDown(KeyCode.E))
				{
					Destroy(gameObject);
				}
			}
		}
	}
	void OnGUI()
	{
		if (inTrigger)
		{
			if(doorKey)
			{
				GUI.Box(new Rect(0, 60, 200, 25), "Press E to open door");
			}
			else{
				GUI.Box(new Rect(0, 60, 200, 25), "Need key");
			}
		}
	}
}
