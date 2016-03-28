using UnityEngine;
using System.Collections;

public class UIFactory : MonoBehaviour2 {

    public GameObject mainMenuPrefab;

    private static UIFactory _instance;

    public void CreateMainMenu() {
        GameObject mainMenu = Instantiate(this.mainMenuPrefab);
        mainMenu.transform.parent = transform;
        mainMenu.transform.localScale = Vector3.one;
        mainMenu.transform.localPosition = Vector3.zero;
        UIStorer.Instance.MainMenuController = mainMenu.GetComponent<MainMenuController>();
    }

    public static UIFactory Instance {
        get {
            if(_instance == null)
                _instance = GameObject.FindObjectOfType<UIFactory>();

            return _instance;
        }

        set {
            _instance = value;
        }
    }
}
