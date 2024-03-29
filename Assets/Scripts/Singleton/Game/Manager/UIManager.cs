using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager: MonoBehaviour {
	public static UIManager Instance { get; private set; }

	[SerializeField]
	private RectTransform mainCanvasPrefab;

	private Stack<UIBase> uiStack = new Stack<UIBase>();

	private RectTransform mainCanvas;

	private void Awake() {
		if (Instance == null) {
			Instance = this;
			DontDestroyOnLoad(gameObject);
			mainCanvas = Instantiate(mainCanvasPrefab);
			DontDestroyOnLoad(mainCanvas);
		} else {
			Destroy(gameObject);
		}
	}

	public UIBase OpenMenu(UIType uiType, bool hideCurrent = true) {
		var uiPrefab = UILibrary.Instance.GetUIBasePrefab(uiType);
		var uiBase = Instantiate(uiPrefab, mainCanvas, false);
		if (!uiStack.IsEmpty && hideCurrent) {
			uiStack.Peek().Hide();
		}
		uiStack.Push(uiBase);
		uiBase.Show();
		return uiBase;
	}

	public void CloseCurrentMenu() {
		if (uiStack.IsEmpty) {
			return;
		}
		var uiBase = uiStack.Pop();
		Destroy(uiBase.gameObject);
		if (!uiStack.IsEmpty) {
			uiStack.Peek().Show();
		}
	}
}