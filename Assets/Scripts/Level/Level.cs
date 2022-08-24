/**
 * Created Date: 08/23/2022
 * Author: Andrei-Florin Ciobanu
 * 
 * Copyright (c) 2022 Andrei-Florin Ciobanu. All rights reserved. 
 */

using UnityEngine;

public class Level : MonoBehaviour{
	[SerializeField]
	private Package[] _packages;

	public int PackagesInLevel => this._packages.Length;

}