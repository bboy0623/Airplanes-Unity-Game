﻿using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
    private const int Speed = 40;
    private const int MaxDistance = 50;
    public int Damage { get; set; }

    private float totalDistance;
    private float currentDistance;

    public Bullet()
    {
        Damage = 35;
    }

    void Update()
    {
        currentDistance = Time.deltaTime * Speed;
        totalDistance += currentDistance;
        if (totalDistance < MaxDistance)
        {
            transform.Translate(Vector3.forward * currentDistance);
        }
        else
        {
            Destroy(gameObject);
            Debug.Log("Bullet died...");
        }        
    }

    void OnTriggerEnter(Collider collision)
    {
        ElementStats elementStats = collision.gameObject.GetComponent<ElementStats>();
        Debug.Log("Bullet collided");
        if (elementStats != null)
        {
            HandleCollision(elementStats);
        }
    }

    private void HandleCollision(ElementStats stats)
    {
        Debug.Log("Bullet damaged!");
        stats.InflictDamage(this.Damage);
        Destroy(gameObject); // TODO: add a small explosion for the bullet dissapearance.
    }
}
