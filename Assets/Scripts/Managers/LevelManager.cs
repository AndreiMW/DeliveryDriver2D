/**
 * Created Date: 08/23/2022
 * Author: Andrei-Florin Ciobanu
 * 
 * Copyright (c) 2022 Andrei-Florin Ciobanu. All rights reserved. 
 */

using System;

using UnityEngine;

public class LevelManager : UnitySingleton<LevelManager>{
    public event Action OnLevelLoaded;
    
    private LevelData[] _levelDatas;
    public LevelData CurrentLevelData{ get; private set; }
    public Level CurrentLevelInstance{ get; private set; }

    private int _levelIndex = 0;

    #region Lifecycle

    public override void Awake() {
        base.Awake();
        this._levelDatas = Resources.LoadAll<LevelData>("LevelData");
    }

    #endregion
    
    #region Public

    public void LoadLevel() {
        this.CurrentLevelData = this._levelDatas[this._levelIndex];
        if (this.CurrentLevelInstance != null){
            Destroy(this.CurrentLevelInstance.gameObject);
            this.CurrentLevelInstance = null;
        }
        this.CurrentLevelInstance = GameObject.Instantiate(this._levelDatas[this._levelIndex].LevelPrefab, this.transform);
        this.OnLevelLoaded?.Invoke();
        this._levelIndex++;
    }
    
    #endregion
}