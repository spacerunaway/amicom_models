using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.iOS;
using UnityEngine.EventSystems;

public class ObjectController : MonoBehaviour {
	private ObjectMaker obj_mkr;

	void Start(){
		obj_mkr = GameObject.Find( "ObjectMaker" ).GetComponent<ObjectMaker>();
	}

	void Update(){
	}
		
	public void next_obj(){
		if (obj_mkr.obj_num < obj_mkr.goal_num) {
			obj_mkr.obj_num++;
		}
	}
	public void prev_obj(){
		if (obj_mkr.obj_num > 0) {
			obj_mkr.obj_num--;
		}
	}
	public void LookAt(){
		obj_mkr.crated_obj[obj_mkr.obj_num].transform.LookAt (Camera.main.transform.position);
		obj_mkr.crated_obj[obj_mkr.obj_num].transform.eulerAngles = new Vector3 (0, transform.eulerAngles.y, 0);
	}

	public void Bigger(){
		obj_mkr.crated_obj[obj_mkr.obj_num].transform.localScale += new Vector3 (0.1f, 0.1f, 0.1f);
	}

	public void Smaller(){
		if (obj_mkr.crated_obj[obj_mkr.obj_num].transform.localScale.x > 0.1f) {
			obj_mkr.crated_obj[obj_mkr.obj_num].transform.localScale -= new Vector3 (0.1f, 0.1f, 0.1f);
		} 
	}

	public void Trun_left(){
		obj_mkr.crated_obj[obj_mkr.obj_num].transform.Rotate(new Vector3 (0, -5, 0));
	}

	public void Trun_right(){
		obj_mkr.crated_obj[obj_mkr.obj_num].transform.Rotate(new Vector3 (0, 5, 0));
	}

}
	/*
	private float[] angle_vector2(float[] cos){
		float[] res = new float[cos.Length];
		for (int i = 0; i < cos.Length; i++) {
			res [i] = Mathf.Acos(cos [i]) * Mathf.Rad2Deg;
		}
		return res;
	}

	private float[] cos_vector2(Vector2[] v2){
		float[] res = new float[v2.Length];
		for (int i = 1; i < v2.Length; i++) {
			Vector2 va = v2 [(i + 1) % v2.Length] - v2 [i];
			Vector2 vb = v2 [i] - v2 [i - 1];
			res [i] = Vector2.Dot (va, vb) / (va.magnitude * vb.magnitude);
		}
		return res;
	}

	private float[] sin_vector2(Vector2[] v2){
		float[] res = new float[v2.Length];
		for (int i = 1; i < v2.Length; i++) {
			Vector2 va = v2 [(i + 1) % v2.Length] - v2 [i];
			Vector2 vb = v2 [i] - v2 [i - 1];
			res [i] = Vector2.SignedAngle (va, vb);
		}
		return res;
	}
	public Vector2[] v3to2xz(Vector3 [] v3){
		Vector2[] v2 = new Vector2[obj_mkr.n];
		for (int i = 0; i < obj_mkr.n; i++) {
			v2 [i] = new Vector2 (v3 [i].x, v3 [i].z);
		}
		return v2;
	}
	/*
		for (int i = 0; i < next_d.Length; i++) {
			if (cos[i] >= 0.0f) {
				if (angle [i] < 25f) {
					turn_arr [i] = new int[]{ 0, 0, 0, 0, 0, 0, 0 };
				} else if (25f <= angle [i] && angle [i] < 65f) {
					turn_arr [i] = new int[]{ 1, 0, 0, 0, 0, 0, 0 };
				} else if (65f <= angle [i] && angle [i] < 110f) {
					turn_arr [i] = new int[]{ 0, 1, 0, 0, 0, 0, 0 };
				} else if (110f <= angle [i] && angle [i] < 155f) {
					turn_arr [i] = new int[]{ 0, 0, 1, 0, 0, 0, 0 };
				} else {
					turn_arr [i] = new int[]{ 0, 0, 0, 0, 0, 0, 1 };
				}
			} else {
				if (angle [i] < 25f) {
					turn_arr [i] = new int[]{ 0, 0, 0, 0, 0, 0, 0 };
				} else if (25f <= angle [i] && angle [i] < 65f) {
					turn_arr [i] = new int[]{ 0, 0, 0, 1, 0, 0, 0 };
				} else if (65f <= angle [i] && angle [i] < 110f) {
					turn_arr [i] = new int[]{ 0, 0, 0, 0, 1, 0, 0 };
				} else if (110f <= angle [i] && angle [i] < 155f) {
					turn_arr [i] = new int[]{ 0, 0, 0, 0, 0, 1, 0 };
				} else {
					turn_arr [i] = new int[]{ 0, 0, 0, 0, 0, 0, 1 };
				}
			}
		}

		for (int i = 0; i < next_d.Length; i++) {
			if (-25f <= sin [i] && sin [i] < 25f) {
				turn_arr [i] = new int[]{ 0, 0, 0, 0, 0, 0, 0, 1 };
				} else if (25f <= sin [i] && sin [i] < 65f) {
				turn_arr [i] = new int[]{ 1, 0, 0, 0, 0, 0, 0, 0 };
				} else if (65f <= sin [i] && sin [i] < 110f) {
				turn_arr [i] = new int[]{ 0, 1, 0, 0, 0, 0, 0, 0 };
				} else if (110f <= sin [i] && sin [i] < 155f) {
				turn_arr [i] = new int[]{ 0, 0, 1, 0, 0, 0, 0, 0 };
				} else if (-65f <= sin [i] && sin [i] < -25f) {
				turn_arr [i] = new int[]{ 0, 0, 0, 1, 0, 0, 0, 0 };
				} else if (-110f <= sin [i] && sin [i] < -65) {
				turn_arr [i] = new int[]{ 0, 0, 0, 0, 1, 0, 0, 0 };
				} else if (-155 <= sin [i] && sin [i] < -110) {
				turn_arr [i] = new int[]{ 0, 0, 0, 0, 0, 1, 0, 0};
				} else {
				turn_arr [i] = new int[]{ 0, 0, 0, 0, 0, 0, 1, 0 };
				}
			} 
		*/

