using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSelector : MonoBehaviour
{
	public GameObject obj1;
	public GameObject obj2;
	public GameObject obj3;
	public GameObject obj4;
	public GameObject obj5;
	public GameObject obj6;
	public GameObject obj_presser;
	public GameObject obj_distance;
	public GameObject obj_tension;
	private ObjectMaker obj_mkr;

	// Use this for initialization
	void Start ()
	{
		obj_mkr = GameObject.Find ("ObjectMaker").GetComponent<ObjectMaker> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	public void ButtonOne ()
	{
		obj_mkr.obj = obj1;
	}

	public void ButtonTwo ()
	{
		obj_mkr.obj = obj2;
	}

	public void ButtonThree ()
	{
		obj_mkr.obj = obj3;
	}

	public void ButtonFour ()
	{
		obj_mkr.obj = obj4;
	}

	public void ButtonFive ()
	{
		obj_mkr.obj = obj5;
	}

	public void ButtonSix ()
	{
		obj_mkr.obj = obj6;
		//obj_mkr.CreateObj (Vector3.zero);
	}

	public void ButtonPresser ()
	{
		obj_mkr.obj = obj_presser;
	}

	public void ButtonDistance ()
	{
		obj_mkr.obj = obj_distance;
	}

	public void ButtonTension ()
	{
		obj_mkr.obj = obj_tension;
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
/*

#region Mouse Inputs
if (Input.GetMouseButtonDown (0)) {
	tap = true;
	isDraging = true;
	beforePoint = Input.mousePosition;
} else if (Input.GetMouseButtonUp (0)) {
	Reset ();
}
#endregion

#region Mobile Inputs
if (Input.touchCount > 0) {
	if (Input.touches [0].phase == TouchPhase.Began) {
		tap = true;
		isDraging = true;
		beforePoint = Input.touches [0].position;
	} else if (Input.touches [0].phase == TouchPhase.Ended || Input.touches [0].phase == TouchPhase.Canceled) {
		Reset ();
	}
}
#endregion

// calurate the distance
nowPoint = Vector2.zero;
if (isDraging) {
	if (Input.touches.Length > 0)
		nowPoint = Input.touches [0].position - beforePoint;
	else if (Input.GetMouseButton(0))
		nowPoint = (Vector2)Input.mousePosition - beforePoint;
}

// did we cross the deadzone?
if (nowPoint.magnitude > 100) {
	// Which direction?
	float x = nowPoint.x;
	float y = nowPoint.y;
	if (Mathf.Abs (x) > Mathf.Abs (y)) {
		// Left or right
		if (x < 0)
			swipeLeft = true;
		else
			swipeRight = true;
	} else {
		// Up or down
		if (y < 0)
			swipeDown = true;
		else
			swipeUp = true;
	}
	Reset ();
}

if (swipeLeft)
	desiredPosition += Vector3.left;
if (swipeRight)
	desiredPosition += Vector3.right;
if (swipeUp)
	desiredPosition += Vector3.forward;
if (swipeDown)
	desiredPosition += Vector3.back;
//target.position = Vector3.MoveTowards (target.position, desiredPosition, 3f * Time.deltaTime);
*/