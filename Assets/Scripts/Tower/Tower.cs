using UnityEngine;

using System.Collections;

public class Tower : MonoBehaviour
{
    private SpriteRenderer renderer;
    [SerializeField] private float attackSpeed;
    [SerializeField] private float attackRange;
    [SerializeField] private Projectile projectilePrefab;
    private Quaternion rotation;

    private World world;
    private Enemy target;

    private bool canShoot = true;
    private float reloadTime;

    public void Construct(World world)
	{
        this.world = world;

        canShoot = true;
        reloadTime = 1f / attackSpeed;
        renderer = GetComponent<SpriteRenderer>();
        rotation = transform.rotation;
	}

    public void Attack(Enemy target)
    {
        var projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        projectile.Attack(target);
    }

    public bool IsInRange(Transform target)
    {
        return Vector3.Distance(target.position, transform.position) <= attackRange;
    }

    private Enemy FindTarget()
    {
        var count = world.EnemyManager.EnemyCount;

        for (int i = 0; i < count; i++)
        {
            Enemy enemy = world.EnemyManager.GetEnemy(i);

            if (IsInRange(enemy.transform))
            {
                return enemy;
            }
        }

        return null;
    }

    public void OnUpdate()
    {
        if (target != null && IsInRange(target.transform))
        {
            transform.rotation = rotation * QuaternionUtility.LookRotation2D((target.transform.position - transform.position).normalized);

            if (canShoot)
            {
                Attack(target);
                StartCoroutine(Reload(reloadTime));
            }
        }
        else
        {
            target = FindTarget();
        }        
    }

    private IEnumerator Reload(float delay)
    {
        canShoot = false;
        yield return new WaitForSeconds(delay);
        canShoot = true;
    }

    public void Upgrade(TowerUpgrade upgrade)
    {
        attackSpeed += upgrade.attackSpeedBonus;
        attackRange += upgrade.attackRangeBonus;

        if (upgrade.towerSprite != null)
        {
            renderer.sprite = upgrade.towerSprite;
        }

        if (upgrade.projectileBonus != null)
		{
            projectilePrefab = upgrade.projectileBonus;
        }
    }

	private void OnDrawGizmos()
	{
        Gizmos.DrawWireSphere(transform.position, attackRange);
	}
}
