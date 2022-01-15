using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellCaster : MonoBehaviour
{
    public enum AbilityState
    {
        ready,
        active,
        cooldown
    }

    [SerializeField] private PowerButton powerButton;
    private float cooldownDone;
    private float spellActiveDone;

    private Spell _spell;
    private AbilityState _state = AbilityState.ready;

    private void Update()
    {
        switch (_state)
        {
            case AbilityState.active:
                _spell.Activate(gameObject);
                if (Time.time > spellActiveDone)
                {
                    _spell.BackToDefoltState(gameObject);
                    _state = AbilityState.cooldown;
                    cooldownDone = _spell.Cooldown + Time.time;
                }
                break;
            case AbilityState.cooldown:
                if (Time.time > cooldownDone)
                {
                    _state = AbilityState.ready;
                }
                break;
        }
    }
    public void CastSpell()
    {
        if (_state != AbilityState.ready && _spell == null) return;
        powerButton.Reload(_spell.Cooldown);
        _state = AbilityState.active;
        spellActiveDone = _spell.Duration + Time.time;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PowerBonus bonus = collision.GetComponent<PowerBonus>();
        if (bonus != null && _state != AbilityState.active)
        {
            _spell = bonus.spell;
            powerButton.GetComponent<Image>().sprite = _spell.Icon;
            Destroy(collision.gameObject);
        }
    }

    public Spell Spell { get { return _spell; } set { _spell = value; } }
    public AbilityState State { get { return _state; } set { _state = value; } }
}
