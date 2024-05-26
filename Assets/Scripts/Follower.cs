using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour
{
    [SerializeField] private Transform hero;
    [SerializeField] private Canvas canvas;

    private void Start()
    {
        canvas.worldCamera = Camera.main; 
    }
    private void Update()
    {
        transform.position = hero.position;
    }
}
