using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private float patrolSpeed = 2.0f;
    [SerializeField] private float chaseSpeed = 4.0f;
    [SerializeField] private float detectionRange = 5.0f;
    [SerializeField] private Transform[] patrolPoints;
    
    private Transform player;
    private Rigidbody2D rb;
    private int currentPatrolIndex = 0;
    private bool isChasingPlayer = false;
    
    enum EnemyState
    {
        Patrolling,
        Chasing,
        Returning
    }
    
    private EnemyState currentState = EnemyState.Patrolling;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player")?.transform;
    }
    
    void Update()
    {
        switch (currentState)
        {
            case EnemyState.Patrolling:
                Patrol();
                CheckForPlayer();
                break;
            case EnemyState.Chasing:
                ChasePlayer();
                CheckPlayerDistance();
                break;
            case EnemyState.Returning:
                ReturnToPatrol();
                break;
        }
    }
    
    private void Patrol()
    {
        if (patrolPoints.Length == 0) return;
        
        Transform target = patrolPoints[currentPatrolIndex];
        MoveTowards(target.position, patrolSpeed);
        
        if (Vector2.Distance(transform.position, target.position) < 0.5f)
        {
            currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Length;
        }
    }
    
    private void CheckForPlayer()
    {
        if (player == null) return;
        
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);
        if (distanceToPlayer <= detectionRange)
        {
            currentState = EnemyState.Chasing;
        }
    }
    
    private void ChasePlayer()
    {
        if (player == null) return;
        
        MoveTowards(player.position, chaseSpeed);
    }
    
    private void CheckPlayerDistance()
    {
        if (player == null) return;
        
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);
        if (distanceToPlayer > detectionRange * 2f)
        {
            currentState = EnemyState.Returning;
        }
    }
    
    private void ReturnToPatrol()
    {
        if (patrolPoints.Length == 0)
        {
            currentState = EnemyState.Patrolling;
            return;
        }
        
        Transform nearestPatrolPoint = patrolPoints[currentPatrolIndex];
        MoveTowards(nearestPatrolPoint.position, patrolSpeed);
        
        if (Vector2.Distance(transform.position, nearestPatrolPoint.position) < 0.5f)
        {
            currentState = EnemyState.Patrolling;
        }
    }
    
    private void MoveTowards(Vector2 target, float speed)
    {
        Vector2 direction = (target - (Vector2)transform.position).normalized;
        rb.velocity = new Vector2(direction.x * speed, rb.velocity.y);
        
        if (direction.x != 0)
        {
            transform.localScale = new Vector3(direction.x > 0 ? 1 : -1, 1, 1);
        }
    }
    
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
        
        if (patrolPoints != null)
        {
            Gizmos.color = Color.blue;
            foreach (Transform point in patrolPoints)
            {
                if (point != null)
                {
                    Gizmos.DrawWireSphere(point.position, 0.5f);
                }
            }
        }
    }
}