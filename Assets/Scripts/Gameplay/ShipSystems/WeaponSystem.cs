using System.Collections.Generic;
using Gameplay.Weapons;
using UnityEngine;
using System.Linq;

namespace Gameplay.ShipSystems
{
    public class WeaponSystem : MonoBehaviour, IWeaponSpeedModifier
    {

        [SerializeField]
        private List<Weapon> _weapons;

        private float _totalTimeDuration = 0.0f;
        private float _totalModifier = 1.0f;
        private bool _modifierActive = false;
        private float _fixedTimeDeltaTime;

        public event Action<float> IsChangeModifier;

        private void Awake()
        {
            _fixedTimeDeltaTime = Time.fixedDeltaTime;
        }




        public void Init(UnitBattleIdentity battleIdentity)
        {
            _weapons.ForEach(w => w.Init(battleIdentity));
        }

        public void TriggerFire()
        {
            _weapons.ForEach(w => w.TriggerFire());
        }

        //Since it was not clearly stated in the assignment how to implement modifiers.
        //Here's a simple solution suggested:
        //adding time to the time of action of the last modifier. 
        public void ModifyWeaponSpeed(float duration, float modifier)
        {
            _totalTimeDuration += duration;
            _totalModifier = modifier;
            
        }
        
        private void FixedUpdate()
        {
            if (_totalTimeDuration > 0)
            {
                _totalTimeDuration -= _fixedTimeDeltaTime;
            }

            if (_totalTimeDuration > 0 && !_modifierActive)
            {
                _weapons.ForEach(w => w.Cooldown = (w.Cooldown / _totalModifier) );
                _modifierActive = true;
                IsChangeModifier?.Invoke(_totalModifier);//event for UI controller
            }
            else if(_totalTimeDuration <= 0 && _modifierActive)
            {
                _weapons.ForEach(w => w.Cooldown = w.Cooldown );
                _totalModifier = 1.0f;
                _modifierActive = false;
                IsChangeModifier?.Invoke(_totalModifier);
            }
        }

    }
}
