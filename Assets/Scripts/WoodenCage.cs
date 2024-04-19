using UnityEngine;

public class WoodenCage : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Creature"))
        {
            Creature creature = other.GetComponent<Creature>();
            if (creature != null)
            {
                CaptureCreature(creature);
            }
        }
    }

    private void CaptureCreature(Creature creature)
    {
        Debug.Log("Creature captured by WoodenCage!");
        creature.Capture();
        // Add capture behavior here (e.g., disable movement)
    }
}
