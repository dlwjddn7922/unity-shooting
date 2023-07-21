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

    string[] charType = { "Jin", "Ari", "Sona", "Teemo" };
    string[] nickType = { "Player1", "Player2", "Player3", "Player4" };
    string[] chatType = { "바론 ㄱㄱ", "탑 ㄱㄱ", "미드 ㄱㄱ", "봇 ㄱㄱ", };


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Chatting", 1f, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Chatting()
    {
        string charkey = charType[Random.Range(0, charType.Length)];
        string nickkey = nickType[Random.Range(0, nickType.Length)];
        string chatkey = chatType[Random.Range(0, chatType.Length)];
        chat.text = $"<b><color=blue>({charkey}){nickkey}</color></b> :{chatkey}";
        Instantiate(chat, parent);
    }
    public void CreateData()
    {
        string charkey = charType[Random.Range(0, charType.Length)];
        string nickkey = nickType[Random.Range(0,nickType.Length)];
    }
    public void OnChatSend()
    {
        chat.text = $"<b><color=blue>(Ash)lee</color></b>:  {myChat.text}"; 
        Instantiate(chat, parent);
        chat.text = "";
    }
}
