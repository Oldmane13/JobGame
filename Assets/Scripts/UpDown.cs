using UnityEngine;
using System.Collections;

public class UpDown : MonoBehaviour {

	Vector3 _startingPos;
	Transform _trans;
	public float time;
	
	void Start() {
		_trans = GetComponent<Transform>();
		_startingPos = _trans.position;
	}
	
	void Update() {
		_trans.position = new Vector3(_startingPos.x, _startingPos.y + Mathf.PingPong(Time.time, time), _startingPos.z);
	}
}