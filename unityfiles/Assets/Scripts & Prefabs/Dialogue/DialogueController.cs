using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System;
using System.IO;

public class DialogueController : MonoBehaviour {


	public string TextToPlay,portrait,emotion,animation_,dialogue;

	public Text textobject;

	public Image PortraitObject;

	private bool textrunning;

	protected List<string> splitext = new List<string>();

	public string text_;

	private StreamReader reader = null;

	private FileInfo info;

	private int nextblock;

	public string filepath;

	public Sprite[] MaxEmotions,RexEmotions;

	public CanvasGroup fadecanvas;

	public GameObject player;
	// Use this for initialization
	void Start () {
		
		//get the file and open it
		info = new FileInfo(filepath);

		reader = info.OpenText ();

		fadecanvas = this.GetComponent<CanvasGroup> ();


	}
	
	// Update is called once per frame
	void Update () {

		//loops through and reads the lines and adds them to a list
		if (text_ != null) {
			text_ = reader.ReadLine ();

			if (text_ == null) {
			} else {
				splitext.Add (text_);
			}

		}
	}


	public void RunText()
	{
		//starts the type writer
		TextToPlay = dialogue;
		//throws in  a check to make sure we dont repeat ourselves
		if (textobject.text != TextToPlay) {
			StartCoroutine ("TextType");
		}
		textrunning = true;	
	}

	IEnumerator TextType()
	{
		//prints text 1 by 1
		textrunning = true;

		foreach (char letter in TextToPlay.ToCharArray()) {

			textobject.text += letter;
			yield return new WaitForSeconds (.02F);
		}      

	}

	public void buttonclick()
	{
		

			//checks if text is running
			if (textrunning) {
				StopCoroutine ("TextType");
				textobject.text = "";
				textobject.text = TextToPlay;
				nexttext ();
				RunText ();
				return;
			}

			if (!textrunning) {
				nexttext ();
				RunText ();
			}

	}


	void nexttext()
	{


		//from the list it takes the lines 1 - 4 and adds them to the specific single strings. 
		if (nextblock != splitext.Count) {

			textobject.text = "";
			portrait = splitext [nextblock];
			nextblock += 1;
			emotion = splitext [nextblock];
			nextblock += 1;
			animation_ = splitext [nextblock];
			nextblock += 1;
			dialogue = splitext [nextblock];
			nextblock += 1;

			PortraitSetter ();


		} else {
			Debug.Log ("Reached end of file");
			StartCoroutine ("fadeout");
		}
	}


	void PortraitSetter()
	{

		Debug.Log ("RUN");
		int i;
		i = Int32.Parse (emotion);

		if (portrait == "max") {
			Debug.Log ("Change Max");
			PortraitObject.sprite = MaxEmotions [i];
		}

		if (portrait == "rex") {
			PortraitObject.sprite = RexEmotions [i];
			Debug.Log ("Change Rex");
		}


	}

	public IEnumerator fadeout()
	{
		while (fadecanvas.alpha > 0) {
			fadecanvas.alpha -= .25F * Time.deltaTime;
			yield return null;
		}

		if (fadecanvas.alpha == 0) {
			UnlockCharacter ();
			StopCoroutine ("fadeout");
		}
	}

	void UnlockCharacter()
	{

	}
}
