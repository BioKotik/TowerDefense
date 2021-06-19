using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [HideInInspector] public Enemy enemy;
    [SerializeField] private float attackSpeed;
    [SerializeField] private float attackRange;
    [SerializeField] private Projectile projectilePrefab;
    [SerializeField] private World world;
    private bool isCanShoot = true;
    private float reloadTime;

    private void Init()
    {
        isCanShoot = true;
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
        var count = world.EnemyManager.EnemiesCount;

        for (int i = 0; i < count; i++)
        {
            Enemy enemy = world.EnemyManager.GetEnemyByIndex(i);

            if (CheckDistance(enemy.transform))
            {
                return enemy;
            }

        }

        return null;
    }

    private void Update()
    {
        try
        {
            if (enemy == null)
            {
                GetNewTarget();
            }

            if (CheckDistance(enemy.transform))
            {
                if (isCanShoot)
                {
                    Attack(enemy);
                    StartCoroutine(Reload(reloadTime));
                }
            }
        }
        catch (NullReferenceException e)
        {
            
        }
    }

    public bool CheckDistance(Transform target)
    {
        return Vector3.Distance(target.position, transform.position) <= attackRange;
    }

    private IEnumerator Reload(float delay)
    {
        isCanShoot = false;
        yield return new WaitForSeconds(delay);
        isCanShoot = true;
    }

    public void Upgrade(TowerUpgrades upgrade)
    {
        attackSpeed += upgrade.attackSpeedBonus;
        attackRange += upgrade.attackRangeBonus;
        projectilePrefab = upgrade.projectileBonus ? upgrade.projectileBonus : projectilePrefab;
    }
}
