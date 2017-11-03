using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WalkTracker : MonoBehaviour {

	private float closs_diff = 0.2f;
	private Animator animator;
	private ObjectMaker obj_mkr;

	// Use this for initialization
	private Vector2[] point3 = new Vector2[3]; 
	private int[] next_turn;
	private int[] reset_turn = new int[]{ 0, 0, 0, 0, 0, 0, 0, 0 };
	public int prev = 0;
	public int now = 1;
	public int next = 2;
	private bool prevback = false;
	private bool nowback = false;
	private bool nextback = false;
	private int max_goal_num;
	private int min_goal_num = 1;

	void Start () {
		obj_mkr = GameObject.Find( "ObjectMaker" ).GetComponent<ObjectMaker>();
		animator = GetComponent<Animator> ();
	}

	// Update is called once per frame
	void Update () {
		if (obj_mkr.next_stage) {
			AnimatorStateInfo state = animator.GetCurrentAnimatorStateInfo (0);
			if (state.IsName ("Show Layer.walk")) {
				transform.LookAt (obj_mkr.goal_anchors [next]);
				transform.eulerAngles = new Vector3 (0, transform.eulerAngles.y, 0);
			}
			if (!state.IsName ("Show Layer.stop") && !state.IsName ("Show Layer.walk")) {
				if (!animator.GetBool ("walk")) {
					animator.SetBool ("walk", true);
					set_turn_bool (reset_turn);
					animator.SetBool ("stop", false);
					Debug.Log (next);
				}
			}
			if (is_positions_cross (transform.position, obj_mkr.goal_anchors [next])) {
				if (!animator.GetBool ("stop")) {
					animator.SetBool ("stop", true);
					animator.SetBool ("walk", false);
					go_next ();
					chose_angle (obj_mkr.goal_anchors);
				}
			}
		}
	}

	public void init_walkstage(){
		max_goal_num = obj_mkr.goal_num - 1;
	}

	bool is_positions_cross(Vector3 a, Vector3 b){
		bool res = false;
		float x_diff = (a.x - b.x) * (a.x - b.x);
		float z_diff = (a.z - b.z) * (a.z - b.z);
		if (x_diff < closs_diff && z_diff < closs_diff) {
			res = true;
		}
		return res;
	}
		
	void chose_angle(Vector3[] v3){
		point3 [0] = new Vector2 (v3 [prev].x, v3 [prev].z);
		point3 [1] = new Vector2 (v3 [now].x, v3 [now].z);
		point3 [2] = new Vector2 (v3 [next].x, v3 [next].z);
	
		float theta = Vector2.SignedAngle (point3 [2] - point3 [1], point3 [1] - point3 [0]);
		if (-25f <= theta && theta < 25f) {
			next_turn = new int[]{ 0, 0, 0, 0, 0, 0, 0, 1 };
		} else if (25f <= theta && theta < 65f) {
			next_turn = new int[]{ 1, 0, 0, 0, 0, 0, 0, 0 };
		} else if (65f <= theta && theta < 110f) {
			next_turn = new int[]{ 0, 1, 0, 0, 0, 0, 0, 0 };
		} else if (110f <= theta && theta < 155f) {
			next_turn = new int[]{ 0, 0, 1, 0, 0, 0, 0, 0 };
		} else if (-65f <= theta && theta < -25f) {
			next_turn = new int[]{ 0, 0, 0, 1, 0, 0, 0, 0 };
		} else if (-110f <= theta && theta < -65f) {
			next_turn = new int[]{ 0, 0, 0, 0, 1, 0, 0, 0 };
		} else if (-155f <= theta && theta < -110f) {
			next_turn = new int[]{ 0, 0, 0, 0, 0, 1, 0, 0};
		} else {
			next_turn = new int[]{ 0, 0, 0, 0, 0, 0, 1, 0 };
		}
		set_turn_bool (next_turn);
	}

	void set_turn_bool(int[] next_turn){
		animator.SetBool ("turnR45", Convert.ToBoolean(next_turn[0]));
		animator.SetBool ("turnR90", Convert.ToBoolean(next_turn[1]));
		animator.SetBool ("turnR135", Convert.ToBoolean(next_turn[2]));
		animator.SetBool ("turnL45", Convert.ToBoolean(next_turn[3]));
		animator.SetBool ("turnL90", Convert.ToBoolean(next_turn[4]));
		animator.SetBool ("turnL135", Convert.ToBoolean(next_turn[5]));
		animator.SetBool ("turnR180", Convert.ToBoolean(next_turn[6]));
		animator.SetBool ("noturn", Convert.ToBoolean(next_turn[7]));
	}

	void go_next(){
		if (prev == max_goal_num) {
			prevback = true;
		}
		if (prev == min_goal_num) {
			prevback = false;
		}
		if (now == max_goal_num) {
			nowback = true;
		}
		if (now == min_goal_num) {
			nowback = false;
		}
		if (next == max_goal_num) {
			nextback = true;
		}
		if (next == min_goal_num) {
			nextback = false;
		}

		if (prevback) {
			prev--;
		} else {
			prev++;
		}
		if (nowback) {
			now--;
		} else {
			now++;
		}
		if (nextback) {
			next--;
		} else {
			next++;
		}
	}

}
