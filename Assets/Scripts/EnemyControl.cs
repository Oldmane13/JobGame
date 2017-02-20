using UnityEngine;
using System.Collections;

public class EnemyControl : MonoBehaviour {
	
	Animator anim;
	public Transform target;
	public int moveSpeed;
	public int rotationSpeed;
	public int maxdistance;
	private Transform myTransform;
	bool facingRight = true;
	public EnemyControl mob;
	
	
	void Awake()
	{
		myTransform = transform;
	}
	
	
	void Start ()
	{
		anim = GetComponent<Animator>();
		GameObject go = GameObject.FindGameObjectWithTag("Player");		
		target = go.transform;
		maxdistance = 0;
		mob = FindObjectOfType<EnemyControl>();
		
	}
	
	void Update ()
	{
		float move =Input.GetAxis ("Horizontal");
		
		//anim.SetFloat("eSpeed", Mathf.Abs(move));
		
		if (Vector3.Distance(target.position, myTransform.position) > maxdistance)
		{
			Vector3 dir = target.position - myTransform.position;
			dir.Normalize();
			myTransform.position += dir * moveSpeed * Time.deltaTime;
			
		}
	}
}