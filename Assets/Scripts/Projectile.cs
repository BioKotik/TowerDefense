using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private int damage;
    private Enemy enemy;

    public void Attack(Enemy target)
    {
        enemy = target;
        StartCoroutine(MoveToTarget(target.transform));
    }

    private IEnumerator MoveToTarget(Transform target)
    {
        while(true)
        {
            if (target == null)
            {
                Destroy(gameObject);
                break;
            }

            if (Vector3.Distance(transform.position, target.position) <= Time.deltaTime * moveSpeed)
            {
                transform.position = target.position;
                enemy.OnHit(damage);
                break;
            }

            transform.Translate((target.position - transform.position).normalized * Time.deltaTime * moveSpeed);
            yield return null;
        }

        Destroy(gameObject);
    }
}
