using UnityEngine;
using System.Collections;

public enum PlayerEvent {
    GO_CHOICE_ANSWER,
    GO_ENTER_HORIZONTAL_PIPE_TUTORIAL,
    GO_EXITING_ALIVE,
    GO_EXITING_DEAD
}

public class PlayerEventsManager : EventsManager<PlayerEvent> {
	
}
