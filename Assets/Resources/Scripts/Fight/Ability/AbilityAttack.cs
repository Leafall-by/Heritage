using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new AbilityAttack", menuName = "Ability/AbilityAttack", order = 53)]
public class AbilityAttack : AbilityEnemyTarget
{
    [SerializeField] private int damage;

    public override void Use(FightPerson target)
    {
        target.Health -= damage;
    }
}
