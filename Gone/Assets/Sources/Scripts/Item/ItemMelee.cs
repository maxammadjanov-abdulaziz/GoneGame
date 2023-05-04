using UnityEngine;

public class ItemMelee : ItemObject,  IItemMelee
{
    [field: SerializeField] public int Damage { get; set; }
    [field: SerializeField] public int SpeedAttack { get; set; }
    [field: SerializeField] public int RadiusDamage { get; set; }

    void Start()
    {
        InitializeSprite();
    }

    void Update()
    {
        
    }

    public void Attack()
    {
      
    }

}
