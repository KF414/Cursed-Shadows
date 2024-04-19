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
                // Call the TrappedByCage method on the creature
                creature.TrappedByCage();
            }
        }
    }
}
