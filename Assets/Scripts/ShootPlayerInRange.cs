using UnityEngine;
using System.Collections;

public class ShootPlayerInRange : MonoBehaviour {

	public float playerRange;
	
	public GameObject projectile;
	
	public CharController player;
	
	public Transform shootArea;
	public float waitBetweenShots;
	private float shotCounter;
	private bool inRange;
	
	// Use this for initialization
	void Start () {
		player = FindObjectOfType<CharController>();
		
		shotCounter = waitBetweenShots;
	}
	
	// Update is called once per frame
	void Update () {
		Debug.DrawLine(new Vector3(transform.position.x - playerRange, transform.position.y, transform.position.z), new Vector3(transform.position.x + playerRange, transform.position.y, transform.position.z));
		shotCounter -= Time.deltaTime;
		
		if(transform.localScale.x < 0 && player.transform.position.x > transform.position.x && player.transform.position.x < transform.position.x + playerRange && shotCounter < 0){
		
			Instantiate(projectile, shootArea.position, shootArea.rotation);
			shotCounter = waitBetweenShots;
		}
		
		if(transform.localScale.x > 0 && player.transform.position.x < transform.position.x && player.transform.position.x > transform.position.x - playerRange && shotCounter < 0){
			
			Instantiate(projectile, shootArea.position, shootArea.rotation);
			shotCounter = waitBetweenShots;
		}
	}
	
	
}
