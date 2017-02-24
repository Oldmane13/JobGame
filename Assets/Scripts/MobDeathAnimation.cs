using UnityEngine;
using System.Collections;

public class MobDeathAnimation : MonoBehaviour {
	public float timeBeforeGone;

	void Update(){
	StartCoroutine("Wait");
	}
	
	IEnumerator Wait(){
		
		yield return new WaitForSeconds(timeBeforeGone);
		Destroy(gameObject);
	}
}
