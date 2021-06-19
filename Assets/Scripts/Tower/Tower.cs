using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] private float attackSpeed;
    [SerializeField] private float attackRange;
    [SerializeField] private Projectile projectilePrefab;
    [SerializeField] private GameObject target;
    [SerializeField] private TowerUpgrades upgrade;

    private void Init()
    {
        attackSpeed += upgrade.attackSpeedBonus;
        attackRange += upgrade.attackRangeBonus;
        projectilePrefab = upgrade.projectileBonus ? upgrade.projectileBonus : projectilePrefab;
    }

    private void Awake()
    {
        Init();
    }

    public void Attack(Transform target)
    {
        Instantiate(projectilePrefab, transform.position, Quaternion.identity).Attack(target);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && CheckRange(target.transform))
        {
            Attack(target.transform);
        }
    }

    private bool CheckRange(Transform target)
    {
        if (Vector3.Distance(transform.position, target.position) <= attackRange)
        {
            return true;
        }

        return false;
    }
}
