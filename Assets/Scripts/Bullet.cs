using System.Collections;
using System.Collections.Generic;
using System.Xml.Xsl;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float fireSpeed, lifeTime, distance;
    [SerializeField] private int damage;
    [SerializeField] private LayerMask enemy;
    [SerializeField] private float timer;

    private void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.right, distance, enemy);
        if (hitInfo.collider != null && hitInfo.collider.tag == gameObject.tag)
        {
            hitInfo.collider.GetComponent<Health>().TakeDamage(damage);
            Destroy(gameObject);
        }
        transform.Translate(Vector2.right * fireSpeed * Time.deltaTime);
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            Destroy(gameObject);
        }
    }
}
