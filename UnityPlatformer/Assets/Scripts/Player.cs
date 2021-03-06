﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent<OpposumMovement>(out OpposumMovement enemy))
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
