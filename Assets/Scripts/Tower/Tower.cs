﻿using UnityEngine;

using System.Collections;

public class Tower : MonoBehaviour
{
    private float attackSpeed;
    private float attackRange;
    private ProjectileConfig projectileConfig;

    private ProjectileManager projectileManager;

    private SpriteRenderer spriteRenderer;
    private Quaternion defaultRotation;

    private World world;
    private Enemy target;

    private bool canShoot = true;
    private float reloadTime;

    public void Construct(TowerConfig config, World world)
	{
        this.world = world;
        this.attackRange = config.AttackRange;
        this.attackSpeed = config.AttackSpeed;
        this.projectileConfig = config.ProjectileConfig;
        this.projectileManager = new ProjectileManager(world);

        canShoot = true;
        reloadTime = 1f / attackSpeed;

        spriteRenderer = GetComponent<SpriteRenderer>();
        defaultRotation = transform.rotation;
	}

    public void Attack(Enemy target)
    {
        projectileManager.Spawn(projectileConfig, target, transform.position);
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
            transform.rotation = defaultRotation * QuaternionUtility.LookRotation2D((target.transform.position - transform.position).normalized);

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

    public void Upgrade(Upgrade upgrade)
    {
        attackSpeed += upgrade.attackSpeedBonus;
        attackRange += upgrade.attackRangeBonus;

        if (upgrade.towerSprite != null)
        {
            spriteRenderer.sprite = upgrade.towerSprite;
        }

        if (upgrade.projectileConfig != null)
		{
            projectileConfig = upgrade.projectileConfig;
        }
    }

	private void OnDrawGizmos()
	{
        Gizmos.DrawWireSphere(transform.position, attackRange);
	}
}
