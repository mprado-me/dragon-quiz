using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using System;

public enum HorizontalPipeEvent {
    PLAYER_ENTER
}

public enum HorizontalPipeState {
    MOVING_TO_POSITION,
    PLAYER_COMING,
    PLAYER_GOING
}

public class HorizontalPipeController : MonoBehaviour2 {

    private HorizontalPipeState _state;
    private EventsManager<HorizontalPipeEvent> _eventsManager;
    private PlayerEnterInHorizontalPipeDetectorB _b;
    private GameController _gameController;

    void Start() {
        _state = HorizontalPipeState.MOVING_TO_POSITION;
        _eventsManager = new EventsManager<HorizontalPipeEvent>();

        gameObject.AddComponent<MoveXHorizontalPipeB>();
        gameObject.AddComponent<DestroyPipeB>();
        _b = gameObject.AddComponent<PlayerEnterInHorizontalPipeDetectorB>();
        _b.SetParams(this);

        _gameController = GameStorer.Instance.GameController;
        _gameController.On(GameEvent.HORIZONTAL_PIPE_COMPLETLY_VISIBLE, ReachXToStop);
        _gameController.On(GameEvent.EXITING_HORIZONTAL_PIPE_START, PlayerGoing);
    }

    // Is public to be called on test methods
    public void ReachXToStop() {
        _state = HorizontalPipeState.PLAYER_COMING;
    }

    // Is public to be called on test methods
    public void PlayerGoing() {
        _state = HorizontalPipeState.PLAYER_GOING;
        PipesSettings ps = PipesSettings.Instance;
        transform.position = new Vector3(-ps.HorizontalXStop, transform.position.y);
    }

    void Update() {
        switch(_state) {
            case HorizontalPipeState.MOVING_TO_POSITION:
                break;
            case HorizontalPipeState.PLAYER_COMING:
                break;
            case HorizontalPipeState.PLAYER_GOING:
                break;
        }
    }

    public void On(HorizontalPipeEvent horizontalPipeEvent, UnityAction call) {
        _eventsManager.On(horizontalPipeEvent, call);
    }

    public void Remove(HorizontalPipeEvent horizontalPipeEvent, UnityAction call) {
        _eventsManager.Remove(horizontalPipeEvent, call);
    }

    public void Invoke(HorizontalPipeEvent horizontalPipeEvent) {
        _eventsManager.Invoke(horizontalPipeEvent);
    }    

    public void OnDestroy() {
        _gameController.Remove(GameEvent.HORIZONTAL_PIPE_COMPLETLY_VISIBLE, ReachXToStop);
    }
}
