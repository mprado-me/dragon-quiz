using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ScenarioController : MonoBehaviour2 {

    private static readonly float mergeFactor = 0.998f;

    private Transform[] moveables, moveablesClone;
    private float[] distances;
    private float z0;

    void Start() {
        InitMoveables();
        InitZ0();
        InitDistances();
        CreateClones();
    }

    void InitMoveables() {
        List<Transform> moveables = new List<Transform>();
        moveables.Clear();

        foreach(Transform t in GetComponentsInChildren<Transform>())
            if(t.ContainTag("Moveable"))
                moveables.Add(t);
        this.moveables = moveables.ToArray();
    }

    void InitZ0() {
        z0 = 0;

        foreach(Transform t in GetComponentsInChildren<Transform>())
            if((t.ContainTag("Z0Ref")) && t.position.z < z0)
                z0 = t.position.z;
    }

    void InitDistances() {
        distances = new float[moveables.Length];
        for(int i = 0; i < moveables.Length; i++) {
            distances[i] = moveables[i].GetComponent<SpriteRenderer>().bounds.size.x * mergeFactor;
        }
    }

    void CreateClones() {
        moveablesClone = new Transform[moveables.Length];
        GameObject clones = gameObject.AddChild("Clones");
        for(int i = 0; i < moveables.Length; i++) {
            moveablesClone[i] = (Transform) Instantiate(moveables[i]);
            moveablesClone[i].SetParent(clones.transform);
            moveablesClone[i].localPosition = moveables[i].localPosition + new Vector3(distances[i], 0f, 0f);
        }
    }

    void Update() {
        Move(Time.deltaTime * ScenariosManager.Instance.Vel);
    }

    public void Move(float dx) {
        for(int i = 0; i < moveables.Length; i++) {
            Translate(moveables[i], dx, distances[i]);
            Translate(moveablesClone[i], dx, distances[i]);
        }
    }

    void Translate(Transform t, float dx, float distance) {
        t.Translate(Vector3.right * dx * t.position.z / z0);
        if(t.localPosition.x < -distance)
            t.Translate(Vector3.right * 2 * distance);
    }
}
