using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            FindObjectOfType<GameOverManager>()?.TriggerGameOver();
            Destroy(collision.gameObject);
        }
    }
}
