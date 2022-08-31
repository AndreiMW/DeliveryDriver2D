/**
 * Created Date: 11/27/2021
 * Author: Andrei-Florin Ciobanu
 * 
 * Copyright (c) 2021 Andrei-Florin Ciobanu. All rights reserved. 
 */

using UnityEngine;

using DG.Tweening;

namespace Gameplay {
	public class DirectionArrow : MonoBehaviour {
    	private enum ArrowState {
    		Idle = 0,
    		Following = 1
    	}
    	private Vector3 _target;
    
    	private ArrowState _state;
    	
    	#region Lifecycle
    
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
    		this.transform.DOScale(Vector3.one, 0.4f).SetEase(Ease.OutBack);
    		this._target = target;
    		this.ChangeState(ArrowState.Following);
    	}
    
    	/// <summary>
    	/// Reset the target.
    	/// </summary>
    	public void ResetTarget() {
    		this.transform.DOScale(Vector3.zero, 0.2f);
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
}
