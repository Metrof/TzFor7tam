using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pig : MonoBehaviour
{
    [Header("Set in inspector")]
    [SerializeField] private float movementSpeed = 5;
    [SerializeField] private Joystick joystick;
    [SerializeField] private List<Sprite> pigSprites;
    [SerializeField] private float knockbackSpeed = 10;
    [SerializeField] private float knockbackDuration = 0.25f;

    [Header("Set Dinamically")]
    private Rigidbody2D rigid;
    private int dirHeld = -1;
    private SpriteRenderer _sprite;
    private Health health;

    private Vector3[] directions = new Vector3[] { Vector3.right, Vector3.down, Vector3.left, Vector3.up };
    private Vector3 knockbackVel;
    private float knockbackDone;
    public int Facing { get; private set; }
    public Vector3 Direction { get; private set; }

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        _sprite = GetComponent<SpriteRenderer>();
        health = GetComponent<Health>();
    }
    private void Update()
    {
        if (Time.time < knockbackDone)
        {
            rigid.velocity = knockbackVel;
            return;
        }
        Vector3 vel = joystick.Direction();
        rigid.velocity = vel * movementSpeed;

        SetSprite();
    }
    void SetSprite()
    {
        dirHeld = -1;
        for (int i = 0; i < 4; i++)
        {
            if (directions[i] == joystick.Direction())
            {
                dirHeld = i;
            }
        }
        if (dirHeld != -1)
        {
            _sprite.sprite = pigSprites[dirHeld];
            Facing = dirHeld;
            Direction = directions[dirHeld];
        }
    }
    public void DamageReaction(Vector3 coll)
    {
        Vector3 delta = transform.position - coll;
        if (Mathf.Abs(delta.x) >= Mathf.Abs(delta.y))
        {
            delta.x = (delta.x > 0) ? 1 : -1;
            delta.y = 0;
        }
        else
        {
            delta.x = 0;
            delta.y = (delta.y > 0) ? 1 : -1;
        }
        knockbackVel = delta * knockbackSpeed;
        rigid.velocity = knockbackVel;

        knockbackDone = Time.time + knockbackDuration;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        DamageEffect damage = collision.gameObject.GetComponent<DamageEffect>();
        if (damage != null && !health.Invincible)
        {
            health.TakeDamage(damage.Damage);
            DamageReaction(collision.transform.position);
        }
    }
}
