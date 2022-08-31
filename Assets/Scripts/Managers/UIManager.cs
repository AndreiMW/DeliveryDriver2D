/**
 * Created Date: 8/29/2022
 * Author: Andrei-Florin Ciobanu
 * 
 * Copyright (c) 2022 Andrei-Florin Ciobanu. All rights reserved. 
 */

using UnityEngine;

using UI;

namespace Managers {
	public class UIManager : UnitySingleton<UIManager> {
		[SerializeField]
		private LevelFailedUI _levelFailedUI;

		[SerializeField]
		private LevelSuccessUI _levelSuccessUI;

		#region Public

		/// <summary>
		/// Display level end UI.
		/// </summary>
		/// <param name="success">If true, display level succes, else level failed.</param>
		public void ShowLevelEndUI(bool success) {
			if (success) {
				this._levelSuccessUI.Show();
			} else {
				this._levelFailedUI.Show();
			}
		}
		
		#endregion
	}
}