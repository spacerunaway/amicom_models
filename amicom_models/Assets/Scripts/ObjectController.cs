using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.iOS;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ObjectController : MonoBehaviour
{
	private ObjectMaker obj_mkr;
	public float rotateSpeed = 1.0f;
	//回転速度(角度/秒)

	//private bool tap, swipeLeft, swipeRight, swipeUp, swipeDown;
	private Vector3 desiredPosition;
	private Vector2 beforePoint, nowPoint, difference;
	private float horizontalAngle, varticalAngle;
	private Transform target;

	void Start ()
	{
		obj_mkr = GameObject.Find ("ObjectMaker").GetComponent<ObjectMaker> ();
	}

	void Update ()
	{
		if (obj_mkr.obj_num < obj_mkr.goal_num) {
			target = obj_mkr.crated_obj [obj_mkr.obj_num].transform;
			//tap = swipeLeft = swipeRight = swipeUp = swipeDown = false;

			//2本指でタップした場合は回転
			if (Input.touchCount == 2) {
				//押下時のポイントを取得
				if (Input.touchCount > 0) {
					if (Input.GetTouch (0).phase == TouchPhase.Began) {
						beforePoint = Input.GetTouch (0).position;
					}
				}
				//スワイプでの継続した入力があった場合、その方向へ回転させる
				if (Input.GetTouch (0).phase == TouchPhase.Moved) {
					nowPoint = Input.GetTouch (0).position;
					//水平方向の移動があった場合、水平方向に回転
					if (nowPoint.x - beforePoint.x != 0) {
						horizontalAngle = (nowPoint.x - beforePoint.x)/5f;
						horizontalAngle *= rotateSpeed * Time.deltaTime;

						//水平方向に回転させる(水平方向はワールド軸)
						target.Rotate (0, horizontalAngle, 0, Space.World);
					}
					//現フレームのポイントを格納
					//beforePoint = nowPoint;
				}
			}
		}
	}

	private void Reset ()
	{
		beforePoint = nowPoint = difference = Vector2.zero;
	}

	#region Change object by touch

	public void next_obj ()
	{
		if (obj_mkr.obj_num < obj_mkr.goal_num) {
			obj_mkr.obj_num++;
		}
	}

	public void prev_obj ()
	{
		if (obj_mkr.obj_num > 0) {
			obj_mkr.obj_num--;
		}
	}

	public void LookAt ()
	{
		target.LookAt (Camera.main.transform.position);
		target.eulerAngles = new Vector3 (0, transform.eulerAngles.y, 0);
	}

	public void Bigger ()
	{
		target.localScale += new Vector3 (0.1f, 0.1f, 0.1f);
	}

	public void Smaller ()
	{
		if (target.localScale.x > 0.1f) {
			target.localScale -= new Vector3 (0.1f, 0.1f, 0.1f);
		} 
	}

	public void Trun_left ()
	{
		target.Rotate (new Vector3 (0, -5, 0));
	}

	public void Trun_right ()
	{
		target.Rotate (new Vector3 (0, 5, 0));
	}

	public void Up ()
	{
		Vector3 temp = target.transform.position + new Vector3 (0, 0.1f, 0);
		target.transform.position = temp;
	}

	public void Down ()
	{
		Vector3 temp = target.transform.position + new Vector3 (0, -0.1f, 0);
		target.transform.position = temp;
	}
	public void deleteBody(){
		GameObject body = target.Find ("Body").gameObject;
		body.SetActive(!body.activeSelf);
	}

	#endregion
}
