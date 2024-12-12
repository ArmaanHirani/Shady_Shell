using UnityEngine;
using UnityEngine.UI;

public class StartTest : MonoBehaviour
{
    [Header("Text References")]
    public Text welcomeText;

    [Header("Trigger Area Settings")]
    public Transform triggerAreaCenter;
    public float triggerAreaRadius = 10f;

    private void Start()
    {
        // Ensure we have a Text component
        if (welcomeText == null)
        {
            Debug.LogError("Welcome Text is not assigned!");
            return;
        }

        // Make sure text is visible
        welcomeText.gameObject.SetActive(true);
    }

    private void Update()
    {
        // Check if player is in trigger area
        if (IsPlayerInTriggerArea())
        {
            // Hide the text when player enters the area
            welcomeText.gameObject.SetActive(false);
        }
    }

    private bool IsPlayerInTriggerArea()
    {
        // Find the player
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player == null || triggerAreaCenter == null)
        {
            Debug.LogWarning("Player or Trigger Area not set correctly!");
            return false;
        }

        // Check if player is within the trigger area radius
        float distance = Vector3.Distance(player.transform.position, triggerAreaCenter.position);
        return distance <= triggerAreaRadius;
    }

    // Optional: Visualize trigger area in scene view
    private void OnDrawGizmosSelected()
    {
        if (triggerAreaCenter != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(triggerAreaCenter.position, triggerAreaRadius);
        }
    }
}