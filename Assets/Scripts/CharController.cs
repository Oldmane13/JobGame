﻿using UnityEngine;
using System.Collections;

public class CharController : MonoBehaviour {
	
	public float maxSpeed = 10f;
	bool facingRight = true;
	bool contact;
	
	Animator anim;
	
	bool grounded = false;
	public Transform groundCheck;
	float groundRadius = 0.3f;
	public LayerMask whatIsGround;
	public float jumpForce = 700;
	
	public Transform firePoint;
	public GameObject projectile;
	
	void Start () {
		anim = GetComponent<Animator>();
	}
	
	
	void FixedUpdate () {
		
		grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
		
		anim.SetBool ("Ground", grounded);
		anim.SetFloat ("vSpeed", rigidbody2D.velocity.y);
		
		float move = Input.GetAxis ("Horizontal");
		
		anim.SetFloat("Speed", Mathf.Abs(move));
		
		rigidbody2D.velocity = new Vector2 (move * maxSpeed, rigidbody2D.velocity.y);
		
		if (move > 0 && !facingRight)
			Flip ();
		else if (move < 0 && facingRight)
			Flip ();		
	}
	
	void Update(){
		grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
		if(grounded && Input.GetKeyDown(KeyCode.Space)){
			audio.Play ();
			anim.SetBool("Ground", false);
			rigidbody2D.AddForce(new Vector2(0, jumpForce));
		}
		if (Input.GetKeyDown(KeyCode.Q)){
			
			Instantiate(projectile, firePoint.position, firePoint.rotation);
		}
		
	}
	
	void Flip(){		
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
