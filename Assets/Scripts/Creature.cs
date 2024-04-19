using UnityEngine;

public class Creature : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("WoodenCage"))
        {
            Capture();
        }
    }

        public void Capture()
        {
            Debug.Log("Creature captured by WoodenCage!");
            // Add capture behavior here (e.g., disable movement)
        }
    }