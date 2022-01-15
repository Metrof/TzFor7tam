using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Kick : Spell
{
    [SerializeField] float distanceToBomb = 1;
    [SerializeField] float kickSpeed = 10;
    Vector3 kickVel;
    BombInstantiate instantiate;
    Bomb kBomb;
    public override void Activate(GameObject parent)
    {
        if (!Preparation)
        {
            instantiate = parent.GetComponent<BombInstantiate>();
            if (instantiate.lastBomb == null) return;
            kBomb = instantiate.lastBomb;
            Preparation = true;
        }

        Vector3 delta = kBomb.transform.position - parent.transform.position;

        if (delta.magnitude <= distanceToBomb)
        {
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
            kickVel = delta * kickSpeed;

            kBomb.KickVel = kickVel;
            kBomb.KickDone = Time.time + Duration;
        }
    }
    public override void BackToDefoltState(GameObject pig)
    {
        Preparation = false;
    }
}
