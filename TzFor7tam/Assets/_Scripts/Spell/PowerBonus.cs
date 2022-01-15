using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerBonus : MonoBehaviour
{
    [Header("Set in Inspector")]
    [SerializeField] private SpellName spellName;
    public Spell spell { get; private set; }
    private SpriteRenderer _spriteRenderer;
    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Start()
    {
        spell = SpellController.GetSpellDefinition(spellName);
        _spriteRenderer.sprite = spell.Icon;
    }
}
