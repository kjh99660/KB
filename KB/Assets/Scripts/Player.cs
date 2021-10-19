using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 5f;
    private Rigidbody playerRigidbody;
    private float inputX, inputZ, fallSpeed;
    private Vector3 playerVelocity;
    private void OnEnable()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        inputX = Input.GetAxis("Horizontal");
        inputZ = Input.GetAxis("Vertical");
        fallSpeed = playerRigidbody.velocity.y;

        playerVelocity = new Vector3(inputX, 0f, inputZ);
        playerVelocity *= speed;
        playerVelocity.y = fallSpeed;
        playerRigidbody.velocity = playerVelocity;
    }
    private void Init()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        inputX = 0f; inputZ = 0f; fallSpeed = 0f;
         playerVelocity = new Vector3(inputX, 0f, inputZ);

    }
}
