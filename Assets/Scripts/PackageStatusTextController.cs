using System;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

/**
 * Created Date: 11/26/2021
 * Author: Andrei-Florin Ciobanu
 * 
 * Copyright (c) 2021 Andrei-Florin Ciobanu. All rights reserved. 
 */
public class PackageStatusTextController : MonoBehaviour {
	public enum PackageStatus {
		Picked = 0,
		Delivered = 1
	}

	private Animator _animator;
	private TMP_Text _text;

	private void Awake() {
		this._animator = this.GetComponent<Animator>();
		this._text = this.GetComponent<TMP_Text>();
	}

	public async void ShowPackageStatus(PackageStatus status) {
		this._text.text = status == PackageStatus.Picked ? "Package picked!" : "Package delivered!";
		this._animator.Play("PackageTextAnimationFadeIn");
		await Task.Delay(TimeSpan.FromSeconds(1f));
		this._animator.Play("PackageTextAnimationFadeOut");
	}
}