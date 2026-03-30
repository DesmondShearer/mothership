using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StatUI : MonoBehaviour
{
    public PlayerStatManager playerStatManager;
    
    public TextMeshProUGUI statText;
    public TextMeshProUGUI priceText;
    public Button upgradeButton;

    public PlayerStatUpgrade playerStatUpgrade;

    private void Start()
    {
        upgradeButton.onClick.AddListener(OnUpgradeClicked);
        UpdateUI();
    }

    void UpdateUI()
    {
        playerStatManager.GetStatValue(playerStatUpgrade.targetStat);

        statText.text = $"{playerStatUpgrade.targetStat.statName} +{playerStatUpgrade.increaseAmount}";
        priceText.text = $"${playerStatUpgrade.upgradePrice}";
    }

    void OnUpgradeClicked()
    {
        playerStatManager.ApplyUpgrade(playerStatUpgrade);
        UpdateUI();
    }
}