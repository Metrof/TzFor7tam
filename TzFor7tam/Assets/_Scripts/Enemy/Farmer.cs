using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Farmer : Enemy
{
    [Header("Set in Inspector: Farmer")]
    [SerializeField] private int speed = 2;
    [SerializeField] private float timeThinkMin = 1f;
    [SerializeField] private float timeThinkMax = 3f;
    [SerializeField] private List<Sprite> farmerSprites;

    [Header("Set Dinamically: Farmer")]
    private int facing = 0;
    private float timeNextDecision = 0;

    protected override void Awake()
    {
        base.Awake();
    }
    private void Update()
    {
        if (Time.time >= timeNextDecision)
        {
            DecideDirection();
        }

        rigid.velocity = directions[facing] * speed;

        sRend.sprite = farmerSprites[facing];
    }
    void DecideDirection(int fIng = -1)
    {
        if (fIng == -1)
        {
            facing = Random.Range(0, 4);
        }
        else
        {
            facing = fIng;
        }
        timeNextDecision = Time.time + Random.Range(timeThinkMin, timeThinkMax);
    }
}
