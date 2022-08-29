/**
 * Created Date: 8/29/2022
 * Author: Andrei-Florin Ciobanu
 * 
 * Copyright (c) 2022 Andrei-Florin Ciobanu. All rights reserved. 
 */

using UnityEngine;
using UnityEngine.UI;

namespace UI {
	public class LevelEndUI : MonoBehaviour {
		[SerializeField]
		private Button _button;
		
		#region Lifecycle

		private void Awake() {
			this._button.onClick.AddListener(this.HandleButtonAction);
			this.gameObject.SetActive(false);
		}

		#endregion
		
		#region Public

		/// <summary>
		/// Show the UI.
		/// </summary>
		public void Show() {
			this.gameObject.SetActive(true);
		}
		
		#endregion
		
		#region Protected

		/// <summary>
		/// Handle the action for the continue/restart button.
		/// </summary>
		protected virtual void HandleButtonAction() {
			LevelManager.Instance.LoadLevel();
			this.gameObject.SetActive(false);
		}
		
		#endregion
	}
}