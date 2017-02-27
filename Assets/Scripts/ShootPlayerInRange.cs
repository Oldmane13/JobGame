using UnityEngine;
using System.Collections;

public class ShootPlayerInRange : MonoBehaviour {

	public float playerRange;
	
	public GameObject projectile;
	
	public CharController player;
	
	public GameObject barrier;
	public Transform barrierSpawn;

	
	public Transform shootArea;
	public float waitBetweenShots;
	private float shotCounter;
	public static bool contact;

	public static int i;
	public ProjectileController bullet;
	public ShootPlayerInRange boss;
	
	public GameObject text1;
	public GameObject text2;
	//public GameObject panel;
	
	public static Animator anim;
	
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		contact = false;
		text1.SetActive(false);
		text2.SetActive (false);
		//panel.SetActive(false);
		bullet = (ProjectileController)this.GetComponent(typeof(ProjectileController));
		boss = FindObjectOfType<ShootPlayerInRange>();
		player = FindObjectOfType<CharController>();
		shotCounter = waitBetweenShots;
		i = 0;
	}
	
	
	// Update is called once per frame
	void Update () {
		if (contact)
		
		StartCoroutine("bossact");
			
		if(i==8){
			StopCoroutine("bossact");
			anim.SetBool("Fight",false);
			CharController.anim.SetFloat("Speed",0f);
			text2.SetActive(true);
			//panel.SetActive(true);
			contact = false;
			player.enabled = false;

			}
	
}

	IEnumerator bossact(){
		anim.SetBool("Fight", true);
		Debug.DrawLine(new Vector3(transform.position.x - playerRange, transform.position.y, transform.position.z), new Vector3(transform.position.x + playerRange, transform.position.y, transform.position.z));
		shotCounter -= Time.deltaTime;
		
		if(transform.localScale.x > 0 && player.transform.position.x < transform.position.x && player.transform.position.x > transform.position.x - playerRange && shotCounter < 0){
			Instantiate(projectile, shootArea.position, shootArea.rotation);
			shotCounter = waitBetweenShots;
			//i++;
		}
		if (i==1){
			ProjectileController.anim.SetBool ("bullet1", true);
		}
		if (i==2){
			ProjectileController.anim.SetBool ("bullet2", true);
		}
		if (i==3){
			ProjectileController.anim.SetBool ("bullet3", true);
		}
		if (i==4){
			ProjectileController.anim.SetBool ("bullet4", true);
		}
		if (i==5){
			ProjectileController.anim.SetBool ("bullet5", true);
		}
		if (i==6){
			ProjectileController.anim.SetBool ("bullet6", true);
		}
		if (i==7){
			ProjectileController.anim.SetBool ("bullet7", true);
		}

		yield return null;
	}
}