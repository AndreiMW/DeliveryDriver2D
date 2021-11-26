using UnityEngine;

/**
 * Created Date: 11/26/2021
 * Author: Andrei-Florin Ciobanu
 * 
 * Copyright (c) 2021 Andrei-Florin Ciobanu. All rights reserved. 
 */

public class GameManager : MonoBehaviour {
	[SerializeField]
	private Driver _driver;

	[SerializeField] 
	private PackageStatusTextController _packageStatusTextController;

	private void Awake() {
		
		this._driver.OnPackagePicked += () => {
			this._packageStatusTextController.ShowPackageStatus(PackageStatusTextController.PackageStatus.Picked);	
		};
		this._driver.OnPackageDelivered += () => {
			this._packageStatusTextController.ShowPackageStatus(PackageStatusTextController.PackageStatus.Delivered);
		};
	}
	
}