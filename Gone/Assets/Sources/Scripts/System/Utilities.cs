using System;
using UnityEngine;

public interface IInputSystem
{
    public float GetHorizontal();
    public float GetVertical();

    public static Action EventDownE;
    public static Action EventDownSpace;
}

public class IItem: MonoBehaviour
{
    public int Strength { get; set; }
    public int Break { get; set; }

    public virtual void BreaksDown()
    {
         Strength -= Break;
    }


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
