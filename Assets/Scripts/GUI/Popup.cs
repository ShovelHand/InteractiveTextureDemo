using UnityEngine;
using System.Collections;

public class Popup : MonoBehaviour {
	[SerializeField] GameObject viewer;
	[SerializeField] Camera camera;

	public MouseLook viewerLook;

	// Use this for initialization
	void Start () {
		viewerLook = (MouseLook) viewer.GetComponent (typeof(MouseLook));
		viewerLook.Pause (true);
	}

	/* Update is called once per frame
	void Update () {

	}
	*/
	public void Open(){
		gameObject.SetActive (true);
		viewerLook = (MouseLook) viewer.GetComponent (typeof(MouseLook));
		viewerLook.Pause (true);
	}

	public void Close(){
		gameObject.SetActive (false);
		viewerLook = (MouseLook) viewer.GetComponent (typeof(MouseLook));
		viewerLook.Pause (false);
	}
}
