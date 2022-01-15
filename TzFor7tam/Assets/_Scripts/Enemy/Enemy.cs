using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected static Vector3[] directions = new Vector3[] { Vector3.right, Vector3.left, Vector3.down, Vector3.up };

    protected Rigidbody2D rigid;
    protected SpriteRenderer sRend;
    protected Health health;

    protected virtual void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        sRend = GetComponent<SpriteRenderer>();
        health = GetComponent<Health>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        DamageEffect damage = collision.gameObject.GetComponent<DamageEffect>();
        if (damage != null)
        {
            if (health.Invincible) return;
            health.TakeDamage(damage.Damage);
        }
    }
}
