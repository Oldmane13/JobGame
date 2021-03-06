﻿using UnityEngine;
using System.Collections;

public class Answer : MonoBehaviour {

	public float speed;
	private float angle;
	public float timeBeforeGone;
	public static Animator answerAnim;
	// Use this for initialization
	void Start () {
		angle = Random.Range(-5,5);
		answerAnim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
		void Update () {
			
			rigidbody2D.velocity = new Vector2(angle, speed);	
			StartCoroutine("Wait");
		}
		
		IEnumerator Wait(){
		
		yield return new WaitForSeconds(timeBeforeGone);
		Destroy(gameObject);
		}
	
	}

