using System;
using Unity.VisualScripting;
using UnityEngine;

public class Driver : MonoBehaviour {
	[SerializeField] 
	private float _speed;
	
	[SerializeField] 
	private float _steerSpeed;

	[SerializeField] private Transform _arrow;
	
	private Transform _transform;
	private bool _hasPackage;
	private bool _isMoving;

	private Vector3 _leftSteer;

	private SpriteRenderer _renderer;
	private Vector3 _customerPosition;
	
    // Start is called before the first frame update
    void Start() {
	    this._transform = this.GetComponent<Transform>();
	    this._renderer = this.GetComponent<SpriteRenderer>();
    }

    void Update() {
	    if (Input.GetKey(KeyCode.W)) {
		    this._transform.Translate(Vector3.up * (this._speed * Time.deltaTime));
		    this._leftSteer = Vector3.forward;
		    this._isMoving = true;
	    }

	    if (Input.GetKey(KeyCode.S)) {
		    this._transform.Translate(Vector3.down * (this._speed * Time.deltaTime));
		    this._leftSteer = Vector3.back;
		    this._isMoving = true;
	    }

	    if (Input.GetKey(KeyCode.A) && this._isMoving) {
		    this._transform.Rotate(this._leftSteer * (this._steerSpeed * Time.deltaTime));
	    }

	    if (Input.GetKey(KeyCode.D) && this._isMoving) {
		    this._transform.Rotate(-this._leftSteer * (this._steerSpeed * Time.deltaTime));
	    }

	    if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S)) {
		    this._isMoving = false;
	    }

	    if (this._hasPackage && this._customerPosition != Vector3.zero) {
			Vector2 direction = (this._customerPosition - this._arrow.transform.position).normalized;
			float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
			Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
			this._arrow.transform.rotation = Quaternion.Slerp(this._arrow.transform.rotation, rotation, 10 * Time.deltaTime);
	    }

}

    private void OnCollisionEnter2D(Collision2D other) {
	    Debug.Log("OUCH");
    }

    private void OnTriggerEnter2D(Collider2D other) {
	    if (this._hasPackage) {
		    if (other.CompareTag("Customer")) {
			    if (other.GetComponent<SpriteRenderer>().color == this._renderer.color) {
				    Debug.Log("Package delivered");
				    this._renderer.color = Color.white;
				    this._hasPackage = false;
				    Destroy(other.gameObject);   
			    } else {
				    Debug.Log("Wrong Color");
			    }
		    }   
	    } else {
		    if (other.CompareTag("Package")) {
			    Debug.Log("Package picked up!");
			    this._hasPackage = true;
			    this._renderer.color = other.GetComponent<SpriteRenderer>().color;
			    this._customerPosition = other.GetComponent<Package>().CustomerPosition.position;
			    Destroy(other.gameObject);
		    }
	    }
    }
}
