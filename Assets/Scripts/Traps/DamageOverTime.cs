using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOverTime : MonoBehaviour
{
    int damage = 0;
    Entity entity;

    public void Init(int _damage)
    {
        StartCoroutine(DamageOverTimeCoroutine(_damage));
    }

    IEnumerator DamageOverTimeCoroutine(int _damage)
    {
        damage = _damage;
        entity = GetComponent<Entity>();

        while (true)
        {
            if (entity != null)
                entity.TakeDamage(damage);

            yield return new WaitForSeconds(0.5f);
        }
    }

}
