using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager instance = null;
    private GameObject Canvas;
    private GameObject Canvas_back;
    private Dictionary<int, GameObject> CanvasWindows;
    private Dictionary<int, GameObject> CanvasBack;
    public static UIManager Instance
    {
        get
        {
            if (!instance)
            {
                GameObject.Find("UIManager").GetComponent<UIManager>().Awake();
            }
            return instance;
        }
    }
    private void Awake()
    {
        if (instance == null)
        {
            Debug.Log("make UIManager");
            instance = this;
        }
        /*
        else
        {
            Destroy(this.gameObject);
            Debug.Log("delete UIManager");
        }
        */
        Reference();
        InitValue();
    }
    private void Start()
    {
        OpenCanvas(0);
    }
    /// <summary>
    /// UIManager Mathod
    /// </summary>
    public void OpenCanvas(int PageNumber)
    {
        foreach (KeyValuePair<int, GameObject> Page in CanvasWindows)
        {
            Page.Value.SetActive(false);
        }
        CanvasWindows[PageNumber].SetActive(true);
    }
    public void OpenCanvasBack(int PageNumber)
    {
        foreach (KeyValuePair<int, GameObject> Page in CanvasBack)
        {
            Page.Value.SetActive(false);
        }
        CanvasBack[PageNumber].SetActive(true);
    }
    public void MoveCharacter() => SceneManager.LoadScene("Character");
    public void MoveFirstFloor() => StartCoroutine(LoadScene("FirstFloor"));
    public void MoveLogin() => SceneManager.LoadScene("Login");
    public void MoveUnderGround() => SceneManager.LoadScene("UnderGround");
    public void ResetUIManager() => GameObject.Find("UIManager").GetComponent<UIManager>().Awake();
    IEnumerator LoadScene(string sceneName)
    {       
        AsyncOperation async = SceneManager.LoadSceneAsync(sceneName);
        async.allowSceneActivation = false;
        float time = 0f;
        while (!async.isDone)
        {
            yield return null;
            time += Time.deltaTime;
            Debug.Log(time);
            if (time > 3f) async.allowSceneActivation = true;
        }
    }
    public GameObject CurrentSelectedGameObject()
    {
        return EventSystem.current.currentSelectedGameObject.gameObject;
    }
    private void Reference()
    {
        CanvasWindows = new Dictionary<int, GameObject>();
        CanvasBack = new Dictionary<int, GameObject>();
        Canvas = GameObject.Find("Canvas");
        Canvas_back = GameObject.Find("Canvas_back");
        int temp = Canvas.transform.childCount;
        int temp2 = Canvas_back.transform.childCount;
        for (int value = 0; value < temp; value++)
        {
            CanvasWindows.Add(value, Canvas.transform.GetChild(value).gameObject);
        }
        for (int value = 0; value < temp2; value++)
        {
            CanvasBack.Add(value, Canvas_back.transform.GetChild(value).gameObject);
        }
    }
    private void InitValue()
    {
        foreach (KeyValuePair<int, GameObject> Page in CanvasWindows)
        {
            Page.Value.SetActive(false);
        }
        foreach (KeyValuePair<int, GameObject> Page in CanvasBack)
        {
            Page.Value.SetActive(false);
        }
    }
}
