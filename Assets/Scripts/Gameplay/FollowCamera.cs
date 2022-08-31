/**
 * Created Date: 11/25/2021
 * Author: Andrei-Florin Ciobanu
 * 
 * Copyright (c) 2021 Andrei-Florin Ciobanu. All rights reserved. 
 */

using UnityEngine;

namespace Gameplay {
	public class FollowCamera : MonoBehaviour {
		[SerializeField]
		private Transform _car;

		private void Update() {
			this.transform.position = this._car.position - Vector3.forward * 10;
		}
	}
}
