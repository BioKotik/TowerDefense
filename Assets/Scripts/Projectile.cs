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
        float t = 0;
        Vector3 start = transform.position;
        while (t < 1)
        {
            t += Time.deltaTime * moveSpeed;

            transform.position = Vector3.Lerp(start, target.position, t);
            yield return null;
        }

        Destroy(gameObject);
    }
}
