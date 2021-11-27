using UnityEngine;

/**
 * Created Date: 11/27/2021
 * Author: Andrei-Florin Ciobanu
 * 
 * Copyright (c) 2021 Andrei-Florin Ciobanu. All rights reserved. 
 */

public class DirectionArrow : MonoBehaviour {
	private enum ArrowState {
		Idle = 0,
		Following = 1
	}
	private Vector3 _target;
	private Animator _animator;

	private ArrowState _state;
	
	#region Lifecycle

	private void Awake() {
		this._animator = this.GetComponent<Animator>();
		
	}

	private void Update() {
		if (this._state == ArrowState.Following) {
			Vector2 direction = (this._target - this.transform.position).normalized;
			float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
			Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
			this.transform.rotation = Quaternion.Slerp(this.transform.rotation, rotation, 10 * Time.deltaTime);	
		}
	}
	
	#endregion
	
	#region Public

	/// <summary>
	/// Set the target to follow.
	/// </summary>
	/// <param name="target"></param>
	public void SetTarget(Vector3 target) {
		this._animator.Play("PackageTextAnimationFadeIn");
		this._target = target;
		this.ChangeState(ArrowState.Following);
	}

	/// <summary>
	/// Reset the target.
	/// </summary>
	public void ResetTarget() {
		this._animator.Play("PackageTextAnimationFadeOut");
		this._target = Vector3.zero;
		this.ChangeState(ArrowState.Idle);
	}
	
	#endregion
	
	#region Private

	private void ChangeState(ArrowState state) {
		this._state = state;
	}
	
	#endregion
}