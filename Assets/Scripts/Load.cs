using UnityEngine;
using System.Collections;

public class Load : MonoBehaviour {
	
	void Start() {
		StartCoroutine(LoadingScreen());
	}
	
	IEnumerator LoadingScreen() {
		print(Time.time);
		yield return new WaitForSeconds(3);
		Application.LoadLevel("Level1");
	}
	
}