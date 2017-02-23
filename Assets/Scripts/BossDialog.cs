using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class BossDialog : MonoBehaviour
{
	private Text _textComponent;
	
	public string[] DialogueStrings;
	
	public float SecondsBetweenCharacters = 0.15f;
	public float CharacterRateMultiplier = 0.5f;
	
	public KeyCode DialogueInput1 = KeyCode.Space;
	public KeyCode DialogueInput2 = KeyCode.Space;
	
	private bool _isStringBeingRevealed = false;
	private bool _isDialoguePlaying = false;
	private bool _isEndOfDialogue = false;
	
	public GameObject ContinueIcon;
	public GameObject StopIcon;
	public GameObject barrier;
	public Transform barrierSpawn;
	
	// Use this for initialization
	void Start ()
	{
		_textComponent = GetComponent<Text>();
		_textComponent.text = "";
		
		
		HideIcons();
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		
		if (!_isDialoguePlaying)
		{
			_isDialoguePlaying = true;
			StartCoroutine(StartDialogue());
		}
		
		
	}
	
	private IEnumerator StartDialogue()
	{
		int dialogueLength = DialogueStrings.Length;
		int currentDialogueIndex = 0;
		
		while (currentDialogueIndex < dialogueLength || !_isStringBeingRevealed)
		{
			if (!_isStringBeingRevealed)
			{
				_isStringBeingRevealed = true;
				audio.Play();
				StartCoroutine(DisplayString(DialogueStrings[currentDialogueIndex++]));
				
				if (currentDialogueIndex >= dialogueLength)
				{
					_isEndOfDialogue = true;
					bosstrigger.inTrigger = true;
					Instantiate(barrier, barrierSpawn.position, barrierSpawn.rotation);
				}
			}
			
			yield return 0;
		}
		
		while (true)
		{
			if (Input.GetKeyDown(DialogueInput1))
			{
				break;
			}
			
			yield return 0;
		}
		
		HideIcons();
		_isEndOfDialogue = false;
		_isDialoguePlaying = false;
	}
	
	private IEnumerator DisplayString(string stringToDisplay)
	{
		int stringLength = stringToDisplay.Length;
		int currentCharacterIndex = 0;
		
		HideIcons();
		
		_textComponent.text = "";
		
		while (currentCharacterIndex < stringLength)
		{
			_textComponent.text += stringToDisplay[currentCharacterIndex];
			currentCharacterIndex++;
		
			
			if (currentCharacterIndex < stringLength)
			{
				if (Input.GetKey(DialogueInput1))
				{
					yield return new WaitForSeconds(SecondsBetweenCharacters*CharacterRateMultiplier);
				}
				else
				{
					yield return new WaitForSeconds(SecondsBetweenCharacters);
				}
			}
			else
			{
				break;
			}
		}
		
		ShowIcon();
		
		while (true)
		{
			if (Input.GetKeyDown(DialogueInput1))
			{
				break;
			}
			
			yield return 0;
		}
		
		HideIcons();
		
		_isStringBeingRevealed = false;
		_textComponent.text = "";
	}
	
	private void HideIcons()
	{
		ContinueIcon.SetActive(false);
		StopIcon.SetActive(false);
	}
	
	private void ShowIcon()
	{
		if (_isEndOfDialogue)
		{
			StopIcon.SetActive(true);
			bosstrigger.inTrigger = true;
			Instantiate(barrier, barrierSpawn.position, barrierSpawn.rotation);
			//Destroy(gameObject);			
		}
		audio.Stop();
		ContinueIcon.SetActive(true);
	}
}
