using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;
    public int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damageAmount)
    {
        StartCoroutine(DamageAnimation());

        currentHealth -= damageAmount;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private IEnumerator DamageAnimation()
    {
        Animator animator = gameObject.GetComponent<Animator>();
        animator.SetTrigger("hurt");
        yield return new WaitForSeconds(0.1f);
        animator.ResetTrigger("hurt");
    }

    private void Die()
    {
        Debug.Log("Player died!");
        Destroy(gameObject);
    }
}
