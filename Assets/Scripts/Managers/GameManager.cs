using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	//singleton
	public static GameObject Instance {
		get {
			return _instance;
		}
	}
	static GameObject _instance;

	//lifecycle methods
	void Awake() {
		if (_instance) {
			Destroy(gameObject);
		} else {
			_instance = gameObject;
		}

		DontDestroyOnLoad(gameObject);
	}

	void OnEnable() {
		InputLayer.Init();
		//TODO: Save system init
	}

	void OnApplicationQuit() {
		InputLayer.Quit();
		//TODO: Save system quit
	}

	void Update() {
		if (InputLayer.GetButtonDown(InputLayer.Button.PAUSE)) {
			// Debug.Log("Pause Down");
		}

		if (InputLayer.GetButtonDown(InputLayer.Button.PICKUP)) {
			// Debug.Log("Pickup Down");
		}

		if (InputLayer.GetButtonDown(InputLayer.Button.USE)) {
			// Debug.Log("Use Down");
		}
	}
}
