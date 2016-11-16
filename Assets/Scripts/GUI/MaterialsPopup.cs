using UnityEngine;
using System.Collections;

public class MaterialsPopup : MonoBehaviour {
	[SerializeField] GameObject viewer;
	[SerializeField] Camera camera;

	public MouseLook viewerLook;

	// Use this for initialization
	void Start () {
		Close ();
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
