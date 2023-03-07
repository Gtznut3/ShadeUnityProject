using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class inputScript : MonoBehaviour
{
    public enum MovementInput
    {
        Forward,
        Backward,
        Left,
        Right,
    }

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public List<MovementInput> GetMovementInput()
    {
        List<MovementInput> keyCodes = new List<MovementInput>();

        if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            keyCodes.Add(MovementInput.Forward);
        }
        if (Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.LeftArrow))
        {
            keyCodes.Add(MovementInput.Left);
        }
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            keyCodes.Add(MovementInput.Backward);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            keyCodes.Add(MovementInput.Right);
        }

        return keyCodes;
    }
}
