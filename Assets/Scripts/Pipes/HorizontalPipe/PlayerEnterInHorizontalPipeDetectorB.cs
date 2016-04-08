using UnityEngine;
using System.Collections;
using System;

public class PlayerEnterInHorizontalPipeDetectorB : MonoBehaviour2 {

    private Collider2D _coll;
    private bool _playerDetected;
    private HorizontalPipeController _horizontalPipeController;

    public void SetParams(HorizontalPipeController horizontalPipeController) {
        _horizontalPipeController = horizontalPipeController;
    }

    private void Start() {
        _playerDetected = false;

        foreach(Collider2D c in GetComponentsInChildren<Collider2D>())
            if(c.ContainTag("EnterRegion"))
                _coll = c;
    }

    private void Update() {
    }

    public void OnTriggerStay2D(Collider2D player) {
        if( !_playerDetected && player.ContainTag("Player") && _coll.bounds.Contains(player.bounds)) {
            Debug.Log("Player enter in region");
            _playerDetected = true;
            _horizontalPipeController.Invoke(HorizontalPipeEvent.PLAYER_ENTER);
        }
    }
}
