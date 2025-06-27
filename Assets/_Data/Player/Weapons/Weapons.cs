using System.Collections.Generic;
using UnityEngine;

public class Weapons : MyMonoBehaviour
{
    [SerializeField]protected List<WeaponAbstract> weapons = new();
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadWeapons();
    }
    protected virtual void LoadWeapons()
    {
        if (weapons.Count > 0) return;
        foreach (Transform child  in transform)
        {
            WeaponAbstract weaponAbstract = child.GetComponentInChildren<WeaponAbstract>();
            if (weaponAbstract == null) continue;
            this.weapons.Add(weaponAbstract);
        }
        Debug.Log(transform.name + "LoadAttackPoint",gameObject);
    }


    public virtual WeaponAbstract GetCurrentWeapon()
    {
        return weapons[0];
    }
}
