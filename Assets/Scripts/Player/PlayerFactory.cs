using UnityEngine;
using System.Collections;

public class PlayerFactory : MonoBehaviour2 {

    public GameObject playerPrefab;

    private static PlayerFactory _instance;

    public void CreatePlayer() {
        GameObject player = AddChild(playerPrefab);
        PlayerController playerController = player.GetComponent<PlayerController>();
        PlayerStorer.Instance.PlayerController = playerController;
        playerController.Init();
        foreach(Transform t in player.GetComponentsInChildren<Transform>()) {
            if(t.ContainTag("NormalBody")) {
                playerController.Data.NormalBodyGO = t.gameObject;
            }
            else if(t.ContainTag("DeadBody")) {
                playerController.Data.DeadBodyGO = t.gameObject;
                t.gameObject.SetActive(false);
            }
        }
    }

    public static PlayerFactory Instance {
        get {
            if(_instance == null)
                _instance = GameObject.FindObjectOfType<PlayerFactory>();

            return _instance;
        }

        set {
            _instance = value;
        }
    }
}
