using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum SpellName
{
    Charge,
    Kick,
    Invisible
}
public class Spell : ScriptableObject
{
    [SerializeField] Sprite _icon;

    [SerializeField] float _cooldown;

    [SerializeField] float _duration;

    [SerializeField] bool _preparation;

    [SerializeField] SpellName _spellName;
    public Sprite Icon { get { return _icon; } protected set { _icon = value; } }
    public float Cooldown { get { return _cooldown; } protected set { _cooldown = value; } }
    public float Duration { get { return _duration; } protected set { _duration = value; } }
    public bool Preparation { get { return _preparation; } protected set { _preparation = value; } }
    public SpellName SpellName { get { return _spellName; } protected set { _spellName = value; } }

    public virtual void Activate(GameObject pig)
    {

    }
    public virtual void BackToDefoltState(GameObject pig)
    {

    }
}
