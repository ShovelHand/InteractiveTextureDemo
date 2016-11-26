using UnityEngine;
using System.Collections;
using System.Xml;

public class GenerateMaze : MonoBehaviour {
	public GameObject wall;

	Color[,]colorOfPixel;
	public Texture2D outlineImage;


	private int[,] worldMap = new int[,] {

		{1,1,1,1,1,1,1,1,1,1},
		{1,2,1,0,0,0,0,0,0,1},
		{1,0,1,0,1,0,1,0,0,1},
		{1,0,1,0,0,0,0,0,0,1},
		{1,0,1,1,1,1,0,0,0,1},
		{1,0,0,0,0,0,0,0,0,1},
		{1,0,1,0,1,0,1,1,1,1},
		{1,0,0,1,0,0,0,0,0,1},
		{1,0,1,0,0,0,0,0,0,1},
		{1,1,1,1,1,1,1,1,1,1},
	};
	// Use this for initialization
	void Start () {
		TextAsset textAsset = (TextAsset) Resources.Load ("levelData", typeof(TextAsset));

		XmlDocument doc = new XmlDocument ();
		Debug.Log (textAsset);
		doc.LoadXml (textAsset.text);

		foreach (XmlNode level in doc.SelectNodes("game/level")) {
			//check level number
			if (level.Attributes.GetNamedItem ("number").Value == "1") {
				foreach (XmlNode gameObject in level.SelectNodes(".//object")) {
					string name, location;

					name = gameObject.Attributes.GetNamedItem ("name").Value;
					Debug.Log (name);

					location = gameObject.Attributes.GetNamedItem ("location").Value;
					Vector3 v = ConvertStringToVector (location);
					Debug.Log (v);

					GameObject g = (GameObject)Instantiate (wall, v, Quaternion.identity);
					g.name = name;
				}
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void GenerateFromImage(){
		colorOfPixel = new
			Color[outlineImage.width, outlineImage.height];

		for (int x = 0; x < outlineImage.width; x++) {

			for (int y = 0; y < outlineImage.height; y++) {
				colorOfPixel [x, y] = outlineImage.GetPixel (x, y);//check transparency

				if (colorOfPixel [x, y] != Color.white) {
					GameObject t = 
						(GameObject)(Instantiate (wall, new Vector3 ((outlineImage.width / 2 * 10) - x * 10, 1.5f, (outlineImage.height / 2 * 10) - y * 10), Quaternion.identity));
				}
			}

		}
	}

	public void GenerateFromText(){
		TextAsset t1 = 
			(TextAsset)Resources.Load ("maze", typeof(TextAsset));
		string s = t1.text;
		int i, j;
		s = s.Replace ("\n", "");

		for (i = 0; i < s.Length; i++) {
			if (s [i] == '1') {
				int column, row;
				//identify row and column
				column = 1 % 10;
				row = i / 10;
				GameObject t;

				t = (GameObject)(Instantiate (wall, new Vector3 (50 - column * 10, 1.5f, 50 - row * 10), Quaternion.identity));
			}
		}
	}

	Vector3 ConvertStringToVector(string s){
		string[] newString;
		newString = s.Split (new char[] { ',' });
		float x, y, z;

		x = float.Parse (newString [0]);
		y = float.Parse (newString [1]);
		z = float.Parse (newString [2]);

		return new Vector3 (x, y, z);
	}
}
