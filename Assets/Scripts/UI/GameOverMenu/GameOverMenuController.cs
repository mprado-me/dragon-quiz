using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class GameOverMenuController : MonoBehaviour2 {

    private GameOverMenuEventsManager _eventsManager;

    public void Init() {
        _eventsManager = new GameOverMenuEventsManager();
    }

    void Start () {
    }
	
	void Update () {
	
	}

    public void On(GameOverMenuEvent gameOverMenuEvent, UnityAction call) {
        _eventsManager.On(gameOverMenuEvent, call);
    }

    public void Remove(GameOverMenuEvent gameOverMenuEvent, UnityAction call) {
        _eventsManager.Remove(gameOverMenuEvent, call);
    }

    public void Invoke(GameOverMenuEvent gameOverMenuEvent) {
        _eventsManager.Invoke(gameOverMenuEvent);
    }
}
