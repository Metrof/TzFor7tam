using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TuskController : MonoBehaviour
{
    [Header("Set Dinamically")]
    private GameObject tusk;
    private Pig pig;
    private SpellCaster caster;

    private void Start()
    {
        tusk = transform.Find("tusk").gameObject;
        pig = transform.parent.GetComponent<Pig>();
        caster = transform.parent.GetComponent<SpellCaster>();
        tusk.SetActive(false);
    }

    private void Update()
    {
        transform.rotation = Quaternion.Euler(0, 0, -90 * pig.Facing);
        if (caster.Spell != null)
        {
            if (caster.Spell.SpellName == SpellName.Charge && caster.State == SpellCaster.AbilityState.active)
            {
                tusk.SetActive(true);
            } else
            {
                tusk.SetActive(false);
            }
        }
    }
}
