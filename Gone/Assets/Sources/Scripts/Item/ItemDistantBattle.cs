using UnityEngine;

public class ItemDistantBattle : ItemObject, IItemDistantBattle
{
    [field: SerializeField] public int Damage { get; set; }
    [field: SerializeField] public int SpeedBullet { get; set; }
    [field: SerializeField] public int TimeReload { get; set; }
    [field: SerializeField] public GameObject Bullet { get; set; }

    void Start()
    {
        InitializeSprite();
    }

    void Update()
    {
        
    }
    public void Shot()
    {
      
    }
}
