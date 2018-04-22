using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageObject : MonoBehaviour {
	public GameObject messageIcon;
	public string messageText;
	public TextAsset messageTextAsset;

	static GameObject novelCanvas;

	// Use this for initialization
	void Start () {
		GameObject.Instantiate (messageIcon, transform);
		if (novelCanvas == null) {
			novelCanvas = GameObject.FindWithTag ("NovelCanvas");
			novelCanvas.SetActive (false);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void LaunchNovelPart() {
		Debug.Log ("Console Part!");
		novelCanvas.SetActive (true);
	}
}
