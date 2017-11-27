using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoSetting : MonoBehaviour
{

	private ObjectMaker obj_mkr;
	private ObjectSelector select;

	void Start ()
	{
		obj_mkr = GameObject.Find ("ObjectMaker").GetComponent<ObjectMaker> ();
		select = GameObject.Find ("ObjectMaker").GetComponent<ObjectSelector> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	public void auto_setting_modelwalk ()
	{
		obj_mkr.CreateObj (new Vector3 (0.0f, -0.2f, 1.0f));
		if (obj_mkr.goal_num > 1) {
			Vector3 temp = obj_mkr.crated_obj [1].transform.position + new Vector3 (0.0f, -0.0f, 0.0f);
			obj_mkr.goal_anchors [1] = temp;
			obj_mkr.CreateObj (temp + new Vector3 (0.0f, 0.0f, 25.0f));
			obj_mkr.CreateObj (temp + new Vector3 (-10.0f, 0.0f, 25.0f));
			obj_mkr.CreateObj (temp + new Vector3 (-10.0f, 0.0f, 0.0f));
			obj_mkr.CreateObj (temp + new Vector3 (0.0f, 0.0f, 0.0f));
		}
	}

	public void auto_setting_modelwalkshima ()
	{
		obj_mkr.CreateObj (new Vector3 (0.0f, -1.5f, 1.0f));
		if (obj_mkr.goal_num > 1) {
			Vector3 temp = obj_mkr.crated_obj [1].transform.position + new Vector3 (0.0f, -0.0f, 0.0f);
			obj_mkr.goal_anchors [1] = temp;
			obj_mkr.CreateObj (temp + new Vector3 (0.0f, 0.0f, 10.0f));
			obj_mkr.CreateObj (temp + new Vector3 (10.0f, 0.0f, 10.0f));
			obj_mkr.CreateObj (temp + new Vector3 (0.0f, 0.0f, 0.0f));
		}
	}

	public void auto_setting_stagewalk ()
	{
		obj_mkr.CreateObj (new Vector3 (0.0f, -0.2f, 4.0f));
		if (obj_mkr.goal_num > 1) {
			Vector3 temp = obj_mkr.crated_obj [1].transform.position + new Vector3 (0.0f, -0.0f, 0.0f);
			obj_mkr.goal_anchors [1] = temp;
			obj_mkr.CreateObj (temp + new Vector3 (0.0f, 0.0f, 28.0f));
			obj_mkr.CreateObj (temp + new Vector3 (0.0f, 0.0f, 0.0f));
		}
	}

	public void auto_setting_stagewalkBySide ()
	{
		obj_mkr.CreateObj (new Vector3 (0.0f, -0.8f, 10.0f));
		if (obj_mkr.goal_num > 1) {
			Vector3 temp = obj_mkr.crated_obj [1].transform.position + new Vector3 (0.0f, -0.0f, 0.0f);
			obj_mkr.goal_anchors [1] = temp;
			obj_mkr.CreateObj (temp + new Vector3 (-18.0f, 0.0f, 0.0f));
			obj_mkr.CreateObj (temp + new Vector3 (0.0f, 0.0f, 0.0f));
		}
	}

	public void auto_setting_modelshow ()
	{

		Vector3 start = new Vector3 (3.0f, -0.8f, 0.0f);
		Vector3 walk_fix = new Vector3 (1.5f, -0.8f, -1.8f);
		Vector3 presser_fix = new Vector3 (0.0f, -0.7f, 0.0f);
		Vector3 distance_fix = new Vector3 (0.5f, -0.0f, -2.0f);
		Vector3 tension_fix = new Vector3 (2.0f, -0.0f, -2.9f);
		Vector3 scale100 = new Vector3 (10.0f, 10.0f, 10.0f);
		Vector3 R30 = new Vector3 (0.0f, 30.0f, 0.0f);
		Vector3 R60 = new Vector3 (0.0f, 60.0f, 0.0f);
		Vector3 R90 = new Vector3 (0.0f, 90.0f, 0.0f);
		Vector3 R120 = new Vector3 (0.0f, 120.0f, 0.0f);
		Vector3 R150 = new Vector3 (0.0f, 150.0f, 0.0f);
		Vector3 R180 = new Vector3 (0.0f, 180.0f, 0.0f);
	
		obj_mkr.obj = select.obj1;
		obj_mkr.obj.transform.localEulerAngles = R180;
		obj_mkr.obj.transform.localScale = scale100;
		obj_mkr.CreateObj (start + new Vector3 (0.0f, 0.0f, 5.0f));

		obj_mkr.obj = select.obj_presser;
		obj_mkr.obj.transform.localEulerAngles = R180;
		obj_mkr.obj.transform.localScale = scale100;
		obj_mkr.CreateObj (start + presser_fix + new Vector3 (1.5f, 0.0f, 5.0f));

		obj_mkr.obj = select.obj_distance;
		obj_mkr.obj.transform.localEulerAngles = -1*R120;
		obj_mkr.obj.transform.localScale = scale100;
		obj_mkr.CreateObj (start + distance_fix +new Vector3 (3.0f, 0.0f, 5.0f));

		obj_mkr.obj = select.obj_tension;
		obj_mkr.obj.transform.localEulerAngles = -1*R150;
		obj_mkr.obj.transform.localScale = scale100;
		obj_mkr.CreateObj (start + tension_fix + new Vector3 (4.5f, 0.0f, 5.0f));

		obj_mkr.obj = select.obj2;
		obj_mkr.obj.transform.localEulerAngles = R180;
		obj_mkr.obj.transform.localScale = scale100;
		obj_mkr.CreateObj (start + new Vector3 (-1.5f, 0.0f, 5.0f));

		obj_mkr.obj = select.obj5;
		obj_mkr.obj.transform.localEulerAngles = R150;
		obj_mkr.obj.transform.localScale = scale100;
		obj_mkr.CreateObj (start + new Vector3 (-0.0f, 0.0f, -0.5f)+new Vector3 (-3.0f, 0.0f, 5.0f));

		obj_mkr.obj = select.obj6;
		obj_mkr.obj.transform.localEulerAngles = R120;
		obj_mkr.obj.transform.localScale = scale100;
		obj_mkr.CreateObj (start + walk_fix + new Vector3 (-6.5f, 0.0f, 5.0f));
	}
}
