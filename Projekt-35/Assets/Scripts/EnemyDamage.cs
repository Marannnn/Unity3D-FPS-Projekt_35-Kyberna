using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyDamage : MonoBehaviour
{
    [Header("Damage & Detection Settings")]
    public float attackRange = 3f;
    public float attackCooldown = 1f;
    public int damageAmount = 10;
    public TMP_Text healthDisplay;
    private float lastAttackTime = 0f;
    private Transform playerTransform;
    private int playerHealth = 100;

    private void Start()
    {

        playerTransform = GameObject.FindGameObjectWithTag("Player")?.transform;

        if (playerTransform == null)
        {
            Debug.LogError("Unable to find player object. Ensure the player GameObject has the tag 'Player'.");
        }

        if (healthDisplay == null)
        {
            Debug.LogError("HealthDisplay is not assigned to the script. Assign it via the Inspector.");
        }

        UpdateHealthDisplay();
    }

    private void Update()
    {
        if (playerTransform == null)
            return;


        float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);

        Debug.Log($"Distance to player: {distanceToPlayer}");


        if (distanceToPlayer <= attackRange)
        {
            Debug.Log("Player is in range.");
            if (Time.time - lastAttackTime >= attackCooldown)
            {
                Debug.Log("Cooldown met. Attacking player...");
                DealDamageToPlayer();
                lastAttackTime = Time.time;
            }
            else
            {
                Debug.Log($"Cooldown in effect. Next attack in: {attackCooldown - (Time.time - lastAttackTime)} seconds.");
            }
        }
        else
        {
            Debug.Log("Player is out of range.");
        }
    }

    private void DealDamageToPlayer()
    {
        playerHealth -= damageAmount;
        Debug.Log($"Player takes {damageAmount} damage. Remaining health: {playerHealth}");

        UpdateHealthDisplay();

        if (playerHealth <= 0)
        {
            Debug.Log("Player has died!");
            PlayerDies();
        }
    }

    private void UpdateHealthDisplay()
    {
        if (healthDisplay != null)
        {
            healthDisplay.text = $"Health: {playerHealth}";
        }
    }

    private void PlayerDies()
    {
        Debug.Log("Player death triggered.");

    }

    private void OnDrawGizmos()
    {

        //Gizmos.color = Color.red;
        //Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
