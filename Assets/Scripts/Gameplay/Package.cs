using UnityEngine;

/**
 * Created Date: 11/26/2021
 * Author: Andrei-Florin Ciobanu
 * 
 * Copyright (c) 2021 Andrei-Florin Ciobanu. All rights reserved. 
 */

public class Package : MonoBehaviour {
	[SerializeField]
	private Transform _customerPosition;
	public Transform CustomerPosition => this._customerPosition;
}