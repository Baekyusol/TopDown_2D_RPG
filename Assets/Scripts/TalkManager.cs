using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;
    Dictionary<int, Sprite> portraitData;
    public Sprite[] portraitArr;

    void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        portraitData = new Dictionary<int, Sprite>();

        GenerateData();
    }

    // Update is called once per frame
    void GenerateData()
    {
        talkData.Add(1000, new string[] { "�ȳ�?:0", 
                                          "�� ���� ó�� �Ա���?:1",
                                          "�� �� �ѷ������� ��.:0"});
        talkData.Add(2000, new string[] { "����:0",
                                          "�� ȣ���� ���� �Ƹ�����?:1",
                                          "��� �� ȣ������ ������ ����� ������ �ִٰ� ��.:1"});
        talkData.Add(3000, new string[] { "����� �������ڴ�."});
        talkData.Add(4000, new string[] { "������ ����ߴ� ������ �ִ� å���̴�." });

        talkData.Add(10 + 1000, new string[] { "� ��.:0",
                                          "�� ������ ���� ������ �ִٴµ�:1",
                                          "������ ȣ�� �ʿ� �絵�� �˷��ٰž�.:0"});
        talkData.Add(11 + 1000, new string[] { "������ �� ������?:0",
                                          "�絵�� ������ ȣ�� �ʿ� �־�.:1"});
        talkData.Add(11 + 2000, new string[] { "����:1",
                                          "�� ȣ���� ������ ������ �°ž�?:0",
                                          "�׷� �� �� �ϳ� ���ָ� �����ٵ�...:1",
                                          "���ڿ� �� ���� �� ã���ٷ�?:0"});
        talkData.Add(20 + 1000, new string[] { "�絵�� ����?:0",
                                          "���� �긮�� �ٴϸ� ������!:3",
                                          "���߿� �絵���� �Ѹ��� �ؾ߰ھ�.:3"});
        talkData.Add(20 + 2000, new string[] { "ã���� �� �� ������ ��.:1"});
        talkData.Add(20 + 5000, new string[] { "��ó���� ������ ã�Ҵ�.", });

        talkData.Add(21 + 2000, new string[] { "��, ã���༭ ������:2" });

        portraitData.Add(1000 + 0, portraitArr[0]);
        portraitData.Add(1000 + 1, portraitArr[1]);
        portraitData.Add(1000 + 2, portraitArr[2]);
        portraitData.Add(1000 + 3, portraitArr[3]);
        portraitData.Add(2000 + 0, portraitArr[4]);
        portraitData.Add(2000 + 1, portraitArr[5]);
        portraitData.Add(2000 + 2, portraitArr[6]);
        portraitData.Add(2000 + 3, portraitArr[7]);

    }

    public string GetTalk(int id, int talkIndex)
    {
        if (!talkData.ContainsKey(id))
        {
            if (!talkData.ContainsKey(id - id % 10))
            {
                //�ش� ����Ʈ ���� ���� �� ��簡 ���� ��
                //����Ʈ �� ó�� ��縦 ������ �´�.
                return GetTalk(id - id % 100, talkIndex);
            }
            else
            {
                //����Ʈ �� ó�� ��縶�� ���� ��
                //�⺻ ��� ������ ����
                return GetTalk(id - id % 10, talkIndex);
            }
        }
        if (talkIndex == talkData[id].Length)
            return null;
        else
            return talkData[id][talkIndex];
        
    }

    public Sprite GetPortrait(int id, int portraitIndex)
    {
        return portraitData[id + portraitIndex];
    }
}