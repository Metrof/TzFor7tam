using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] private GameObject explPreff;
    [SerializeField] private float timeToExplosion = 2;

    private float timeDone;
    private float _kickDone;
    private Vector3 _kickVel;

    private Rigidbody2D rigid;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        timeDone = Time.time + timeToExplosion;
    }
    private void Update()
    {
        rigid.velocity = Vector3.zero;
        if (KickDone > Time.time)
        {
            rigid.velocity = _kickVel;
        }
        if (Time.time > timeDone)
        {
            Explousion();
        }
    }
    public void Explousion()
    {
        GameObject pointToExplo = Instantiate(explPreff);
        pointToExplo.transform.position = transform.position;
        Destroy(gameObject);
        Destroy(pointToExplo, 0.35f);
    }

    public Vector3 KickVel { get { return _kickVel; } set { _kickVel = value; } }

    public float KickDone { get { return _kickDone; } set { _kickDone = value; } }
}
