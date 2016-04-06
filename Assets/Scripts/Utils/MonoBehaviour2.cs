using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class MonoBehaviour2 : MonoBehaviour {

    UnityEvent afterStartEvent = new UnityEvent();

    public void OnAfterStart(UnityEngine.Events.UnityAction call) {
        afterStartEvent.AddListener(call);
    }

    protected void ShootAfterStartEvent() {
        afterStartEvent.Invoke();
    }

    protected GameObject AddChild( GameObject prefab ) {
        GameObject child = Instantiate(prefab);
        child.transform.SetParent(transform, false);
        return child;
    }

    protected GameObject AddChild(string name) {
        GameObject child = new GameObject(name);
        child.transform.SetParent(transform, false);
        return child;
    }
}
