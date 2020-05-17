using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpposumDie : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerMovement>(out PlayerMovement player))
        {
            Destroy(transform.parent.gameObject);
        }
    }
}
