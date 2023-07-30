using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestFight : MonoBehaviour
{
    [SerializeField] private FightPerson hero;
    [SerializeField] private FightPerson dog;

    [SerializeField] private FightPerson enemy;

    [SerializeField] private FightManager fightManager;

    public void StartFight()
    {
        fightManager.StartFight(new List<FightPerson> {hero, dog}, new List<FightPerson> {enemy} );
    }
}
