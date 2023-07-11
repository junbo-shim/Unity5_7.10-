using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public GameObject[] obstacles;
    public GameObject[] coins;
    private bool isStepped = false;


    private void OnEnable()
    {
        isStepped = false;

        for(int i = 0; i < obstacles.Length; i++) 
        {
            if(Random.Range(0,3) == 0) 
            {
                obstacles[i].SetActive(true);
            }
            else 
            {
                obstacles[i].SetActive(false);
            }
        }

        for(int i = 0; i < coins.Length; i++) 
        {
            if(Random.Range(0, 7) == 0) 
            {
                coins[i].SetActive(true);
            }
            else 
            {
                coins[i].SetActive(false);
            }
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Player" && isStepped) 
        {
            isStepped = true;
        }
        GameManager.instance.AddScore(1);
    }


    // Start is called before the first frame update
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {

    }
}
