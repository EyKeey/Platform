using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
    public int damageAmount = 1;

    private Collider2D mainCollider;
    private Collider2D killZoneCollider;

    private void Start()
    {
        Collider2D[] colliders = GetComponents<Collider2D>();
        mainCollider = colliders[0];
        killZoneCollider = colliders[1];
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered enemy trigger");
            if (other.transform.position.y > transform.position.y)
            {
                Debug.Log("Player jumped on enemy");
                Die();
                return;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(damageAmount);
            Die();
        }
    }

    private void Die()
    {
        mainCollider.enabled = false;
        killZoneCollider.enabled = false;
        Destroy(gameObject);
    }
}
