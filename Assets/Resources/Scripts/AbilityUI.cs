using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityUI : MonoBehaviour
{
    [SerializeField] private Image image;
    public Ability ability;

    public void SetAbility(Ability ability)
    {
        image.enabled = true;
        this.ability = ability;
        image.sprite = ability.image;
    }

    public void UnSetAbility()
    {
        image.enabled = false;
        this.ability = null;
        image.sprite = null;
    }
}
