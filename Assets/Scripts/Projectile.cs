using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float damage;

    public void Attack(Transform target)
    {
        StartCoroutine(MoveToTarget(target));
    }

    private IEnumerator MoveToTarget(Transform target)
    {
        while(Vector3.Distance(transform.position, target.position) > 0.2f)
        {
            transform.Translate((target.position - transform.position).normalized * Time.deltaTime * moveSpeed);
            yield return null;
        }

        Destroy(gameObject);
    }
}
