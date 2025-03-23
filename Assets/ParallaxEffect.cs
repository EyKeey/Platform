using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    [SerializeField] private float parallaxSpeed;

    private float length;
    private Transform cam;
    private Vector3 position;

    private void Start()
    {
        cam = Camera.main.transform;
        position = transform.position;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    private void FixedUpdate()
    {
        float temp = cam.position.x * (1- parallaxSpeed);
        float distance = cam.position.x * parallaxSpeed;

        transform.position = new Vector3(position.x + distance, position.y, position.z);

        if (temp > position.x + length) { position.x += length; }
        else if(temp < position.x - length) { position.x -= length; }
    }
}
