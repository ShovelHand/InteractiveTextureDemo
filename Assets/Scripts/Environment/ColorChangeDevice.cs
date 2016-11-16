using UnityEngine;
using System.Collections;

public class ColorChangeDevice : MonoBehaviour {
	[SerializeField] private Material[] materials;
	[SerializeField] private GameObject popup;
	private MaterialsPopup popupController;

	private Material _texture;
	public Renderer rend;
	private int index;

	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer> ();
		index = 0;
		rend.material = materials [0];
		popupController = (MaterialsPopup)popup.GetComponent (typeof(MaterialsPopup));

	}

	// Update is called once per frame
	void Update () {
		
	}

	public void Operate(){
		/*
		if (materials.Length == 0)
			return;
		if (index < materials.Length -1) {
			index += 1;
		} else {
			index = 0;
		}
		rend.material = materials [index];*/
		popupController.Open ();

	}
	public void SetMaterial(int i){
		rend.material = materials [i];
		popupController.Close ();
	}
}
