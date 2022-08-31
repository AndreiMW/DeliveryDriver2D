/**
 * Created Date: 08/18/2022
 * Author: Andrei-Florin Ciobanu
 * 
 * Copyright (c) 2022 Andrei-Florin Ciobanu. All rights reserved. 
 */


using UnityEngine;

using TMPro;

using Managers;

namespace Gameplay {
	public class TimerManager : MonoBehaviour {
        private float _initialTime;
    
        [SerializeField] 
        private TMP_Text _timerText;
        
        private bool _isTimerStarted = false;
        
        #region Lifecycle
    
        private void Awake() {
            LevelManager.Instance.OnLevelLoaded += () => {
                this._initialTime = LevelManager.Instance.CurrentLevelData.Time;
                this._isTimerStarted = true;
            };
        }
    
        private void Update() {
            if (this._isTimerStarted && GameManager.Instance.IsGameStarted) {
                if (this._initialTime > 0) {
                    if (this._isTimerStarted) {
                        this._initialTime -= Time.deltaTime;   
                    }
                    this.CalculateAndDisplayTime();
                }
                else {
                    if (this._isTimerStarted){
                        this._isTimerStarted = false;
                        this._initialTime = 0f;
                        GameManager.Instance.GameOver(false);
                    }
                }
            }
        }
        
        #endregion
        
        #region Public
    
        /// <summary>
        /// Remove time from time left.
        /// </summary>
        /// <param name="timeAmount">The amount to remove.</param>
        public void RemoveTime(float timeAmount) {
    	    this._initialTime -= timeAmount;
        }
        
        #endregion
        
        #region Private
    
        private void CalculateAndDisplayTime() {
            float minutes = Mathf.FloorToInt(this._initialTime / 60);
            float seconds = Mathf.FloorToInt(this._initialTime % 60);
            
            this._timerText.SetText($"{minutes:0}:{seconds:00}");
        }
        
        #endregion
        
    }
}
