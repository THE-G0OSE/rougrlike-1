using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damagebelCreature : MonoBehaviour
{

    [SerializeField] private bool haveBlood;

    [Header("stats")]
    
    
    [SerializeField] private int strength;
    public int Strength { get { return strength; } set {  strength = value; } }
    [SerializeField] private int agility;
    public int Agility { get { return agility; } set { agility = value; } }
    [SerializeField] private int durability;
    public int Durability { set { durability = value; } get { return durability; } }

    [Header("basic stats")]
    
    
    [SerializeField] private float baseSpeed;
    public float BaseSpeed { get { return baseSpeed; } }
    [SerializeField] private int baseBlood;
    public int BaseBlood { get { return baseBlood; } }
    
    [Header("Body parts")]



    [SerializeField] private int baseLeftArmHealth;
    public int BaseLeftArmHealth { get { return baseLeftArmHealth; } }
    private bool haveLeftArm;
    
    
    [SerializeField] private int baseRightArmHealth;
    public int BaseRightArmHealth { get { return baseRightArmHealth; } }
    private bool haveRightArm;
    
    
    [SerializeField] private int baseRightLegHealth;
    public int BaseRightLegHealth { get { return baseRightLegHealth; } }
    private bool haveRightLeg;

    
    [SerializeField] private int baseLeftLegHealth;
    public int BaseLeftLegHealth { get { return baseLeftLegHealth; } }
    private bool haveLeftLeg;

    
    [SerializeField] private int baseHeadHealth;
    public int BaseHeadHealth {  get { return baseHeadHealth; } }
    
    
    [SerializeField] private int baseTorsoHealth;
    public int BaseTorsoHealth { get { return baseTorsoHealth; } }



    private bool isBleeding;



    public void HitRightArm(int damage)
    {
        if (baseRightArmHealth > 0)
        {
            baseRightArmHealth -= damage;
            if (baseRightArmHealth <= 0)
            {
                haveRightArm = false;
            }
        }
    }





    
}
