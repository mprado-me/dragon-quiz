using UnityEngine;
using System.Collections;

public enum GameOverMenuEvent {
    TRY_AGAIN_BUTTON_CLICK,
    MAIN_MENU_BUTTON_CLICK
}

public class GameOverMenuEventsManager : EventsManager<GameOverMenuEvent> {

}
