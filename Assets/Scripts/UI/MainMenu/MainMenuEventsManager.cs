using UnityEngine.Events;
using System.Collections.Generic;
using System;
using UnityEngine;

public enum MainMenuEvent {
    PLAY_BUTTON_CLICK,
    IN_ANIMATION_END,
    OUT_ANIMATION_END
}

public class MainMenuEventsManager : EventsManager<MainMenuEvent> {

}
