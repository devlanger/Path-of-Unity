using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatsUi : MonoBehaviour
{
    [SerializeField]
    private Human player;

    [SerializeField]
    private Slider manaBar;

    [SerializeField]
    private Slider healthBar;

    private void Start()
    {
        player.OnManaChanged += Player_OnManaChanged;
        player.OnHealthChanged += Player_OnHealthChanged;
    }

    private void Player_OnHealthChanged(Human obj)
    {
        healthBar.value = obj.health / 100f;
    }

    private void Player_OnManaChanged(Human obj)
    {
        manaBar.value = obj.mana / 100f;
    }
}
