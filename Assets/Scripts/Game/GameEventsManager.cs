using UnityEngine;
using System.Collections;

public enum GameEvent {
    ON_EXIT_JUMP_START_TUTORIAL,
    ON_HORIZONTAL_PIPE_COMPLETLY_VISIBLE
}


public class GameEventsManager : EventsManager<GameEvent> {

}
