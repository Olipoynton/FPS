using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthpickup : MonoBehaviour
{

    public float health;
    public float maxHealth;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("health"))
        {
            Destroy(other.gameObject);
        }

        if (health >= 0)
        {
            health = maxHealth;
        }
    }
}
