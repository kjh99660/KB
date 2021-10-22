using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    
    private Rigidbody playerRigidbody;
    private float inputX, inputZ, fallSpeed, speed;
    private Vector3 playerVelocity;
    private Animator animator;
    private bool canOperate;
    private void OnEnable()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        if(canOperate)
        {
            inputX = Input.GetAxis("Horizontal");
            inputZ = Input.GetAxis("Vertical");
            fallSpeed = playerRigidbody.velocity.y;

            playerVelocity = new Vector3(inputX, 0f, inputZ);
            playerVelocity *= speed;
            playerVelocity.y = fallSpeed;
            //playerRigidbody.velocity = playerVelocity;
            transform.Translate(playerVelocity * Time.deltaTime, Space.World);
        }       
    }
    private void FixedUpdate()
    {
        //animation
    }
    public void DepriveOperate() => canOperate = false;
    public void GiveOperate() => canOperate = true;
    private void Init()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        inputX = 0f; inputZ = 0f; fallSpeed = 0f; speed = 5f;
        playerVelocity = new Vector3(inputX, 0f, inputZ);
        canOperate = true;
    }
}
