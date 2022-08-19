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
		Delivered = 1
	}
	
	private TMP_Text _text;

	private void Awake() {
		this._text = this.GetComponent<TMP_Text>();
	}

	public async void ShowPackageStatus(PackageStatus status) {
		this._text.text = status == PackageStatus.Picked ? "Package picked!" : "Package delivered!";
		this._text.transform.DOScale(Vector3.one, 0.4f).SetEase(Ease.OutBack);
		await Task.Delay(TimeSpan.FromSeconds(1f));
		this._text.transform.DOScale(Vector3.zero, 0.4f);
	}
}