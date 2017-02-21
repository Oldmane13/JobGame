using UnityEngine;
using System.Collections;

public class ShootPlayerInRange : MonoBehaviour {

	public float playerRange;
	
	public GameObject projectile;
	
	public CharController player;
	
	public Transform shootArea;
	public float waitBetweenShots;
	private float shotCounter;
	public static bool contact;
	private bool inRange;
	public int i;
	public ProjectileController bullet;
	public ShootPlayerInRange boss;
	
	public GameObject text1;
	public GameObject text2;
	
	// Use this for initialization
	void Start () {
	contact = false;
		text1.SetActive(false);
		text2.SetActive (false);
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
			
		if (inRange){
			if (Input.GetKeyDown(KeyCode.Space)){
				text1.SetActive(false);			
			}	
	}
	
}

	IEnumerator bossact(){
	
		Debug.DrawLine(new Vector3(transform.position.x - playerRange, transform.position.y, transform.position.z), new Vector3(transform.position.x + playerRange, transform.position.y, transform.position.z));
		shotCounter -= Time.deltaTime;
		
		if(transform.localScale.x > 0 && player.transform.position.x < transform.position.x && player.transform.position.x > transform.position.x - playerRange && shotCounter < 0){
			Instantiate(projectile, shootArea.position, shootArea.rotation);
			shotCounter = waitBetweenShots;
			i++;
		}
		if (i==2){
		ProjectileController.anim.SetBool ("bullet1", true);
		}
		if (i==3){
			ProjectileController.anim.SetBool ("bullet2", true);
		}
		if (i == 8){
			inRange = true;
			contact = false;
			text1.SetActive(true);
			Destroy(gameObject);
			
		}
		yield return null;
	}
}