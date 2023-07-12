using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // image 쓰려면 적어야함

public class FilledTypeTest : MonoBehaviour
{
    public Image filledTypeImage;

    private void Awake()
    {
        //filledTypeImage.fillAmount = 1f;  
    }

    // Start is called before the first frame update
    void Start()
    {
        // coroutine 메서드를 start에 넣어야함
        StartCoroutine(PassedCoolTime(1f));
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        //if (0 < filledTypeImage.fillAmount)
        //{
        //    filledTypeImage.fillAmount -= (Time.deltaTime * 0.5f);
        //}
    }

    // coroutine으로 쿨타임 함수로 만든 것
    private IEnumerator PassedCoolTime(float cooltimeDelay) 
    {
        float cooltimePercent = 0.003f;

        while(0 < filledTypeImage.fillAmount)
        {
            // 이만큼 시간이 걸린다
            yield return new WaitForSeconds(cooltimeDelay);

            // 시간이 지난 다음에 처리한다
            filledTypeImage.fillAmount -= cooltimePercent;
        }
    }

}
