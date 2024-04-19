using UnityEngine;

public class Bait : MonoBehaviour
{
    // Reference to the creature that will be lured
    public GameObject creature;

    // Flag to track if the bait has been triggered
    private bool triggered = false;

    // Method called when another collider enters the trigger collider of the bait
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the collider belongs to the ground
        if (other.CompareTag("Ground"))
        {
            // Set the flag to indicate that the bait has been triggered
            triggered = true;
        }
    }

    // Method to lure the creature
    private void LureCreature()
    {
        // Check if the creature reference is set and the bait has been triggered
        if (creature != null && triggered)
        {
            // Instantiate the creature at the position of the bait
            Instantiate(creature, transform.position, Quaternion.identity);

            // Destroy the bait GameObject
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Call the method to lure the creature
        LureCreature();
    }
}
