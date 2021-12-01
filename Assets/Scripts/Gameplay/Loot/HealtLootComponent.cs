using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealtLootComponent : MonoBehaviour //heal player if Collision2D
{
    [SerializeField]
    private float _hitPoints;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            HitPointsComponent hitPointsComponent = other.gameObject.GetComponent<HitPointsComponent>();
            if (hitPointsComponent != null)
            {
                hitPointsComponent.GetHeal(_hitPoints);
                Destroy(this.gameObject);
            }
            
        }
        
    }


}

