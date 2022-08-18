using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour {
    [SerializeField] 
    private float _initialTime;

    [SerializeField] 
    private TMP_Text _timerText;
    
    private bool _isTimerStarted = false;
    
    #region Lifecycle

    private void Start() {
        this._isTimerStarted = true;
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
    
    #region Private

    private void CalculateAndDisplayTime() {
        float minutes = Mathf.FloorToInt(this._initialTime / 60);
        float seconds = Mathf.FloorToInt(this._initialTime % 60);
        
        this._timerText.SetText($"{minutes:0}:{seconds:00}");
    }
    
    #endregion
    
}