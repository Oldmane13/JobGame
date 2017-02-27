using UnityEngine;
using System.Collections;

public class EndButton : MonoBehaviour {

	public GameObject canvas;
	public string quit;
	
	public void Reload(){
		Application.Quit ();
	}
	
}
