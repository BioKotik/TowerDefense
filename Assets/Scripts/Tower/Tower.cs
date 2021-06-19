using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public Enemy enemy;
    [SerializeField] private float attackSpeed;
    [SerializeField] private float attackRange;
    [SerializeField] private Projectile projectilePrefab;
    [SerializeField] private World world;
    private bool canShoot = true;
    private float reloadTime;

    private void Init()
    {
        canShoot = true;
        reloadTime = 1 / attackSpeed;
    }

    private void Awake()
    {
        Init();
    }

    public void Attack(Enemy target)
    {
        Instantiate(projectilePrefab, transform.position, Quaternion.identity).Attack(target);
    }

    private Enemy GetNewTarget()
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

    private void Update()
    {
        if (enemy != null && IsInRange(enemy.transform))
        {
            if (canShoot)
            {
                Attack(enemy);
                StartCoroutine(Reload(reloadTime));
            }
        }
        else
        {
            print("NewTarget");
            enemy = GetNewTarget();
        }        
    }

    public bool IsInRange(Transform target)
    {
        return Vector3.Distance(target.position, transform.position) <= attackRange;
    }

    private IEnumerator Reload(float delay)
    {
        canShoot = false;
        yield return new WaitForSeconds(delay);
        canShoot = true;
    }

    public void Upgrade(TowerUpgrades upgrade)
    {
        attackSpeed += upgrade.attackSpeedBonus;
        attackRange += upgrade.attackRangeBonus;
        projectilePrefab = upgrade.projectileBonus ? upgrade.projectileBonus : projectilePrefab;
    }

	private void OnDrawGizmos()
	{
        Gizmos.DrawWireSphere(transform.position, attackRange);
	}
}
