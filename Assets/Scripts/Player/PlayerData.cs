using UnityEngine;
using System.Collections;

public class PlayerData : Data {

    private float _absVel;
    private Transform _transform;
    private Rigidbody2D _rigidBody;
    private Collider2D _otherCollider2D;
    private SpriteRenderer _frontWingSR;
    private SpriteRenderer _backWingSR;

    public PlayerData( PlayerController playerController ) {
        RigidBody = playerController.GetComponent<Rigidbody2D>();
        Transform = playerController.transform;
        foreach( SpriteRenderer sr in playerController.GetComponentsInChildren<SpriteRenderer>()) {
            if(sr.ContainTag("BackWing"))
                BackWingSR = sr;
            else if(sr.ContainTag("FrontWing"))
                FrontWingSR = sr;
        }
    }

    public float AbsVel {
        get {
            return _absVel;
        }

        set {
            _absVel = value;
        }
    }

    public Rigidbody2D RigidBody {
        get {
            return _rigidBody;
        }

        set {
            _rigidBody = value;
        }
    }

    public Transform Transform {
        get {
            return _transform;
        }

        set {
            _transform = value;
        }
    }

    public Collider2D OtherCollider2D {
        get {
            return _otherCollider2D;
        }

        set {
            _otherCollider2D = value;
        }
    }

    public SpriteRenderer FrontWingSR {
        get {
            return _frontWingSR;
        }

        set {
            _frontWingSR = value;
        }
    }

    public SpriteRenderer BackWingSR
    {
        get {
            return _backWingSR;
        }

        set {
            _backWingSR = value;
        }
    }
}
