using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class IngameUI : MonoBehaviour
{
    [Header ("Sound")]
    public GameObject Sound;
    [Header("SocialAction")]
    public GameObject SocialAction;
    [Header("Booth")]
    public GameObject Booth;

    public void SoundOptionOnOff()
    {
        if (Sound.activeSelf) Sound.SetActive(false);
        else Sound.SetActive(true);
    }
    public void PopUpCancel()
    {
        EventSystem.current.currentSelectedGameObject.transform
            .parent.transform.gameObject.SetActive(false);
    }
    public void SocialActionOnOff()
    {
        if (SocialAction.activeSelf) SocialAction.SetActive(false);
        else SocialAction.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
