using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool isGameover = false;
    public TMP_Text scoreText;
    //public Text scoreText_;     레가시 text 일 경우
    public GameObject gameoverUI;

    private int score = 0;

    private void Awake()
    {
        //if (instance == null)
        //{
        //    instance = this;
        //}
        if(instance.IsValid() == false) 
        {
            instance = this;
        }
        else
        {
            Function_Global.LogWarning("씬에 두 개 이상의 게임 매니저가 존재합니다");
            Destroy(gameObject);
        }



        // ! List 안에 무언가를 넣어보고 GameManager의 IsValid List를 사용해 null인지 아닌지 체크해보자
        
        //List<int> intList = null;
        //List<int> intList = new List<int>();
        //intList.Add(0);

        //Debug.LogFormat("intList가 유효한지? : {0}", intList.IsValid());
    }


    // Start is called before the first frame update
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {
        if (isGameover == true && Input.GetMouseButtonDown(0))
        {
            //Function_Global.LoadScene("PlayScene");
            Function_Global.LoadScene(Function_Global.GetActiveSceneName());
        }
    }


    public void AddScore(int newScore)
    {
        if (isGameover == false)
        {
            score += newScore;
            scoreText.text = string.Format("Score : {0}", score);
        }
    }


    public void OnPlayerDead() 
    {
        isGameover = true;
        gameoverUI.SetActive(true);
    }
}
