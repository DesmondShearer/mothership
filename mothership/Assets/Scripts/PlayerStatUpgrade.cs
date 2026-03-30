using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStatUpgrade", menuName = "Scriptable Objects/PlayerStatUpgrade")]
public class PlayerStatUpgrade : ScriptableObject
{
    public PlayerStat targetStat;
    public float increaseAmount;
    public int upgradePrice;  
}
