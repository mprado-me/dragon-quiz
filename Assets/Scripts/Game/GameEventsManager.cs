﻿using UnityEngine;
using System.Collections;

public enum GameEvent {
    EXIT_JUMP_START_TUTORIAL,
    HORIZONTAL_PIPE_COMPLETLY_VISIBLE,
    GO_TO_JUMP_START_TUTORIAL,
    GO_DIRECT_TO_MATCH,
    PLAYER_IN_HORIZONTAL_PIPE,
    EXITING_HORIZONTAL_PIPE_START,
    PLAYER_BACK_TO_DIVERT_OSBTACLE_STATE,
    BACK_TO_MAIN_MENU,
    GO_GAME_OVER
}


public class GameEventsManager : EventsManager<GameEvent> {

}
