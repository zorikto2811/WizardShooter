using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DestroyBarrier : MonoBehaviour
{
    public void DestroyObstacle()
    {
        Destroy(gameObject);
    }
}
