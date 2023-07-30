using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class FightManager : MonoBehaviour
{
    [SerializeField] private GameObject fightCanvas;
    [SerializeField] private FightPersonUI[] teamUI;
    [SerializeField] private FightPersonUI[] enemyUI;
    [SerializeField] private AbilityUI[] abilitiesUI;

    private List<FightPerson> team;
    private List<FightPerson> enemy;

    private FightPerson selectedHero;

    private void Start()
    {
        foreach (var person in teamUI)
        {
            person.OnClick.AddListener(TryChangeHero);
        }
        foreach (var person in enemyUI)
        {
            person.OnClick.AddListener(TryChangeHero);
        }
    }

    public void StartFight(List<FightPerson> team, List<FightPerson> enemies)
    {
        fightCanvas.SetActive(true);

        for (int i = 0; i < team.Count; i++)
        {
            if (teamUI[i].IsAvaialable())
            {
                teamUI[i].SetPerson(team[i]);
            }
        }

        for (int i = 0; i < enemies.Count; i++)
        {
            if (enemyUI[i].IsAvaialable())
            {
                enemyUI[i].SetPerson(enemies[i]);
            }
        }

        this.team = team;
        this.enemy = enemies;

        TryChangeHero(team[0]);

        UseEnemyTargetSpell(null);
    }

    public void TryChangeHero(FightPerson hero)
    {
        foreach (var item in abilitiesUI)
        {
            item.UnSetAbility();
        }

        if (enemy.Contains(hero))
        {
            return;
        }

        for (int i = 0; i < hero.spells.Length; i++)
        {
            abilitiesUI[i].SetAbility(hero.spells[i]);
        }
    }

    private void UseSpell(Ability ability)
    {
        if (ability is AbilityEnemyTarget aet)
        {
            UseEnemyTargetSpell(aet);
        }
        else if (ability is AbilityFriendTarget aft)
        {
            UseFriendTargetSpell(aft);
        }
    }

    private void UseEnemyTargetSpell(AbilityEnemyTarget ability)
    {
        for (int i = 0; i < enemy.Count; i++)
        {
            enemyUI[i].SetBorder();
        }
    }

    private void UseFriendTargetSpell(AbilityFriendTarget aft)
    {

    }
}
