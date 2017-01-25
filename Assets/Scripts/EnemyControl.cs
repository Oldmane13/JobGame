using UnityEngine;
using System.Collections;

public class EnemyControl : MonoBehaviour {
	
	
	public Transform target;
	public int moveSpeed;
	public int rotationSpeed;
	public int maxdistance;
	private Transform myTransform;
	
	
	void Awake()
	{
		myTransform = transform;
	}
	
	
	void Start ()
	{
		GameObject go = GameObject.FindGameObjectWithTag("Player");		
		target = go.transform;
		maxdistance = 2;
	}
	
	void Update ()
	{
		
		if (Vector3.Distance(target.position, myTransform.position) > maxdistance)
		{
			Vector3 dir = target.position - myTransform.position;
			dir.Normalize();
			myTransform.position += dir * moveSpeed * Time.deltaTime;
		}
	}
}