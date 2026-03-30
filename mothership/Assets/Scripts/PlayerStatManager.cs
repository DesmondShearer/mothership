using System.Collections.Generic;
using UnityEngine;

public class PlayerStatManager : MonoBehaviour
{
    [System.Serializable]
    public class StatsAtRuntime
    {
        public PlayerStat playerStat;
        public float currentValue;
    }
    
    public List<StatsAtRuntime> playerStats = new List<StatsAtRuntime>();
    public CreditManager creditManager;
    
    
    void Start()
    {
        InitializeStats();
    }

    // Update is called once per frame
    void InitializeStats()
    {
        foreach (var s in playerStats)
        {
            s.currentValue = s.playerStat.baseValue;
        }
    }
    public float GetStatValue(PlayerStat stat)
    {
        var found = playerStats.Find(s => s.playerStat == stat);
        return found != null ? found.currentValue : 0;
    }

    public void ApplyUpgrade(PlayerStatUpgrade playerStatUpgrade)
    {
        if (creditManager.totalCredits < playerStatUpgrade.upgradePrice)
        {
            Debug.Log("Not enough currency!");
            return;
        }

        var stat = playerStats.Find(s => s.playerStat == playerStatUpgrade.targetStat);

        if (stat != null)
        {
            stat.currentValue += playerStatUpgrade.increaseAmount;
            creditManager.UpdateCredits(-playerStatUpgrade.upgradePrice);

            Debug.Log($"{playerStatUpgrade.targetStat.statName} upgraded!");
        }
    }
}