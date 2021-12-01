using System;
using Gameplay.ShipControllers;
using Gameplay.ShipSystems;
using Gameplay.Weapons;
using UnityEngine;

namespace Gameplay.Spaceships
{
    public class Spaceship : MonoBehaviour, ISpaceship, IDamagable
    {
        [SerializeField]
        private ShipController _shipController;
    
        [SerializeField]
        private MovementSystem _movementSystem;
    
        [SerializeField]
        private WeaponSystem _weaponSystem;

        [SerializeField]
        private UnitBattleIdentity _battleIdentity;

        [SerializeField]
        private HitPointsComponent _hitPointsComponent;

        public event Action<bool> IsDied;

        private ScoreManager _scoreManager;
        private bool IsDestroy = false;

        public MovementSystem MovementSystem => _movementSystem;
        public WeaponSystem WeaponSystem => _weaponSystem;

        public UnitBattleIdentity BattleIdentity => _battleIdentity;

        private void Awake()
        {
            _scoreManager = ScoreManager.instance; //singlton manager. I prefer Zenject for this purpose, but decided not to change Architecture
        }
        private void Start()
        {
            _shipController.Init(this);
            _weaponSystem.Init(_battleIdentity);
        }

        public void ApplyDamage(IDamageDealer damageDealer)
        {
            if(this.gameObject.CompareTag("Player"))
            {
                _hitPointsComponent.GetDamage(damageDealer.Damage);
            }
            else if (!IsDestroy)//just to avoid double spawn lootboxes
            {
                IsDestroy = true;
                Destroy(gameObject);
                IsDied?.Invoke(true);//for scoreManager
                _scoreManager.Addscore();
            }
            
        }

    }
}
