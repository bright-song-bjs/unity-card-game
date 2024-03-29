using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController: MonoBehaviour {
	public static PlayerController Instance { get; private set; }

	private void Awake() {
		if (Instance != null) {
			Destroy(Instance.gameObject);
		}
		Instance = this;
	}

	private void OnDestroy() {
		Instance = null;
	}

	private void Start() {
		
	}
}