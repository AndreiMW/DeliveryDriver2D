/**
* Created Date: 11/26/2021
* Author: Andrei-Florin Ciobanu
* 
* Copyright (c) 2021 Andrei-Florin Ciobanu. All rights reserved. 
*/

using UnityEngine;

namespace Managers {
	public class GameManager : UnitySingleton<GameManager> {
		private bool _isGameStarted;
		public bool IsGameStarted {
			get => this._isGameStarted;
			set {
				this._isGameStarted = value;
				this.SetDriverState(value);
			}
		}

		[SerializeField]
		private Driver _driver;
		public Driver Driver => this._driver;

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
			this._numberOfPackages = LevelManager.Instance.CurrentLevelInstance.PackagesInLevel;
		}

		#endregion
	
		#region Public

		public void GameOver(bool won) {
			this.IsGameStarted = false;
			if (won){
				UserSettings.Instance.SaveSettings();
			}
			UIManager.Instance.ShowLevelEndUI(won);
			this._arrow.ResetTarget();
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
		
		private void SetDriverState(bool canDrive) {
			this._driver.CanDrive = canDrive;
		}
	
		#endregion
	}
}