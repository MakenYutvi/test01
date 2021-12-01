using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostWeaponComponent : MonoBehaviour //if collision -> try to change modifier
{
   
    [SerializeField]
    private float _boostWeaponTimer;
    [SerializeField]
    private float _boostWeaponModifier;
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            var weaponSpeedModifier = other.gameObject.GetComponent<IWeaponSpeedModifier>();
            if (weaponSpeedModifier != null)
            {
                weaponSpeedModifier.ModifyWeaponSpeed(_boostWeaponTimer, _boostWeaponModifier);
                Destroy(this.gameObject);
            }
        }
    }
}
