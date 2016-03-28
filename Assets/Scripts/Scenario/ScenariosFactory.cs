using UnityEngine;
using System.Collections;

public class ScenariosFactory : MonoBehaviour2 {

    public GameObject sky;
    public GameObject ground;
    public GameObject cave;

    private static ScenariosFactory _instance;

    public GameObject CreateSky() {
        GameObject sky = Instantiate(this.sky);
        InitScenario(sky);
        return sky;
    }

    public GameObject CreateGround() {
        GameObject ground = Instantiate(this.ground);
        InitScenario(ground);
        return ground;
    }

    public GameObject CreateCave() {
        GameObject cave = Instantiate(this.cave);
        InitScenario(cave);
        return cave;
    }

    private void InitScenario(GameObject scenarioGO) {
        scenarioGO.SetParent(transform);
        scenarioGO.SetActive(false);
    }

    public static ScenariosFactory Instance {
        get {
            if(_instance == null)
                _instance = GameObject.FindObjectOfType<ScenariosFactory>();

            return _instance;
        }

        set {
            _instance = value;
        }
    }
}
