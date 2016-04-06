using UnityEngine.Events;
using System.Collections.Generic;
using System;
using UnityEngine;

public class EventsManager<ET> {

    private Dictionary<ET, UnityEvent> _unityEventsByEventType;

    public EventsManager() {
        _unityEventsByEventType = new Dictionary<ET, UnityEvent>();
    }

    public void On(ET eventType, UnityAction call) {
        UnityEvent unityEvent;
        try {
            unityEvent = _unityEventsByEventType[eventType];
        }
        catch(KeyNotFoundException) {
            unityEvent = new UnityEvent();
            _unityEventsByEventType[eventType] = unityEvent;
        }
        unityEvent.AddListener(call);
    }

    public void Remove(ET eventType, UnityAction call) {
        UnityEvent unityEvent;
        try {
            unityEvent = _unityEventsByEventType[eventType];
        }
        catch(KeyNotFoundException) {
            return;
        }
        unityEvent.RemoveListener(call);
    }

    public void Invoke(ET eventType) {
        try {
            _unityEventsByEventType[eventType].Invoke();
        }
        catch(KeyNotFoundException) {

        }
    }
}
