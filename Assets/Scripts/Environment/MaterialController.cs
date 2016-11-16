using UnityEngine;
using System.Collections;

public class MaterialController : MonoBehaviour {
	[SerializeField] GameObject display;
	private ColorChangeDevice device;

	// Use this for initialization
	void Start () {
		device = (ColorChangeDevice) display.GetComponent (typeof(ColorChangeDevice));
	}
	
	// Update is called once per frame
	public void SetMaterial(int i){

		device.SetMaterial (i);
	}
}
