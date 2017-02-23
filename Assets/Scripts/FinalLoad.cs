using UnityEngine;
using System.Collections;

public class FinalLoad : MonoBehaviour {

	void Start() {
		StartCoroutine(LoadingScreen());
	}
	
	IEnumerator LoadingScreen() {
		print(Time.time);
		yield return new WaitForSeconds(3);
		Application.LoadLevel("BossFight");
	}
}