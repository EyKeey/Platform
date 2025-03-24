using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{


    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.GetComponent<ICollectable>() != null)
        {
            other.gameObject.GetComponent<ICollectable>().Collect();
        }
    }
}
