using System;
using UnityEngine;

public class Dog : MonoBehaviour
{
    [SerializeField] private GameObject losePanel;
    [SerializeField] private Transform targetPosition;
    private Animator animator;

    [SerializeField] private float maxSpeed = 10f;
    [SerializeField] private float minDistanceToMove = 2f;
    [SerializeField] private float maxDistnaceToMove = 30f;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        // ABSTRACTION
        Move();
    }

    private void Move()
    {
        // Check maximun distance between dog and target
        if ((targetPosition.position - transform.position).magnitude < maxDistnaceToMove)
        {
            // FALSE sit animation
            animator.SetBool("Sit_b", false);

            // When ready to move
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("Locomotion"))
            {
                // Linearly increase and decrese between 0 and MaxSpeed
                float speed = Mathf.PingPong(Time.time, maxSpeed);

                // Check minimun distance with the target
                if ((targetPosition.position - transform.position).magnitude > minDistanceToMove)
                {
                    // FALSE bark animation
                    animator.SetBool("Bark_b", false);

                    transform.LookAt(targetPosition, Vector3.up);
                    transform.Translate(Vector3.forward * speed * Time.deltaTime);

                    // Calculate animation speed
                    float animationSpeed = Mathf.InverseLerp(0f, maxSpeed, speed);
                    animator.SetFloat("Speed_f", animationSpeed);
                }
                else
                {
                    // TRUE bark animation
                    animator.SetBool("Bark_b", true);
                }
            }
        }
        else
        {
            // TRUE sit animation
            animator.SetBool("Sit_b", true);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Attack();
        }
    }

    public virtual void Attack()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Bark"))
        {
            losePanel.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
