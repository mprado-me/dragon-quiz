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
    private GameController _gameController;
    private float _xToStop;

    void Start() {
        _state = HorizontalPipeState.MOVING_TO_POSITION;
        _eventsManager = new EventsManager<HorizontalPipeEvent>();
        _xToStop = PipesSettings.Instance.HorizontalXStop;

        gameObject.AddComponent<MoveXHorizontalPipeB>();
        gameObject.AddComponent<DestroyPipeB>();
        PlayerEnterInHorizontalPipeDetectorB b = gameObject.AddComponent<PlayerEnterInHorizontalPipeDetectorB>();
        b.SetParams(this);

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
                UpdateMovingToPosition();
                break;
            case HorizontalPipeState.PLAYER_COMING:
                break;
            case HorizontalPipeState.PLAYER_GOING:
                transform.position = new Vector3(transform.position.x + Time.deltaTime * ScenariosManager.Instance.Vel, transform.position.y);
                break;
        }
    }

    private void UpdateMovingToPosition() {
        if(transform.position.x > _xToStop) {
            transform.position = new Vector3(transform.position.x + Time.deltaTime * ScenariosManager.Instance.Vel, transform.position.y);
            if(transform.position.x < _xToStop) {
                transform.position = new Vector3(_xToStop, transform.position.y);
                GameStorer.Instance.GameController.Invoke(GameEvent.HORIZONTAL_PIPE_COMPLETLY_VISIBLE);
            }
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
