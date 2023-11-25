using System.Collections;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 15f;
    public float switchAnimationInterval = 3f;

    private Animator animator;
    private Transform targetEnemy;

    void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(SwitchAnimationRandomly());
    }

    void Update()
    {
        MoveTowardsNearestEnemy();
        RotateTowardsTarget();
    }

    void MoveTowardsNearestEnemy()
    {
        if (targetEnemy != null)
        {
            Vector3 direction = targetEnemy.position - transform.position;
            direction.y = 0f; // Keep the character upright
            direction.Normalize();

            transform.Translate(direction * moveSpeed * Time.deltaTime, Space.World);
        }
    }

    void RotateTowardsTarget()
    {
        if (targetEnemy != null)
        {
            Vector3 direction = targetEnemy.position - transform.position;
            direction.y = 0f; // Keep the character upright

            Quaternion toRotation = Quaternion.LookRotation(direction, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
    }

    IEnumerator SwitchAnimationRandomly()
    {
        while (true)
        {
            yield return new WaitForSeconds(switchAnimationInterval);

            // Generate a random animation trigger name
            string randomAnimation = "Attack" + Random.Range(1, 4).ToString();

            // Trigger the random animation
            animator.SetTrigger(randomAnimation);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            // Set the collided enemy as the target
            targetEnemy = other.transform;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            // Reset the target when the enemy exits the trigger area
            targetEnemy = null;
        }
    }
}
