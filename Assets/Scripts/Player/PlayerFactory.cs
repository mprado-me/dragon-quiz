using UnityEngine;
using System.Collections;

public class PlayerFactory : MonoBehaviour2 {

    public GameObject playerPrefab;

    private static PlayerFactory _instance;

    public void CreatePlayer() {
        GameObject player = AddChild(playerPrefab);
        PlayerStorer.Instance.PlayerController = player.GetComponent<PlayerController>();
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
