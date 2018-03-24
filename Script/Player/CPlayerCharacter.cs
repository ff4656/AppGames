using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPlayerCharacter : CCharacter
{
    [SerializeField]
    private float _jump;
    public float Jump { get { return _jump; } }

    private CPlayerController _controller;
    public CPlayerController Controller { get { return _controller; } }

    private CPlayerAnimation _animation;
    public CPlayerAnimation Animation { get { return _animation; } }

    private bool _isLeft;
    public bool IsLeft { get { return _isLeft; } }
    public void setLeft(bool value) { if (value == _isLeft) return; _isLeft = value; }

    private bool _isMove;
    public bool IsMove { get { return _isMove; } }
    public void SetMove(bool value) { if (_isMove == value) return; _isMove = value; }

    private bool _isJump;
    public bool IsJump { get { return _isJump; } }
    public void SetJump(bool value) { if (_isJump == value) return; _isJump = value; }

    protected override void Awake()
    {
        base.Awake();

        _isMove = false;
        _isLeft = false;

        _animation = GetComponent<CPlayerAnimation>();
        _animation.Init(this);
    }

    public void Init(CPlayerController controller) { _controller = controller; }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject)
        {
            SetJump(false);
        }
    }
}
