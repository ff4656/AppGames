using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPlayerController : MonoBehaviour
{
    private CPlayerCharacter _character;
    public CPlayerCharacter Character { get { return _character; } }

    private void Start()
    {
        SetController(GetComponent<CPlayerCharacter>());
    }

    public void SetController(CPlayerCharacter character)
    {
        _character = character;
        _character.Init(this);
    }

    private void Move()
    {
        if (Input.GetKey(KeyCode.A))
        {
            _character.transform.Translate(Vector3.left * (_character.Speed * Time.fixedDeltaTime));
            _character.setLeft(true);
            _character.SetMove(true);
        }

        else if (Input.GetKey(KeyCode.D))
        {
            _character.transform.Translate(Vector3.right * (_character.Speed * Time.fixedDeltaTime));
            _character.setLeft(false);
            _character.SetMove(true);
        }

        else
        {
            _character.SetMove(false);
        }
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _character.RigidBody.AddForce(Vector2.up * _character.Jump, ForceMode2D.Impulse);
            _character.SetJump(true);
        }
    }

    private void FixedUpdate()
    {
        Move();
        Jump();
    }
}
