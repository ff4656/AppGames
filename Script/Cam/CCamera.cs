using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCamera : MonoBehaviour
{
    [SerializeField]
    private CPlayerController _target;
    public CPlayerController Target { get { return _target; } }

    private Vector2 movePos;

    private float _camSpeed = 10.0f;

    private void Start()
    {
        _target.InitCam(this);
    }

    private void LateUpdate()
    {
        MoveCam();
    }

    private void MoveCam()
    {
        movePos = Vector2.Lerp(_target.transform.position, transform.position, _camSpeed * Time.deltaTime);
        movePos.y = Mathf.Clamp(movePos.y, 1.91f, 30.0f);
        transform.position = movePos;
    }
}
