using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnAnimeRessource : MonoBehaviour
{
    //public Animation ResssourceGetOutOffIsland;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayAnimation()
    {
        // Exécuter l'animation
        GetComponent<Animation>().Play();
    }
}
