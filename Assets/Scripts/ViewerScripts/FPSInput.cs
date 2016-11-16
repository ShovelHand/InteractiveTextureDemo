using UnityEngine;
using System.Collections;

// basic WASD-style movement control
// commented out line demonstrates that transform.Translate instead of charController.Move doesn't have collision detection

[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/FPS Input")]
public class FPSInput : MonoBehaviour {
	public float speed = 6.0f;
	public float gravity = -9.8f;

	private float minFall = -1.5f;
	public float jumpSpeed = 15.0f;
	public float terminalVelocity = -20.0f;
	private float _vertSpeed;
	private ControllerColliderHit _contact;

	private CharacterController _charController;
	private Animator _animator;
	public float pushForce = 3.0f;
	
	void Start() {
		_vertSpeed = minFall;
		_charController = GetComponent<CharacterController>();
		_animator = GetComponent<Animator> ();
		if (_charController == null)
			Debug.Log ("no character controller attached to player");
		if (_animator == null)
			Debug.Log ("no animator attached to player");
	}
	
	void Update() {
		//transform.Translate(Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0, Input.GetAxis("Vertical") * speed * Time.deltaTime);
		float deltaX = Input.GetAxis("Horizontal") * speed;
		float deltaZ = Input.GetAxis("Vertical") * speed;
		Vector3 movement = new Vector3 (deltaX, 0, deltaZ);

		if (deltaZ != 0) {
			movement = Vector3.ClampMagnitude (movement, speed);
			movement.y = gravity;
		}

		//raycast down to detect steep edges and dropoffs
		bool hitGround = false;
		RaycastHit hit;

		if(_vertSpeed < 0 && Physics.Raycast(transform.position, Vector3.down, out hit)){
			float check = (_charController.height + _charController.radius) / 1.9f;
			hitGround = hit.distance <= check;
		}

		if (hitGround) {
			if (Input.GetButtonDown ("Jump"))
				_vertSpeed = jumpSpeed;
			else{
				_vertSpeed = minFall;
			//_animator.SetBool("Jumping", false);
			}
		} else {
			_vertSpeed += gravity * 5 * Time.deltaTime;
			if (_vertSpeed < terminalVelocity)
				_vertSpeed = terminalVelocity;
			/*
			 if(_contact != null)
			 	_animator.SetBool("Jumping", false);
			*/
			if (_charController.isGrounded) {
				if (Vector3.Dot (movement, _contact.normal) < 0)
					movement = _contact.normal * speed;
				else
					movement += _contact.normal * speed;
			}
		}
		movement.y = _vertSpeed;

		movement *= Time.deltaTime;
		movement = transform.TransformDirection(movement);
		_charController.Move(movement);
	}

	//store collision to use in Update
	void OnControllerColliderHit(ControllerColliderHit hit){
		_contact = hit;

		Rigidbody body = hit.collider.attachedRigidbody;
		if (body != null && !body.isKinematic)
			body.velocity = hit.moveDirection * pushForce;
	}
}
