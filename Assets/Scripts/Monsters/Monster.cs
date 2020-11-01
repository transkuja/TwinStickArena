using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MonsterData : EntityData
{
}

public class Monster : Entity
{
    [SerializeField] MonsterData data;

    private void Start()
    {
        currentHp = data.maxHp;
    }

    // A voir si on fait une bdd de monstres, pour l'instant on configurera le prefab directement
    public void InitMonster(MonsterData _monsterData)
    {
        currentHp = _monsterData.maxHp;
        data = _monsterData;
    }

}
