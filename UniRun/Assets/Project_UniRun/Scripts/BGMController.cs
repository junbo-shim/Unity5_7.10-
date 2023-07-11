using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMController : MonoBehaviour
{
    public PlayerController playerController;
    private AudioSource bgm;

    // Start is called before the first frame update
    void Start()
    {
        if(playerController != null && playerController.isDead == false) 
        {
            bgm.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerController != null && playerController.isDead == true)
        {
            bgm.Pause();
        }
    }
}
