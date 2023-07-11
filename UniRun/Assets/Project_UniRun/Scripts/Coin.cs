using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    //public AudioClip getCoin;
    private AudioSource coinAudio;
    private SpriteRenderer coinSprite;

    // Start is called before the first frame update
    void Start()
    {
        coinAudio = GetComponent<AudioSource>();
        coinSprite = GetComponent<SpriteRenderer>();
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
            GameManager.instance.AddScore(1);
            //coinAudio.clip = getCoin;
            coinAudio.Play();
            //gameObject.SetActive(false);
            coinSprite.enabled = false;
        }
    }
}
