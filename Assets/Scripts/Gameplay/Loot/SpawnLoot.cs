using System;
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
        //[SerializeField]
        //private GameObject _gameobject;
        //[SerializeField]
        //private List<GameObject> _lootList;

        [SerializeField]
        private List<LootComponent> _lootComponents;

        private float _totalScore = 0;


        void Awake()
        {
            _spaceship.IsDied += Spawn;
            foreach(var x in _lootComponents)
            {
                _totalScore += x.dropСhance;
            }
         
        }

        //private void SpawnOld(bool IsDead)//not used
        //{
        //    int i = UnityEngine.Random.Range(0, _lootList.Count);
        //    var a = Instantiate(_lootList[i], this.transform.position, this.transform.rotation);
        //}

        private void Spawn(bool IsDead)
        {
            float currentChance = UnityEngine.Random.Range(0.0f, _totalScore + 1.0f);
            float currentValue = 0.0f;
           for(int i = 0; i < _lootComponents.Count; i++)
            {
               currentValue += _lootComponents[i].dropСhance;
               if (currentValue > currentChance)
                {
                    var a = Instantiate(_lootComponents[i].gameObject, this.transform.position, this.transform.rotation);
                    break;
                }
            }
        }

        [Serializable]
        private struct LootComponent
        {
            [SerializeField]
            public GameObject gameObject;
            [SerializeField]
            public float dropСhance;

        }


}
}



