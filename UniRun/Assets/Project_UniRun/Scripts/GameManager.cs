using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool isGameover = false;
    public TMP_Text scoreText;
    //public Text scoreText_;     ������ text �� ���
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
            Function_Global.LogWarning("���� �� �� �̻��� ���� �Ŵ����� �����մϴ�");
            Destroy(gameObject);
        }



        // ! List �ȿ� ���𰡸� �־�� GameManager�� IsValid List�� ����� null���� �ƴ��� üũ�غ���
        
        //List<int> intList = null;
        //List<int> intList = new List<int>();
        //intList.Add(0);

        //Debug.LogFormat("intList�� ��ȿ����? : {0}", intList.IsValid());
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
