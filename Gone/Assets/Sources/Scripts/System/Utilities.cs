using System;
using UnityEngine;

public interface IInputSystem
{
    public float GetHorizontal();
    public float GetVertical();

    public static Action EventDownE;
    public static Action EventDownSpace;
    public static Action EventDownTab;
}

public class ItemObject : MonoBehaviour, IItem
{
   [field: SerializeField] public int Strength { get; set; }
   [field: SerializeField] public int Break { get; set; }
   public Sprite MySprite { get; set; }

    protected void InitializeSprite() => MySprite = GetComponent<SpriteRenderer>().sprite;
    protected virtual void BreaksDown() => Strength -= Break;
}

public interface IItem
{
    public Sprite MySprite { get; set; }
}


public interface IItemMelee
{
    public int Damage { get; set; }
    public int SpeedAttack { get; set; }
    public int RadiusDamage { get; set; }
    public void Attack();
}

public interface IItemDistantBattle
{
    public int Damage { get; set; }
    public int SpeedBullet { get; set; }
    public int TimeReload { get; set; }
    public GameObject Bullet { get; set; }
    public void Shot();
}

public interface IItemThrown
{
    public int Damage { get; set; }
    public int SpeedFlight { get; set; }
    public void Throw();
}
