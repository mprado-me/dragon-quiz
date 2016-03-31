using UnityEngine;
using System.Collections;
using System;

public class MainMenuToJumpStartTutorialPS : PlayerState {

    private bool _endMainMenuOutAnim;
    private float _vel;

    protected override void Enter() {
        MainMenuController mainMenuController = UIStorer.Instance.MainMenuController;
        Controller.Add<BeatWingPB>();
        mainMenuController.On(MainMenuEvent.OUT_ANIMATION_END, delegate { _endMainMenuOutAnim = true; });
        _vel = (PlayerSettings.Instance.initialX-Data.Transform.position.x)/PlayerSettings.Instance.timeToReachInitialX;
    }

    protected override void Exit() {

    }

    protected override State<PlayerController, PlayerSettings, PlayerData> Update() {
        if( Data.Transform.position.x > PlayerSettings.Instance.initialX) {
            Data.Transform.position = new Vector3(Data.Transform.position.x + Time.deltaTime * _vel, Data.Transform.position.y);
            if(Data.Transform.position.x < PlayerSettings.Instance.initialX)
                Data.Transform.position = new Vector3(PlayerSettings.Instance.initialX, Data.Transform.position.y);
        }

        if(Data.Transform.position.x == PlayerSettings.Instance.initialX && _endMainMenuOutAnim)
            return PlayerStatesStorer.Instance.Get<JumpStartTutorialPS>();

        return null;
    }
}
