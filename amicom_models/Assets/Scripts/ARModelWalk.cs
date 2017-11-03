using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARModelWalk : MonoBehaviour {
	private Canvas canvas_anchor_setting;
	private Canvas canvas_can_go_walk;
	private ObjectMaker obj_mkr;

	void Start(){
		canvas_anchor_setting = GameObject.Find ("AnchorSetting").GetComponent<Canvas> ();
		canvas_can_go_walk = GameObject.Find ("CanGoWalk").GetComponent<Canvas> ();
		obj_mkr = GameObject.Find( "ObjectMaker" ).GetComponent<ObjectMaker>();
		obj_mkr.obj_num = 1;
		obj_mkr.CreateObj(Vector3.zero);
	}

	void Update()
	{
		if (!obj_mkr.wait_click_screen) {
			check_flag ();
		}
	}
	void check_flag(){
		if (obj_mkr.obj_num < obj_mkr.goal_num) {
			obj_mkr.can_create_new_obj = false;
			canvas_anchor_setting.enabled = true;
			canvas_can_go_walk.enabled = false;
		} else {
			obj_mkr.can_create_new_obj = true;
			canvas_anchor_setting.enabled = false;
			canvas_can_go_walk.enabled = true;
		}

	}
	public void go_next_stage(){
		for (int i = 0; i < obj_mkr.goal_num; i++) {
			GameObject.Destroy (obj_mkr.crated_obj [i]);
		}
		obj_mkr.action_obj.transform.position = obj_mkr.goal_anchors [1];
		obj_mkr.wait_click_screen = true;
		obj_mkr.next_stage = true;
		obj_mkr.can_create_new_obj = false;
		canvas_anchor_setting.enabled = false;
		canvas_can_go_walk.enabled = false;
	}
	public void auto_setting(){
		if (obj_mkr.goal_num > 1) {
			Vector3 temp = obj_mkr.crated_obj [1].transform.position;
			obj_mkr.CreateObj (temp + new Vector3 (1.0f, -3.5f, 25.0f));
			obj_mkr.CreateObj (temp + new Vector3 (-10.0f, -3.5f, 25.0f));
			obj_mkr.CreateObj (temp + new Vector3 (-10.0f, -3.5f, 1.0f));
			obj_mkr.CreateObj (temp + new Vector3 (1.0f, -3.5f, 1.0f));
		}
	}
}

