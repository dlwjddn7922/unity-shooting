using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum CharType
{
    Jin,
    Teemo,
    Ari,
    Sona
}
public enum NickName
{
    player1,
    player2,
    player3,
    player4
}
public class PlayerData
{
    public CharType type;
    public NickName nick;
}
public class Chat : MonoBehaviour
{
    [SerializeField] Text chat;
    [SerializeField] Transform parent;
    [SerializeField] TMPro.TMP_InputField myChat;
    TMPro.TMP_InputField inputField;
    string[] charType = { "Jin", "Ari", "Sona", "Teemo" };
    string[] monsterType = { "�ٷ� óġ", "�巹�� óġ", "��ε巹�� óġ", "���� óġ" };
    string[] chatType = { "�ٷ� ����", "ž ����", "�̵� ����", "�� ����", };
    string[] charType1 = { "Player1 (Jin)", "Player2 (Ari)", "Player3 (Sona) ", "Player4 (Teemo) ", };


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Chatting", 1f, 3f);
        InvokeRepeating("MonsterChatting", 3f, 6f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Chatting()
    {
        string chatkey = chatType[Random.Range(0, chatType.Length)];
        string char1key = charType1[Random.Range(0, charType1.Length)];
        chat.text = $"<b><color=blue>{char1key}</color></b> :{chatkey}";
        Instantiate(chat, parent);
    }
    public void MonsterChatting()
    {
        string char1key = charType1[Random.Range(0, charType1.Length)];
        string monkey = monsterType[Random.Range(0, monsterType.Length)];
        chat.text = $"<b><color=blue>{char1key}��</color></b><b><color=red> {monkey}</color></b>";
        Instantiate(chat, parent);
    }
    public void OnChatSend()
    {
        if(myChat.text != "")
        {
            chat.text = $"<b><color=blue>(Ash)lee</color></b>:  {myChat.text}";
            Instantiate(chat, parent);
            chat.text = "";
            myChat.text = "";
        }else
        {
            Debug.Log("ä���� �Է��ϼ���.");
        }
        
        
    }
}
