using UnityEngine;
using System.Collections;

public class MaterialImage : MonoBehaviour {
	public const int gridCols = 4;
	public const float offsetX = 2.0f;

	[SerializeField] private MaterialCard originalImage;
	[SerializeField] private Sprite[] images;

	// Use this for initialization
	void Start () {
		Vector3 startPos = originalImage.transform.position;

		for (int i = 0; i < gridCols; ++i) {
			MaterialCard image;
			if (i == 0) {
				image = originalImage;
			} else {
				image = Instantiate (originalImage) as MaterialCard;
			}
			image.setImage (i, images [i]);
			float posX = (offsetX * i) + startPos.x;
			image.transform.position = new Vector3(posX, startPos.y, startPos.z);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
