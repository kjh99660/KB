using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraManager : MonoBehaviour
{
    public GameObject cameraFirstPos;
    public GameObject cameraThirdPos;

    private GameObject player;
    private float SmoothTime = 0.1f, xmove = 0f, ymove = 0f;
    private Vector3 cameraVelocity = Vector3.zero;
    private Vector3 distancePlayerToCamera;
    private Vector3 distancePlayerToCameraFirst;
    private Transform ThirdPos;
    private Transform FirstPos;
    private Transform PlayerPos;

    private void Awake()
    {
        player = GameObject.Find("Player");//Player
        distancePlayerToCamera = new Vector3(0f, 8f, -5f);
        distancePlayerToCameraFirst = new Vector3(0f, 0f, 1f);       
    }


    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(1))
        {
            xmove += Input.GetAxis("Mouse X");
            ymove -= Input.GetAxis("Mouse Y");
        }
        
        if(Input.GetKeyDown(KeyCode.F1))//시점 변경
        {
            if(cameraFirstPos.activeSelf)
            {
                cameraFirstPos.SetActive(false);
                cameraThirdPos.SetActive(true);
                xmove = 0; ymove = 0;
            }
            else
            {
                cameraFirstPos.SetActive(true);
                cameraThirdPos.SetActive(false);
                xmove = 0; ymove = 0;
            }
        }

        ThirdPos = cameraThirdPos.transform;
        FirstPos = cameraFirstPos.transform;
        PlayerPos = player.transform;
        ThirdPos.position = Vector3.SmoothDamp(ThirdPos.position, PlayerPos.position + distancePlayerToCamera, ref cameraVelocity, SmoothTime);
        ThirdPos.rotation = Quaternion.Euler(35f + ymove, xmove, 0f);
        FirstPos.position = Vector3.SmoothDamp(FirstPos.position, PlayerPos.position + distancePlayerToCameraFirst, ref cameraVelocity, SmoothTime);
        FirstPos.rotation = Quaternion.Euler(-10f + ymove, xmove, 0f);
    }
}
