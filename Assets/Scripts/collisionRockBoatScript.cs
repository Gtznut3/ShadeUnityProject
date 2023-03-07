using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionRockBoatScript : MonoBehaviour, AbleToPause
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

    private bool _isCollide;
    // Start is called before the first frame update
    void Start()
    {
        _isCollide = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!isPause && collision.gameObject.tag == "Rock")
        {
            transform.GetComponent<CapsuleCollider>().isTrigger = true;
            transform.GetComponent<BoxCollider>().isTrigger = true;
            _isCollide = true;
        }
    }

    public bool getCollision()
    {
        return _isCollide;
    }

    public void setIsCollide(bool collide)
    {
        _isCollide = collide;
    }
}
