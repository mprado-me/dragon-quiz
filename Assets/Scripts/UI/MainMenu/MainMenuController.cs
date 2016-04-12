using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

// TODO: The user can change char by pressing left/right arrow key and play pressing enter key
public class MainMenuController : MonoBehaviour2 {

    private MainMenuEventsManager _mainMenuEventsManager;
    private Animator _animator;
    private MainMenuButtonsManager _mainMenuButtonsManager;

    private void Awake() {
        _animator = GetComponent<Animator>();
        _mainMenuEventsManager = new MainMenuEventsManager();
        InitMainMenuButtonsManager();
    }

    private void InitMainMenuButtonsManager() {
        _mainMenuButtonsManager = new MainMenuButtonsManager(this);
        _mainMenuButtonsManager.TurnOffAll();
        On(MainMenuEvent.IN_ANIMATION_END, delegate { _mainMenuButtonsManager.TurnOnAll(); });
    }

    public void InitInAnimation() {
        _animator.SetTrigger("initMainMenuAnimation");
    }

    public void InvokePlayButtonClick() {
        _animator.SetTrigger("playButtonClick");
        Invoke(MainMenuEvent.PLAY_BUTTON_CLICK);
    }

    public void On(MainMenuEvent mainMenuEvent, UnityAction call) {
        _mainMenuEventsManager.On(mainMenuEvent, call);
    }

    public void Remove(MainMenuEvent mainMenuEvent, UnityAction call) {
        _mainMenuEventsManager.Remove(mainMenuEvent, call);
    }

    public void Invoke(MainMenuEvent mainMenuEvent) {
        _mainMenuEventsManager.Invoke(mainMenuEvent);
    }
}
