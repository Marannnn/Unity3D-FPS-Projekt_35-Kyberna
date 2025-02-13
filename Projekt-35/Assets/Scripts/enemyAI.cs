using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float detectionRange = 20f;
    public float moveSpeed = 5f;
    public float chaseRange = 15f;
    public LayerMask playerLayer;

    private Transform playerTransform;
    private Rigidbody rb;

    private void Start()
    {
        playerTransform = GameObject.FindWithTag("Player").transform;
        rb = GetComponent<Rigidbody>(); 

        if (rb == null)
        {
            Debug.LogError("No Rigidbody found on enemy!");
        }
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

        
        direction.y = 0;

        rb.velocity = new Vector3(direction.x * moveSpeed, rb.velocity.y, direction.z * moveSpeed);

        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 5f);
    }
}
