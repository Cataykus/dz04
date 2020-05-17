using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GemTrigger : MonoBehaviour
{
    [SerializeField] private UnityEvent _getGem;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerMovement>(out PlayerMovement player))
        {
            _getGem.Invoke();
            Destroy(gameObject);
        }
    }
}
