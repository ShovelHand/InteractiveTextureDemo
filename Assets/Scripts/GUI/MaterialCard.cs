using UnityEngine;
using System.Collections;

public class MaterialCard : MonoBehaviour {
	//[SerializeField] private Sprite image;
	[SerializeField] private MaterialImage controller;

	private int _id;
	public int id {
		get { return _id; }
	}

	public void setImage(int id, Sprite image){
		_id = id;
		GetComponent<SpriteRenderer> ().sprite = image;
	}
		

	public void OnMouseDown(){
		Debug.Log (_id);
	}
}
