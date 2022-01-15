using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEffect : MonoBehaviour
{
    [SerializeField] private int objDamage = 20;
    public int Damage { get; private set; }
    private void Start()
    {
        Damage = objDamage;
    }
}
