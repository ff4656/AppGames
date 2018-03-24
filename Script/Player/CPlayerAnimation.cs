using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
    Idle = 0,
    Run,
    Jump
}

public class CPlayerAnimation : MonoBehaviour
{
    private CPlayerCharacter _character;
    public CPlayerCharacter Character { get { return _character; } }

    private SpriteRenderer _spirte;
    public SpriteRenderer Sprite { get { return _spirte; } }

    private Animator _animator;

    private PlayerState _state;
    public PlayerState State { get { return _state; } }
    public void ChangeState(PlayerState state) { if (_state == state) return; _state = state; }

    public void Init(CPlayerCharacter character)
    {
        _character = character;

        Transform anim = _character.transform.GetChild(0);
        _spirte = anim.GetComponent<SpriteRenderer>();
        _animator = anim.GetComponent<Animator>();
    }

    private void Update()
    {
        if (_character.IsLeft)
        {
            if (!_spirte.flipX)
                _spirte.flipX = true;
        }
        else
        {
            if (_spirte.flipX)
                _spirte.flipX = false;
        }

        if (_character.IsJump)
        {
            ChangeState(PlayerState.Jump);
        }

        else if (!_character.IsJump)
        {
            if (_character.IsMove)
                ChangeState(PlayerState.Run);

            else if (!_character.IsMove)
                ChangeState(PlayerState.Idle);
        }

        _animator.SetInteger("State", (int)_state);
    }
}
