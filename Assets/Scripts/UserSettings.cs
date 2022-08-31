/**
 * Created Date: 08/23/2022
 * Author: Andrei-Florin Ciobanu
 * 
 * Copyright (c) 2022 Andrei-Florin Ciobanu. All rights reserved. 
 */

using UnityEngine;

public class UserSettings : UnitySingleton<UserSettings>{
    private const string CURRENT_LEVEL_INDEX = "c9e9a848920877e76685b2e4e76de38d";
    public int CurrentLevelIndex{ get; set; }
    
    #region Save Settings
    
    public void SaveSettings() {
        PlayerPrefs.SetInt(CURRENT_LEVEL_INDEX, this.CurrentLevelIndex);
    }
    
    #endregion
    
    #region Load Settings

    public void LoadSettings() {
        this.CurrentLevelIndex = PlayerPrefs.GetInt(CURRENT_LEVEL_INDEX, 0);
    }
    
    #endregion
}
