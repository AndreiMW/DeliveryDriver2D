using System;
using UnityEngine;

/**
 * Created Date: 11/26/2021
 * Author: Andrei-Florin Ciobanu
 * 
 * Copyright (c) 2021 Andrei-Florin Ciobanu. All rights reserved. 
 */

public class GameManager : UnitySingleton<GameManager>{
public bool IsGameStarted{ get; private set; }
	
	[SerializeField]
	private Driver _driver;

	[SerializeField] 
	private PackageStatusTextController _packageStatusTextController;

	[SerializeField]
	private DirectionArrow _arrow;
	
	private int _numberOfPackages;
	
	#region Lifecycle

	public override void Awake() {
		UserSettings.Instance.LoadSettings();
		this._driver.OnPackagePicked += this.HandleOnPackagePicked;
		this._driver.OnPackageDelivered += this.HandleOnPackageDelivered;
	}

	private void Start() {
		//TODO Trigger level start differently
		LevelManager.Instance.LoadLevel();
		this.IsGameStarted = true;
		this._numberOfPackages = LevelManager.Instance.CurrentLevelInstance.PackagesInLevel;
	}

	#endregion
	
	#region Public

	public void GameOver(bool won) {
		this.IsGameStarted = false;
		if (won){
			UserSettings.Instance.SaveSettings();
			//TODO Show GameWon UI
		}
		else{
			//TODO Show GameLost UI
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