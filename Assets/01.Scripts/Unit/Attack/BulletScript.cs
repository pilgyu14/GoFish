using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : PoolableObject
{
    private float speed;
    private float damage;
    private Transform target;

    #region 애니메이션
    private Animator animator;
    private int hashCollision = Animator.StringToHash("Collision");
    #endregion

    protected virtual void Awake()
    {
        animator = GetComponent<Animator>();
    }

    protected virtual void Update()
    {
        Move();
    }

    protected virtual void Move()
    {
        transform.position += (target.position - transform.position).normalized * speed * Time.deltaTime;
        transform.rotation = Quaternion.Euler(target.position - transform.position);
    }

    protected virtual void OnCollisionEnter(Collision collision)
    {
        UnitScript unit = collision.gameObject.GetComponent<UnitScript>();
        if (unit != null)
        {
            unit.GetHit(damage);
            animator.SetTrigger(hashCollision);
            StartCoroutine(DeathCoroutine());
        }
    }

    protected IEnumerator DeathCoroutine()
    {
        yield return new WaitForSeconds(1f);
        PoolManager.Instance.Push(this);
    }

    public void SettingBullet(Vector3 startPos, Transform target, float damage, float atkSpeed)
    {
        transform.position = startPos;
        this.target = target;
        this.damage = damage;
        speed = atkSpeed * 10;
    }

    public override void Reset()
    {
        
    }
}
