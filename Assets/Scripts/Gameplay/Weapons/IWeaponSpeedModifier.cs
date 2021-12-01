using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeaponSpeedModifier // interface for our implementation if Player loot modifier box
{
    void ModifyWeaponSpeed(float duration, float modifier);
}
