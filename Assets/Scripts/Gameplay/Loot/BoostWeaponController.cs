using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Gameplay.ShipSystems
{
    public class BoostWeaponController : MonoBehaviour //subscribe on Event -> update UI
    {
        [SerializeField]
        private Text _modifierText;
        [SerializeField]
        private WeaponSystem _weaponSystem;
        private void Awake()
        {
            _weaponSystem.IsChangeModifier += UpdateTextUI;
        }

        private void UpdateTextUI(float modifier)
        {
            _modifierText.text = "Modifier:" + modifier.ToString();
        }
    }



}