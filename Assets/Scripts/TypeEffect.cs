using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypeEffect : MonoBehaviour
{
    public int CharPerSeconds;
    public GameObject EndCursor;
    public bool isAnim;

    string targetMsg;
    Text MsgText;
    AudioSource audioSource;
    int index;
    float interval;

    private void Awake()
    {
        MsgText = GetComponent<Text>();
        audioSource = GetComponent<AudioSource>();
    }
    public void SetMsg(string msg)
    {
        if(isAnim)
        {
            MsgText.text = targetMsg;
            CancelInvoke();
            EffectEnd();

        }
        else
        {
            targetMsg = msg;
            EffectStart();
        }
        
    }

    // Update is called once per frame
    void EffectStart()
    {
        MsgText.text = "";
        index = 0;
        //EndCursor 숨김
        EndCursor.SetActive(false);

        interval = 1.0f / CharPerSeconds;
        Debug.Log(interval);

        isAnim = true;
        //시간차 반복 호출
        Invoke("Effecting", interval);
    }

    void Effecting()
    {
        if(MsgText.text == targetMsg)
        {
            EffectEnd();
            return;
        }

        MsgText.text += targetMsg[index];
        //Sound 
        if (targetMsg[index] != ' ' || targetMsg[index] != '.')
            audioSource.Play();

        index++;

        Invoke("Effecting", interval);
    }

    void EffectEnd()
    {
        isAnim = false;
        //EndCursor 활성화
        EndCursor.SetActive(true);
    }
}
