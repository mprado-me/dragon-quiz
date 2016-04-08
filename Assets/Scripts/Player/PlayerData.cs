using UnityEngine;
using System.Collections;

public class PlayerData : Data {

    private Collider2D _otherCollider2D;

    public PlayerData( PlayerController playerController ) {
    }

    public Collider2D OtherCollider2D {
        get {
            return _otherCollider2D;
        }

        set {
            _otherCollider2D = value;
        }
    }
}
