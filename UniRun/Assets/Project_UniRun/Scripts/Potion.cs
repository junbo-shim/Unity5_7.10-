using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour
{
    private AudioSource potionAudio;
    private SpriteRenderer potionSprite;
    private PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        potionAudio = GetComponent<AudioSource>();
        potionSprite = GetComponent<SpriteRenderer>();
        playerController = FindObjectOfType<PlayerController>();
        Function_Global.Assert(true);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            if (playerController.isBig == true)
            {
                return;
            }
            else 
            {
                playerController.isBig = true;
                playerController.transform.localScale = new Vector3(1,1,0) + playerController.transform.localScale;
                potionAudio.Play();
                potionSprite.enabled = false;
            }
        }
    }
}
