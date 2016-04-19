using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Events;

public class UIFactory : MonoBehaviour2 {

    public GameObject mainMenuPrefab;
    public GameObject gameOverMenuPrefab;
    public GameObject recordPrefab;
    public GameObject tryAgainButtonPrefab;
    public GameObject goMainMenuButtonPrefab;

    private static UIFactory _instance;

    public void CreateMainMenu() {
        GameObject mainMenu = Instantiate(this.mainMenuPrefab);
        mainMenu.transform.parent = transform;
        mainMenu.transform.localScale = Vector3.one;
        mainMenu.transform.localPosition = Vector3.zero;
        UIStorer.Instance.MainMenuController = mainMenu.GetComponent<MainMenuController>();
    }

    public GameOverMenuController CreateGameOverMenu(
        int nCorrectAnswers,
        bool newCorrectAnswersRecord,
        int correctAnswersRecord, 
        int distance,
        bool newDistanceRecord,
        int distanceRecord) {
        GameObject go = Instantiate(gameOverMenuPrefab);
        GameOverMenuController gameOverMenuController = go.GetComponent<GameOverMenuController>();
        UIStorer.Instance.GameOverMenuController = gameOverMenuController;

        Text nCorrectAnswersComponent = null;
        Text nDistanceComponent = null;
        foreach(Text t in go.GetComponentsInChildren<Text>()) {
            if(t.gameObject.ContainTag("NCorrectAnswers")) {
                nCorrectAnswersComponent = t;
            }
            else if(t.gameObject.ContainTag("NDistance")) {
                nDistanceComponent = t;
            }
        }
        nCorrectAnswersComponent.text = ""+nCorrectAnswers;
        nDistanceComponent.text = distance+"m";
        go.transform.SetParent(transform, false);

        string recordDescriptionText;
        if(newCorrectAnswersRecord)
            recordDescriptionText = "NEW!";
        else
            recordDescriptionText = "RECORD";
        GameObject correctAnswersRecordGO = CreateRecord(recordDescriptionText, correctAnswersRecord);
        correctAnswersRecordGO.transform.SetParent(go.transform, false);
        correctAnswersRecordGO.transform.localPosition = new Vector3(
            correctAnswersRecordGO.transform.localPosition.x,
            nCorrectAnswersComponent.transform.localPosition.y);

        if(newDistanceRecord)
            recordDescriptionText = "NEW!";
        else
            recordDescriptionText = "RECORD";
        GameObject distanceRecordGO = CreateRecord(recordDescriptionText, distanceRecord);
        distanceRecordGO.transform.SetParent(go.transform, false);
        distanceRecordGO.transform.localPosition = new Vector3(
            distanceRecordGO.transform.localPosition.x,
            nDistanceComponent.transform.localPosition.y);

        CreateTryAgainButton(go.transform, OnTryAgainButtonClickInGameOverMenu, UISettings.Instance.TryAgainButtonGameOverMenuPos);
        CreateGoMainMenuButton(go.transform, OnGoMainMenuButtonClickInGameOverMenu, UISettings.Instance.GoMainMenuButtonGameOverMenuPos);

        gameOverMenuController.Init();
        return gameOverMenuController;
    }

    // It's public only because of the test
    public GameObject CreateRecord(string recordDescriptionText, int recordValue) {
        GameObject go = Instantiate(recordPrefab);
        Text recordDescriptionTextComponent = null;
        Text recordValueComponent = null;
        foreach( Text t in go.GetComponentsInChildren<Text>()) {
            if(t.gameObject.ContainTag("RecordDescription")) {
                recordDescriptionTextComponent = t;
            } else if(t.gameObject.ContainTag("RecordValue")) {
                recordValueComponent = t;
            }
        }
        recordDescriptionTextComponent.text = recordDescriptionText;
        recordValueComponent.text = recordValue+"m";
        // TEST
        //go.transform.SetParent(transform, false);
        return go;
    }

    private GameObject CreateTryAgainButton(Transform parent, UnityAction call, Vector3 pos) {
        GameObject go = Instantiate(tryAgainButtonPrefab);
        go.GetComponent<Button>().onClick.AddListener(call);
        go.transform.SetParent(parent, false);
        go.transform.position = pos;
        return go;
    }
    private void OnTryAgainButtonClickInGameOverMenu() {
        UIStorer.Instance.GameOverMenuController.Invoke(GameOverMenuEvent.TRY_AGAIN_BUTTON_CLICK);
    }

    private GameObject CreateGoMainMenuButton(Transform parent, UnityAction call, Vector3 pos) {
        GameObject go = Instantiate(goMainMenuButtonPrefab);
        go.GetComponent<Button>().onClick.AddListener(call);
        go.transform.SetParent(parent, false);
        go.transform.position = pos;
        return go;
    }
    private void OnGoMainMenuButtonClickInGameOverMenu() {
        UIStorer.Instance.GameOverMenuController.Invoke(GameOverMenuEvent.MAIN_MENU_BUTTON_CLICK);
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