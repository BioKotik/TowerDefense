using UnityEngine;

using System.Collections;

public class Projectile : MonoBehaviour
{
    private float flySpeed;
    private int damage;
    private Enemy target;

    public void Construct(ProjectileConfig config)
	{
        this.flySpeed = config.FlySpeed;
        this.damage = config.Damage;

	}

    public void SetTarget(Enemy target)
    {
        this.target = target;
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

            if (Vector3.Distance(transform.position, target.position) <= Time.deltaTime * flySpeed)
            {
                transform.position = target.position;
                this.target.OnHit(damage);
                break;
            }

            transform.Translate((target.position - transform.position).normalized * Time.deltaTime * flySpeed);
            yield return null;
        }

        Destroy(gameObject);
    }
}
