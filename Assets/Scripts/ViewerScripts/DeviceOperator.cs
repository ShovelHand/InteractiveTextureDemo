using UnityEngine;
using System.Collections;

public class DeviceOperator : MonoBehaviour {
	public float radius = 1.5f;

	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire1")) {
			Collider[] hitColliders = Physics.OverlapSphere (transform.position, radius);
		//	Debug.Log ("Trigger pressed");
			foreach (Collider hitCollider in hitColliders){
				Vector3 direction = hitCollider.transform.position - transform.position;
				if(Vector3.Dot(transform.forward, direction) > 0.1f) 
					hitCollider.SendMessage ("Operate", SendMessageOptions.DontRequireReceiver);
			}

		}

	}
}
