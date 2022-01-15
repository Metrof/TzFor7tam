using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int maxHP = 1000;
    private float invincibleDuration = 2f;
    private SpriteRenderer _sprite;
    private float invincibleDone = 0;
    private float alphaSpeedChange = 13;

    public bool Invincible { get; private set; }
    public int HitPoints { get; private set; }
    private void Awake()
    {
        _sprite = GetComponent<SpriteRenderer>();
    }
    private void Start()
    {
        HitPoints = maxHP;
        Invincible = false;
    }
    private void Update()
    {
        if (Invincible)
        {
            Color invincibleColor = new Color(1, 1, 1, 0.5f + Mathf.Sin(Time.time * alphaSpeedChange) * 0.25f);
            _sprite.color = invincibleColor;
            if (Time.time > invincibleDone)
            {
                Invincible = false;
                _sprite.color = new Color(1, 1, 1, 1);
            }
        }
    }
    public void TakeDamage(int damage)
    {
        HitPoints -= damage;
        Invincible = true;
        invincibleDone = Time.time + invincibleDuration;
        if (HitPoints < 0) HitPoints = 0;
    }
}
