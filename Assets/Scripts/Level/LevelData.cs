/**
 * Created Date: 08/23/2022
 * Author: Andrei-Florin Ciobanu
 * 
 * Copyright (c) 2022 Andrei-Florin Ciobanu. All rights reserved. 
 */

using UnityEngine;

namespace Level {
	[CreateAssetMenu(fileName = "Level000", menuName = "Level/CreateLevelData")]
	public class LevelData : ScriptableObject {
 
		[field : SerializeField] 
		public Level LevelPrefab {get; private set;} 

		[field : SerializeField] 
		public float Time {get; private set;}
 
	}
}
