using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DamageType { Neutral, Fire, Ice, Heal }
public enum AlterationType { None, Burn, Frozen, Regen }

[System.Serializable]
public class SkillSO : ScriptableObject
{
    [System.Serializable]
    public struct Damage
    {
        public DamageType damageType;
        public int damageValue;
    }

    [System.Serializable]
    public struct Alteration
    {
        public AlterationType alterationType;
        public float alterationChance;
    }

    public float cooldown;

    [Header("Damages")]
    public Damage[] damages; // Transférer au fx ou a la hitbox de l'entité si au cac ?

    [Header("Alterations")]
    public Alteration[] alterations; // Transférer au fx ou a la hitbox de l'entité si au cac ?

    [Header("Animation and effects")]
    public string animationKey;
    public GameObject fx; // Collision sur le fx, if collision, jouer le fx lié à ce fx au point d'impact
    public AudioClip sound; // Idem fx

}
