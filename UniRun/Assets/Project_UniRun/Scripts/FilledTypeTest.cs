using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // image ������ �������

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
        // coroutine �޼��带 start�� �־����
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

    // coroutine���� ��Ÿ�� �Լ��� ���� ��
    private IEnumerator PassedCoolTime(float cooltimeDelay) 
    {
        float cooltimePercent = 0.003f;

        while(0 < filledTypeImage.fillAmount)
        {
            // �̸�ŭ �ð��� �ɸ���
            yield return new WaitForSeconds(cooltimeDelay);

            // �ð��� ���� ������ ó���Ѵ�
            filledTypeImage.fillAmount -= cooltimePercent;
        }
    }

}
