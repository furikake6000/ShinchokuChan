using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageIcon : MonoBehaviour {

	private ParticleSystem ps;
	private Animator animator;
	private MessageObject triggerMessage;

	// Use this for initialization
	void Start () {
		ps = GetComponent<ParticleSystem> ();
		animator = GetComponent<Animator> ();
		triggerMessage = transform.parent.gameObject.GetComponent<MessageObject> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter() {
		animator.SetBool ("enabled", true);
	}

	void OnTriggerExit() {
		animator.SetBool ("enabled", false);
	}

	void OnTriggerStay() {
		if (Input.GetKey (KeyCode.Z) || Input.GetKey (KeyCode.Return)) {
			triggerMessage.LaunchNovelPart();
		}
	}

	void OnAnimationEnd() {
		ps.Emit (10);
	}
}
