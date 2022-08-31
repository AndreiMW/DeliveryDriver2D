/**
 * Created Date: 8/29/2022
 * Author: Andrei-Florin Ciobanu
 * 
 * Copyright (c) 2022 Andrei-Florin Ciobanu. All rights reserved. 
 */

using UnityEngine;
using UnityEngine.UI;

using DG.Tweening;

using Managers;

namespace UI {
	public class LevelEndUI : MonoBehaviour {
		[SerializeField]
		private Image _titleImage;

		[SerializeField]
		private Button _button;

		private Sequence _sequence;
		
		#region Lifecycle

		private void Awake() {
			this._button.onClick.AddListener(this.HandleButtonAction);
			this.gameObject.SetActive(false);
			
			this._sequence = DOTween.Sequence();
			Vector3 endValue = new Vector3(1.3f, 1.3f, 1.3f);

			this._sequence.Append(this._titleImage.transform.DOScale(endValue, 0.3f));
			this._sequence.Append(this._titleImage.transform.DOScale(Vector3.one, 0.5f));
			
			this._sequence.Append(this._button.transform.DOScale(endValue, 0.3f));
			this._sequence.Append(this._button.transform.DOScale(Vector3.one, 0.5f));
			
			this._sequence.SetAutoKill(false);
			this._sequence.Pause();
		}

		#endregion
		
		#region Public

		/// <summary>
		/// Show the UI.
		/// </summary>
		public void Show() {
			this.gameObject.SetActive(true);
			
			this._titleImage.transform.localScale = Vector3.zero;
			this._button.transform.localScale = Vector3.zero;

			this._sequence.SetDelay(0.2f);
			this._sequence.Restart();
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