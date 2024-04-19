using UnityEngine;

public class Creature : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float detectionRadius = 10f;
    public float attackRadius = 2f;
    public LayerMask playerLayer;
    public GameObject bait;
    public GameObject firstCage;
    public GameObject secondCage;

    private Rigidbody2D rb;
    private Transform player;
    private bool isAggressive = false;
    private bool isCaptured = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if (!isCaptured)
        {
            if (IsNearBait())
            {
                // Move towards the bait if it's nearby
                MoveTowards(bait.transform.position);
            }
            else if (IsPlayerInRange() && !isAggressive)
            {
                // Become aggressive towards the player if they are in range
                isAggressive = true;
            }

            if (isAggressive && !IsPlayerInRange())
            {
                // Stop being aggressive if the player is no longer in range
                isAggressive = false;
            }

            if (isAggressive)
            {
                // Move towards the player if aggressive
                MoveTowards(player.position);

                // Attack the player if in range
                if (Vector2.Distance(transform.position, player.position) <= attackRadius)
                {
                    AttackPlayer();
                }
            }
        }
    }

    private bool IsNearBait()
    {
        return Vector2.Distance(transform.position, bait.transform.position) <= detectionRadius;
    }

    private bool IsPlayerInRange()
    {
        return Vector2.Distance(transform.position, player.position) <= detectionRadius;
    }

    private void MoveTowards(Vector2 targetPosition)
    {
        Vector2 moveDirection = (targetPosition - (Vector2)transform.position).normalized;
        rb.velocity = moveDirection * moveSpeed;
    }

    private void AttackPlayer()
    {
        // Implement attack behavior (e.g., reduce player's health)
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == firstCage && !isCaptured)
        {
            // Break out of the first cage
            BreakOutOfCage();
        }
        else if (other.gameObject == secondCage && !isCaptured)
        {
            // Capture the creature in the second cage
            CaptureCreature();
        }
    }

    private void BreakOutOfCage()
    {
        // Implement break out behavior (e.g., destroy the cage)
        Destroy(firstCage);
    }

    private void CaptureCreature()
    {
        // Implement capture behavior (e.g., disable movement, change state)
        isCaptured = true;
    }

    public void TrappedByCage()
    {
        // Implement behavior when trapped by a cage
    }
}
