using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatsUI : MonoBehaviour
{
    public Stats playerStats;
    public TextMeshProUGUI healthStatusText;
    public TextMeshProUGUI speedStatusText;
    public TextMeshProUGUI damageStatusText;

    void Start()
    {
        if(playerStats != null) 
        {
            playerStats.OnStatsChanged += UpdateUI;
            UpdateUI();
        }
    }

    private void OnDestroy()
    {
        if(playerStats != null)
        {
            playerStats.OnStatsChanged -= UpdateUI;
        }
    }

    void UpdateUI()
    {
        if(healthStatusText != null)
        {
            healthStatusText.text = "HEALTH: " + playerStats.health;
        }
        if(speedStatusText != null)
        {
            speedStatusText.text = "SPEED: " + playerStats.speed;
        }
        if (damageStatusText != null)
        {
            damageStatusText.text = "DAMAGE: " + playerStats.upgradedDamage;
        }
    }
}
