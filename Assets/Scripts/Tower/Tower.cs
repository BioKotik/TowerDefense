using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] private float attackSpeed;
    [SerializeField] private float attackRange;
    [SerializeField] private Projectile projectilePrefab;
    [SerializeField] private GameObject target;
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

    public void Attack(Transform target)
    {
        Instantiate(projectilePrefab, transform.position, Quaternion.identity).Attack(target);
    }

    private void Update()
    {
        if (Input.GetMouseButton(0) && CheckRange(target.transform))
        {
            if (isCanShoot)
            {
                Attack(target.transform);
                StartCoroutine(Reload(reloadTime));
            }
        }
    }

    private IEnumerator Reload(float delay)
    {
        isCanShoot = false;
        yield return new WaitForSeconds(delay);
        isCanShoot = true;
    }

    private bool CheckRange(Transform target)
    {
        if (Vector3.Distance(transform.position, target.position) <= attackRange)
        {
            return true;
        }

        return false;
    }

    public void Upgrade(TowerUpgrades upgrade)
    {
        attackSpeed += upgrade.attackSpeedBonus;
        attackRange += upgrade.attackRangeBonus;
        projectilePrefab = upgrade.projectileBonus ? upgrade.projectileBonus : projectilePrefab;
    }
}
