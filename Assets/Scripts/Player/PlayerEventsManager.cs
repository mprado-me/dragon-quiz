using UnityEngine;
using System.Collections;

public enum PlayerEvent {
    ON_TRIGGER_ENTER_2D,
    ON_CHOICE_ANSWER,
    ON_ENTER_HORIZONTAL_PIPE_TURORIAL
}

public class PlayerEventsManager : EventsManager<PlayerEvent> {
	
}
