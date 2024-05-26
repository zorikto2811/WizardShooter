using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTrigger : MonoBehaviour
{
    [SerializeField] private DeathController deathController;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<DeathController>(out var deathController))
        { 
           deathController.Death();
        }
    }
}
