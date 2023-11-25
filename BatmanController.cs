using UnityEngine;

public class BatmanController : MonoBehaviour
{
    private Animator animator;
    private bool isAttacking = false;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        HandleInput();
    }

    void HandleInput()
    {
        if (Input.GetButtonDown("Attack") && !isAttacking)
        {
            StartAttack();
        }
    }

    void StartAttack()
    {
        isAttacking = true;
        int randomAttack = Random.Range(1, 4); // Assuming you have three attack animations

        // Trigger the corresponding attack animation
        animator.SetTrigger("Attack" + randomAttack.ToString());
    }

    // Called from animation event when an attack animation finishes
    public void EndAttack()
    {
        isAttacking = false;
    }
}
