using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

    // Start is called before the first frame update
    void Start()
    {
        _movementScript = GetComponent<movementScript>();
        _inputScript = GetComponent<inputScript>();
        _collisionRock = GetComponent<collisionRockBoatScript>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!isPause)
        {
            _isCollideToRock = _collisionRock.getCollision();
            if (!_isCollideToRock) movement();
        }
    }

    private void movement()
    {
        List<MovementInput> listMovementInput = _inputScript.GetMovementInput();

        foreach (MovementInput input in listMovementInput)
        {
            switch (input)
            {
                case MovementInput.Forward:
                    _movementScript.MoveForward(10);
                    break;
                case MovementInput.Backward:
                    _movementScript.MoveBackward(10);
                    break;
                case MovementInput.Left:
                    _movementScript.MoveForward(5f);
                    _movementScript.MyRotate(0, -1f, 0);
                    break;
                case MovementInput.Right:
                    _movementScript.MoveForward(5f);
                    _movementScript.MyRotate(0, 1f, 0);
                    break;
                default: break;
            }
        }
    }
}
