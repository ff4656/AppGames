using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCharacter : MonoBehaviour {

    [SerializeField]
    protected float _hp;
    public float Hp { get { return _hp; } }

    [SerializeField]
    protected float _speed;
    public float Speed { get { return _speed; } }

    protected Rigidbody2D _rigidbody;
    public Rigidbody2D RigidBody { get { return _rigidbody; } }

    protected virtual void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }
}
