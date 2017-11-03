using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.iOS;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ObjectMaker : MonoBehaviour
{
	public GameObject obj;
	public GameObject action_obj;
	public Vector3[] goal_anchors;
	public GameObject[] crated_obj;
	public int goal_num = 0;
	public int obj_num = 0;
	public bool can_create_new_obj = true;
	public bool next_stage = false;
	public bool wait_click_screen = false;

	void Start(){
		goal_anchors = new Vector3[100];
		crated_obj = new GameObject[100];
		//CreateObj(Vector3.zero);
	}

	void Update()
	{
		// タッチ入力確認
		if (Input.touchCount > 0)
		{
			var touch = Input.GetTouch(0);
			if (touch.phase == TouchPhase.Began && !EventSystem.current.IsPointerOverGameObject(0))
			{
				var screenPosition = Camera.main.ScreenToViewportPoint(touch.position);
				ARPoint point = new ARPoint
				{
					x = screenPosition.x,
					y = screenPosition.y
				};
				// スクリーンの座標をWorld座標に変換
				List<ARHitTestResult> hitResults = UnityARSessionNativeInterface.GetARSessionNativeInterface().HitTest(point, ARHitTestResultType.ARHitTestResultTypeExistingPlaneUsingExtent);
				if (hitResults.Count > 0)
				{
					foreach (var hitResult in hitResults)
					{
						Vector3 position = UnityARMatrixOps.GetPosition(hitResult.worldTransform);
						if (can_create_new_obj) {
							CreateObj (new Vector3 (position.x, position.y - 0.5f, position.z));
							break;
						} else {
							MoveObj (new Vector3 (position.x, position.y - 0.5f, position.z));
							break;
						}
					}
				}
			}
		}
	}

	public void CreateObj(Vector3 atPosition)
	{
		if (can_create_new_obj) {
			GameObject setObject = Instantiate (obj, atPosition, Quaternion.identity);
			setObject.transform.Rotate (obj.transform.eulerAngles);
			setObject.transform.localScale= this.transform.localScale;
			goal_anchors [goal_num] = atPosition;
			crated_obj [goal_num] = setObject;
			goal_num++;
			wait_click_screen = false;
			Debug.Log (goal_num);
		}
	}
	void MoveObj(Vector3 atPosition){
		crated_obj [obj_num].transform.position = atPosition;
	}
}