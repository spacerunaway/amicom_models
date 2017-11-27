using System;
using System.Collections.Generic;

namespace UnityEngine.XR.iOS
{
	public class ObjectMakerTest : MonoBehaviour
	{
		public GameObject obj, action_obj;
		public Vector3[] goal_anchors;
		public GameObject[] crated_obj;
		public int goal_num = 0, obj_num = 0;
		public bool can_create_new_obj = true, next_stage = false, wait_click_screen = false;

		void Start(){
			goal_anchors = new Vector3[100];
			crated_obj = new GameObject[100];
			//CreateObj(Vector3.zero);
		}

		bool HitTestWithResultType (ARPoint point, ARHitTestResultType resultTypes)
		{
			List<ARHitTestResult> hitResults = UnityARSessionNativeInterface.GetARSessionNativeInterface ().HitTest (point, resultTypes);
			if (hitResults.Count > 0) {
				foreach (var hitResult in hitResults) {
					Debug.Log ("Got hit!");
					Vector3 p = UnityARMatrixOps.GetPosition (hitResult.worldTransform);
					if (can_create_new_obj) {
						CreateObj (new Vector3 (p.x,p.y - 0.5f, p.z));
					} else {
						//MoveObj (new Vector3 (m_HitTransform.position.x, m_HitTransform.position.y - 0.5f, m_HitTransform.position.z));
					}
					return true;
				}
			}
			return false;
		}

		// Update is called once per frame
		void Update () {
			if (Input.touchCount > 0) {
				var touch = Input.GetTouch (0);
				if (touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Moved) {
					var screenPosition = Camera.main.ScreenToViewportPoint (touch.position);
					ARPoint point = new ARPoint {
						x = screenPosition.x,
						y = screenPosition.y
					};

					// prioritize reults types
					ARHitTestResultType[] resultTypes = {
						ARHitTestResultType.ARHitTestResultTypeExistingPlaneUsingExtent, 
						// if you want to use infinite planes use this:
						//ARHitTestResultType.ARHitTestResultTypeExistingPlane,
						ARHitTestResultType.ARHitTestResultTypeHorizontalPlane, 
						ARHitTestResultType.ARHitTestResultTypeFeaturePoint
					}; 

					foreach (ARHitTestResultType resultType in resultTypes) {
						if (HitTestWithResultType (point, resultType)) {
							return;
						}
					}
				}
			}
		}
		public void CreateObj (Vector3 atPosition)
		{
			if (can_create_new_obj) {
				GameObject setObject = Instantiate (obj, atPosition, Quaternion.identity);
				setObject.transform.Rotate (obj.transform.eulerAngles);
				setObject.transform.localScale = this.transform.localScale;
				goal_anchors [goal_num] = atPosition;
				crated_obj [goal_num] = setObject;
				goal_num++;
				wait_click_screen = false;
				Debug.Log (goal_num);
			}
		}

		void MoveObj (Vector3 atPosition)
		{
			crated_obj [obj_num].transform.position = atPosition;
		}


	}
}

