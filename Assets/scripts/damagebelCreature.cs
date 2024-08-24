using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damagebelCreature : MonoBehaviour
{
    [SerializeField] private bool haveBlood;
    [Header("stats")]
    [SerializeField] private int strength;
    [SerializeField] private int agility;
    private bool isBleed;
}
