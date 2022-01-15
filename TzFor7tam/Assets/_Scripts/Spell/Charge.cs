using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Charge : Spell
{
    [SerializeField] private float chargeVel = 20;
    private Rigidbody2D rigid;
    private Pig pigMover;
    public override void Activate(GameObject parent)
    {
        if (!Preparation)
        {
            pigMover = parent.GetComponent<Pig>();
            rigid = parent.GetComponent<Rigidbody2D>();
            pigMover.gameObject.layer = LayerMask.NameToLayer("RacingPlayer");
            Preparation = true;
        }
        rigid.velocity = pigMover.Direction * chargeVel;
    }
    public override void BackToDefoltState(GameObject pig)
    {
        pigMover.gameObject.layer = LayerMask.NameToLayer("Player");
        Preparation = false;
    }
}
