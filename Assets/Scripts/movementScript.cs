using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class movementScript : MonoBehaviour
{
    [SerializeField] private float speed = 5;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void MoveForward(float multiply = 1f)
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime * multiply);
    }

    public void MoveBackward(float multiply = 1f)
    {
        transform.Translate(Vector3.back * speed * Time.deltaTime * multiply);
    }

    public void MyRotate(float x, float y, float z)
    {
        transform.Rotate(x, y, z);
    }
}
