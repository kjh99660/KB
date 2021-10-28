using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChattingManager : MonoBehaviour
{
    [Header ("Player")]
    public GameObject player;
    [Header ("Chatting Text")]
    public InputField inputText;
    public GameObject textPrefabs;
    public GameObject content;
    [Header("Chatting Panel")]
    public ScrollRect scrollRect;
    [SerializeField]private ArrayList messages;
    
    void Start()
    {
        Init();
    }
    private void OnEnable()
    {
        
    }

    public void SendMessage()
    {
        //서버로 메세지를 보내는 내용
    }
    public void GetMessage()
    {
        //서버로부터 메세지를 받는 내용
        //if(messageNum 있음)
    }
    public void PushEnter()//메세지 전송
    {
        if (inputText.text == "") return;

        MakeText(inputText.text);

        inputText.text = "";
        GameObject temp = Instantiate(textPrefabs, content.transform);
        temp.transform.SetAsLastSibling();

        messages.Add(temp);
        scrollRect.verticalNormalizedPosition = 0f;
        inputText.ActivateInputField();

        SendMessage();
    }
    private void MakeText(string text)
    {
        if (messages.Count > 20)
        {
            Destroy(messages[0] as GameObject);
            messages.RemoveAt(0);
            Debug.Log(messages.Count);
        }
        textPrefabs.GetComponent<Text>().text = "PlayerID: " + text;
    }
    public void ChatActivate() => player.GetComponent<Player>().DepriveOperate();
    public void ChatDisabled() => player.GetComponent<Player>().GiveOperate();

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            PushEnter();
        }
    }
    private void Init()
    {
        messages = new ArrayList();
    }
}
