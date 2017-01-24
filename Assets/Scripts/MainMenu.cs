using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

public string startLevel;
public string quit;

public void NewGame(){
	Application.LoadLevel("OpeningText");
	}

public void QuitGame(){
	Application.Quit();

	}
}