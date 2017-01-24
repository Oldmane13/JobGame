using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {

	public string quit;	
	public bool isPaused;
	public GameObject pauseMenuCanvas;

	
	void Update () {
		
		if (isPaused){	
			pauseMenuCanvas.SetActive(true);
			Time.timeScale = 0f;			
		
		}else{			
			pauseMenuCanvas.SetActive(false);
			Time.timeScale = 1f;		
		}
	
		if (Input.GetKeyDown(KeyCode.Escape)){			
			audio.Play ();
			isPaused = !isPaused;
		}
	}
	
	public void Resume(){
		isPaused = false;
		audio.Play ();
	}
	
	public void Quit(){
		Application.Quit();	
	}
}
