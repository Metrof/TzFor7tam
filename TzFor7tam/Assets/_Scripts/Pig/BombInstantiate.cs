using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombInstantiate : MonoBehaviour
{
    [SerializeField] private GameObject bombPreffab;
    [SerializeField] private BombButton bombButt;
    private Pig pig;
    public Bomb lastBomb { get; private set; }
    private void Awake()
    {
        pig = GetComponent<Pig>();
    }
    public void PlantBomb()
    {
        GameObject bomb = Instantiate(bombPreffab);
        bomb.transform.position = transform.position + pig.Direction;
        lastBomb = bomb.GetComponent<Bomb>();
        bombButt.Reload();
    }
}
