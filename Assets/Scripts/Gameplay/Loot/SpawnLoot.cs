using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
namespace Gameplay.Spaceships
{


    public class SpawnLoot : MonoBehaviour // Random Instantiate LootItem, subscribe on SpaceShip
    {
        [SerializeField]
        private Spaceship _spaceship;
        [SerializeField]
        private GameObject _gameobject;
        [SerializeField]
        private List<GameObject> _lootList;

        
        void Awake()
        {
            _spaceship.IsDied +=Spawn;
        }

        private void Spawn(bool IsDead)
        {
            int i = Random.Range(0, _lootList.Count);       
            var a = Instantiate(_lootList[i], this.transform.position, this.transform.rotation);
         }
    }
}



