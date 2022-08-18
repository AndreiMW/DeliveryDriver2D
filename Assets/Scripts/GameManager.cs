using UnityEngine;

/**
 * Created Date: 11/26/2021
 * Author: Andrei-Florin Ciobanu
 * 
 * Copyright (c) 2021 Andrei-Florin Ciobanu. All rights reserved. 
 */

public class GameManager : MonoBehaviour{
	private static GameManager s_instance; 
	public static GameManager Instance => s_instance ? s_instance : FindObjectOfType<GameManager>();
	
	public bool IsGameStarted{ get; private set; }
	
	[SerializeField]
	private Driver _driver;

	[SerializeField] 
	private PackageStatusTextController _packageStatusTextController;

	[SerializeField]
	private DirectionArrow _arrow;
	
	private int _numberOfPackages;
	
	#region Lifecycle

	private void Awake() {
		this._driver.OnPackagePicked += this.HandleOnPackagePicked;
		this._driver.OnPackageDelivered += this.HandleOnPackageDelivered;

		this._numberOfPackages = FindObjectsOfType<Package>().Length;

		this.IsGameStarted = true;
	}
	
	#endregion
	
	#region Public

	public void GameOver(bool won) {
		this.IsGameStarted = false;
		if (won){
			Debug.Log("Game WON.");
		}
		else{
			Debug.Log("Game over man.");	
		}
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
		this._numberOfPackages--;
		if (this._numberOfPackages == 0){
			this.GameOver(true);
		}
	}
	
	#endregion
}