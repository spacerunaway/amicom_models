using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSelector : MonoBehaviour {
	public GameObject obj1;
	public GameObject obj2;
	public GameObject obj3;
	public GameObject obj4;
	public GameObject obj5;
	public GameObject obj6;
	private ObjectMaker obj_mkr;

	// Use this for initialization
	void Start () {
		obj_mkr = GameObject.Find( "ObjectMaker" ).GetComponent<ObjectMaker>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void ButtonOne(){
		obj_mkr.obj = obj1;
	}
	public void ButtonTwo(){
		obj_mkr.obj = obj2;
	}
	public void ButtonThree(){
		obj_mkr.obj = obj3;
	}
	public void ButtonFour(){
		obj_mkr.obj = obj4;
	}
	public void ButtonFive(){
		obj_mkr.obj = obj5;
	}
	public void ButtonSix(){
		obj_mkr.obj = obj6;
	}
}
