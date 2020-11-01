using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityData
{
    public int maxHp;
}

public class Entity : MonoBehaviour
{
    protected int currentHp;

    public void TakeDamage(int damageTaken)
    {
        currentHp -= damageTaken;
        if (currentHp <= 0)
            Destroy(gameObject);
    }

}
