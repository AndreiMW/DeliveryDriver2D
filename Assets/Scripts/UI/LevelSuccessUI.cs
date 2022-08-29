/**
 * Created Date: 8/29/2022
 * Author: Andrei-Florin Ciobanu
 * 
 * Copyright (c) 2022 Andrei-Florin Ciobanu. All rights reserved. 
 */

namespace UI {
	public class LevelSuccessUI : LevelEndUI {
		
		#region Protected

		protected override void HandleButtonAction() {
			LevelManager.Instance.IncrementLevelIndex();
			base.HandleButtonAction();
		}

		#endregion
	}
}
