using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitPointsComponent : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float _MaxHP;
    [SerializeField] private Text _healthBar;
    private float _hp;

    void Start()
    {
        _hp = _MaxHP;
        _healthBar.text = "HitPoints:" + _hp.ToString();
    }

    public float GetDamage(float hitPoints)
    {
        _hp = Mathf.Max(0, _hp - hitPoints);
        _healthBar.text = "HitPoints:" + _hp.ToString();
        return _hp;
    }
    public float GetHeal(float hitPoints)
    {
        _hp = Mathf.Min(_hp + hitPoints, _MaxHP);
        _healthBar.text = "HitPoints:" + _hp.ToString();
        return _hp;
    }


}

