using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class MainMenuButtonsManager {

    List<Button> buttons;

    public MainMenuButtonsManager(MainMenuController mainMenuController) {
        buttons = new List<Button>();
        foreach(Button b in mainMenuController.GetComponentsInChildren<Button>()) {
            buttons.Add(b);
        }
    }

    public void TurnOnAll() {
        foreach(Button b in buttons) {
            b.interactable = true;
        }
    }

    public void TurnOffAll() {
        foreach(Button b in buttons) {
            b.interactable = false;
        }
    }
}
