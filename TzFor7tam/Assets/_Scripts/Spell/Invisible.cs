using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Invisible : Spell
{
    [SerializeField] float alphaColor = .5f;
    SpriteRenderer invisibleSprite;
    public override void Activate(GameObject parent)
    {
        if (!Preparation)
        {
            parent.gameObject.layer = LayerMask.NameToLayer("InvisiblePlayer");
            invisibleSprite = parent.GetComponent<SpriteRenderer>();
            invisibleSprite.color = new Color(1, 1, 1, alphaColor);
            Preparation = true;
        }
    }
    public override void BackToDefoltState(GameObject pig)
    {
        pig.gameObject.layer = LayerMask.NameToLayer("Player");
        invisibleSprite.color = new Color(1, 1, 1, 1);
        Preparation = false;
    }
}
