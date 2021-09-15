using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody rg;

    [SerializeField] private float speed;


    // Start is called before the first frame update
    void Start()
    {
        rg = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        Vector3 verticalMovement = transform.forward * verticalInput * speed;
        Vector3 horizontalMovement = transform.right * horizontalInput * speed;

        rg.AddForce(verticalMovement + horizontalMovement);
    }
}
