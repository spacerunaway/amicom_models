using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.iOS;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ARShowRoom : MonoBehaviour {
	private Canvas canvas_setting;
	private Canvas canvas_mode_change;
	private GameObject scroll_view;
	private ObjectMaker obj_mkr;

	void Start(){
		canvas_setting = GameObject.Find ("ModelSetting").GetComponent<Canvas> ();
		canvas_mode_change = GameObject.Find ("ModeChange").GetComponent<Canvas> ();
		scroll_view = GameObject.Find ("ScrollView");
		obj_mkr = GameObject.Find( "ObjectMaker" ).GetComponent<ObjectMaker>();
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
			canvas_setting.enabled = true;
			canvas_mode_change.enabled = false;
			scroll_view.SetActive (false);
		} else {
			obj_mkr.can_create_new_obj = true;
			canvas_setting.enabled = false;
			canvas_mode_change.enabled = true;
			scroll_view.SetActive (true);
		}

	}
	public void show_stage(){
		obj_mkr.can_create_new_obj = false;
		canvas_setting.enabled = false;
		scroll_view.SetActive (false);
		obj_mkr.wait_click_screen = !obj_mkr.wait_click_screen;
	}
	public void go_setting_stage(){
		canvas_mode_change.enabled = false;
		scroll_view.SetActive (false);
		obj_mkr.wait_click_screen = true;
	}
}
