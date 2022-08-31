using System;

using UnityEngine;

/**
 * Created Date: 11/25/2021
 * Author: Andrei-Florin Ciobanu
 * 
 * Copyright (c) 2021 Andrei-Florin Ciobanu. All rights reserved. 
 */

public class Driver : MonoBehaviour {
	[SerializeField] 
	private float _speed;
	
	[SerializeField] 
	private float _steerSpeed;
	
	public bool CanDrive { get; set; }
	
	private SpriteRenderer _renderer;	
	private Transform _transform;
	
	private bool _hasPackage;
	private bool _isMoving;

	private Vector3 _steeringDirection;
	private Vector3 _originalPosition;
	private Quaternion _originalRotation;

	private Package _currentPicekdPackage;

	public event Action<Vector3> OnPackagePicked;
	public event Action OnPackageDelivered;
	public event Action OnWrongPackageDestination;
	
    #region Lifecycle
    void Start() {
	    this._transform = this.GetComponent<Transform>();
	    this._renderer = this.GetComponent<SpriteRenderer>();
	    
	    this._originalPosition = this._transform.position;
	    this._originalRotation = this._transform.rotation;
    }

    void Update() {
	    if (this.CanDrive) {
		    if (Input.GetKey(KeyCode.W)) {
			    this._transform.Translate(Vector3.up * (this._speed * Time.deltaTime));
			    this._steeringDirection = Vector3.forward;
			    this._isMoving = true;
		    }

		    if (Input.GetKey(KeyCode.S)) {
			    this._transform.Translate(Vector3.down * (this._speed * Time.deltaTime));
			    this._steeringDirection = Vector3.back;
			    this._isMoving = true;
		    }

		    if (Input.GetKey(KeyCode.A) && this._isMoving) {
			    this._transform.Rotate(this._steeringDirection * (this._steerSpeed * Time.deltaTime));
		    }

		    if (Input.GetKey(KeyCode.D) && this._isMoving) {
			    this._transform.Rotate(-this._steeringDirection * (this._steerSpeed * Time.deltaTime));
		    }

		    if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S)) {
			    this._isMoving = false;
		    }   
	    }
    }
    
    #endregion
    
    #region Public

    /// <summary>
    /// Reset position and rotation;
    /// </summary>
    public void Reset() {
	    this._transform.SetPositionAndRotation(this._originalPosition,this._originalRotation);
	    this.SetCarColor(Color.white);
	    this._hasPackage = false;
    }
    
    #endregion
    
    #region Physics

    private void OnCollisionEnter2D(Collision2D other) {
	    Debug.Log("OUCH");
    }

    private void OnTriggerEnter2D(Collider2D other) {
	    if (this._hasPackage) {
		    if (other.CompareTag("Customer")) {
			    if (other.transform.position == this._currentPicekdPackage.CustomerPosition.position) {
				    this.OnPackageDelivered?.Invoke();
				    this.SetCarColor(Color.white);
				    this._hasPackage = false;
				    Destroy(other.gameObject);   
			    } else {
					this.OnWrongPackageDestination?.Invoke();
			    }
		    }   
	    } else {
		    if (other.CompareTag("Package")) {
			    this._currentPicekdPackage = other.GetComponent<Package>();
			    this.OnPackagePicked?.Invoke(this._currentPicekdPackage.CustomerPosition.position);
			    this._hasPackage = true;
			    this.SetCarColor(other.GetComponent<SpriteRenderer>().color);
			    Destroy(other.gameObject);
		    }
	    }
    }
    
    #endregion
    
    #region Private

    private void SetCarColor(Color color) {
	    this._renderer.color = color;
    }
    
    #endregion
    
}
