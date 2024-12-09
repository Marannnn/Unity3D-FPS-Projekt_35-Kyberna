using UnityEngine;

public class enemyAI : MonoBehaviour
{
    public float detectionRange = 20f;
    public float moveSpeed = 5f;
    public float chaseRange = 15f;
    public LayerMask playerLayer;

    private Transform playerTransform;

    private void Start()
    {
        playerTransform = GameObject.FindWithTag("Player").transform;
    }

    private void Update()
    {
        DetectAndChasePlayer();
    }

    private void DetectAndChasePlayer()
    {

        Collider[] hitColliders = Physics.OverlapSphere(transform.position, detectionRange, playerLayer);

        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("Player"))
            {
                Debug.Log("Player detected!");


                if (Vector3.Distance(transform.position, playerTransform.position) <= chaseRange)
                {
                    ChasePlayer();
                }

                break;
            }
        }
    }

    private void ChasePlayer()
    {
        Vector3 direction = (playerTransform.position - transform.position).normalized;
        transform.position += direction * moveSpeed * Time.deltaTime;


        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 5f);
    }

    private void OnDrawGizmos()
    {

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRange);


        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
}
