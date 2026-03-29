using UnityEngine;
    
[CreateAssetMenu(fileName = "TargetType", menuName = "Scriptable Objects/TargetType")]
public class TargetType : ScriptableObject
{
    [SerializeField] public float maxHealth;
    [SerializeField] public float creditValue;
}
