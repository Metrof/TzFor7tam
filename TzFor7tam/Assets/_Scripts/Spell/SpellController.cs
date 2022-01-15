using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellController : MonoBehaviour
{
    static Dictionary<SpellName, Spell> SPELL_DICT;

    public Spell[] spellDefinitions;
    private void Awake()
    {
        SPELL_DICT = new Dictionary<SpellName, Spell>();
        foreach (Spell def in spellDefinitions)
        {
            SPELL_DICT[def.SpellName] = def;
        }
    }
    static public Spell GetSpellDefinition(SpellName sn)
    {
        if (SPELL_DICT.ContainsKey(sn))
        {
            return SPELL_DICT[sn];
        }

        return new Spell();
    }
}
