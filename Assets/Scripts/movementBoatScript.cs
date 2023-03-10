using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Engine.Utils;
using static inputScript;

public class movementBoatScript : MonoBehaviour, AbleToPause
{
    bool isPause = false;
    public void Continue()
    {
        isPause = false;
    }

    public void Pause()
    {
        isPause = true;
    }

    private movementScript _movementScript;
    private inputScript _inputScript;

    private collisionRockBoatScript _collisionRock;
    private bool _isCollideToRock;

    [SerializeField] private int _movementForwardStat = 0;
    [SerializeField] private int _movementForwardMax = 3;
    [SerializeField] private int _movementSideStat = 0;
    [SerializeField] private float _movementSpeed = 5f;

    private float _lastAcceleration;

    // Start is called before the first frame update
    void Start()
    {
        _movementScript = GetComponent<movementScript>();
        _inputScript = GetComponent<inputScript>();
        _collisionRock = GetComponent<collisionRockBoatScript>();

        _lastAcceleration = Time.time;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!isPause)
        {
            _isCollideToRock = _collisionRock.getCollision();
            if (!_isCollideToRock)
            {
                setMovement();
                movement();
            }
        }
    }

    private void setMovement()
    {
        List<MovementInput> listMovementInput = _inputScript.GetMovementInput();
        _movementSideStat = 0;
        foreach (MovementInput input in listMovementInput)
        {
            switch (input)
            {
                case MovementInput.Forward:
                    if (_lastAcceleration + 0.1f < Time.time)
                    {
                        _movementForwardStat++;
                        _lastAcceleration = Time.time;
                    }
                    break;
                case MovementInput.Backward:
                    if (_lastAcceleration + 0.1f < Time.time)
                    {
                        _movementForwardStat--;
                        _lastAcceleration = Time.time;
                    }
                    break;
                case MovementInput.Left:
                    _movementSideStat--;
                    break;
                case MovementInput.Right:
                    _movementSideStat++;
                    break;
                default: break;
            }
        }

        if (_movementForwardStat < 0) _movementForwardStat = 0;
        else if (_movementForwardStat > _movementForwardMax) _movementForwardStat = _movementForwardMax;
    }

    private void movement()
    {
        _movementScript.MoveForward(_movementSpeed * _movementForwardStat * _movementForwardStat);
        if (_movementForwardStat > 0) _movementScript.MyRotate(0, _movementSideStat, 0);
    }
}
