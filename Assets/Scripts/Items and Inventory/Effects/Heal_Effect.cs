using UnityEngine;

[CreateAssetMenu(fileName = "Heal Effect", menuName = "Data/Item Effect/Heal Effect")]
public class Heal_Effect : ItemEffect
{
    [Range(0f,1f)]
    [SerializeField] private float healPercent;
    
    public override void ExecuteEffect(Transform _enemyPosition)
    {
        PlayerStats playerStats = PlayerManager.instance.player.GetComponent<PlayerStats>();
        AudioManager.instance.PlaySFX(43,null);
        int healAmount = Mathf.RoundToInt(playerStats.GetMaxHealthValue() * healPercent);
        
        playerStats.IncreaseHealthBy(healAmount);
    }
}
