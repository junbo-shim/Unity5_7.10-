using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// ������ �޼����� �ʿ� ��ó����
using UnityEngine.UI;
// ������ �޼����� �ʿ� ��ó����
using UnityEngine.SceneManagement;

public static partial class Function_Global
{
    //������ ��ó���⸦ ǥ��
    [System.Diagnostics.Conditional("DEBUG_MODE")]

    //Log ����
    public static void Log(object message)
    {
#if DEBUG_MODE
        Debug.Log(message);
#endif
    }

    //
    public static void Assert(bool condition) 
    {
#if DEBUG_MODE
        Debug.Assert(condition);
#endif
    }

    //! GameObject �޾Ƽ� Text ã�Ƽ� text �ʵ� �� �����ϴ� �Լ�, text�� ����ϱ� ���ؼ��� using UnityEngine.UI �����
    public static void SetText(this GameObject target, string text) 
    {
        Text textcomponent = target.GetComponent<Text>();
        if(textcomponent == null || textcomponent == default) 
        {
            return;
        }

        textcomponent.text = text;
    } 

    // ! LoadScene �Լ��� ����
    public static void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    // �� ���͸� ���ϴ� �޼���(����3�� ����2�� ���ϰ� ������)
    public static Vector2 AddVector(this Vector3 origin, Vector2 addVector)
    {
        Vector2 result = new Vector2(origin.x, origin.y);
        result += addVector;
        return result;
    }
}
