using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandPerformance : MonoBehaviour {

	private Animator animator;
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		AnimatorStateInfo state = animator.GetCurrentAnimatorStateInfo (0);
		checkisFocus ();
		if (state.IsName ("Base Layer.Idle_Stance_1")) {
			
		}
	}
	void checkisFocus(){
		float dot =Vector3.Dot (Camera.main.transform.forward, this.transform.forward);
		Debug.Log (dot);
		if(dot<-0.8f)
			animator.SetBool ("isFocus", true);
		else
			animator.SetBool ("isFocus", false);
	}
}
