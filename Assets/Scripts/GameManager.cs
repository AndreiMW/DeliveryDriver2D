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

	[SerializeField]
	private DirectionArrow _arrow;
	
	#region Lifecycle

	private void Awake() {
		this._driver.OnPackagePicked += this.HandleOnPackagePicked;
		this._driver.OnPackageDelivered += this.HandleOnPackageDelivered;
	}
	
	#endregion
	
	#region Private

	private void HandleOnPackagePicked(Vector3 positionToDeliver) {
		this._arrow.SetTarget(positionToDeliver);
		this._packageStatusTextController.ShowPackageStatus(PackageStatusTextController.PackageStatus.Picked);
	}

	private void HandleOnPackageDelivered() {
		this._packageStatusTextController.ShowPackageStatus(PackageStatusTextController.PackageStatus.Delivered);
		this._arrow.ResetTarget();
	}
	
	#endregion
}