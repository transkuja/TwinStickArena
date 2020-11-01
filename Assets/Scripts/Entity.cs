using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EntityData
{
    public int maxHp;
}

public class Entity : MonoBehaviour
{
    [SerializeField] protected int currentHp;

    public void TakeDamage(int damageTaken)
    {
        currentHp -= damageTaken;
        if (currentHp <= 0)
            Destroy(gameObject);
    }

}
