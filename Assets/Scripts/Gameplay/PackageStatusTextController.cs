/**
 * Created Date: 11/26/2021
 * Author: Andrei-Florin Ciobanu
 * 
 * Copyright (c) 2021 Andrei-Florin Ciobanu. All rights reserved. 
 */

using System;
using System.Threading.Tasks;

using UnityEngine;

using DG.Tweening;
using TMPro;

public class PackageStatusTextController : MonoBehaviour {
	public enum PackageStatus {
		Picked = 0,
		Delivered = 1,
		WrongCustomer = 3
	}
	
	private TMP_Text _text;

	private void Awake() {
		this._text = this.GetComponent<TMP_Text>();
	}

	public async void ShowPackageStatus(PackageStatus status) {

		switch (status) {
			case PackageStatus.Picked: {
				this._text.text = "Package picked!";
				break;
			}
			
			case PackageStatus.Delivered: {
				this._text.text = "Package delivered!";
				break;
			}
			
			case PackageStatus.WrongCustomer: {
				this._text.text = "Wrong customer\n-10 seconds";
				break;
			}
		}
		
		this._text.transform.DOScale(Vector3.one, 0.4f).SetEase(Ease.OutBack);
		await Task.Delay(TimeSpan.FromSeconds(1f));
		this._text.transform.DOScale(Vector3.zero, 0.4f);
	}
}