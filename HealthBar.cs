using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image CurrentHealthBar1;
    [SerializeField] private Image DamageHealthBar1;
    [SerializeField] private Image CurrentHealthBar2;
    [SerializeField] private Image DamageHealthBar2;
    private HealthSystem _healthSystem;

    private const float _damagedHealthShrinkTimerMax = 1;
    private float _damagedHealthShrinkTimer;


    private void Update()
    {
        ShrinkBar();
    }


    private void ShrinkBar()
    {
        _damagedHealthShrinkTimer -= Time.deltaTime;
        if (_damagedHealthShrinkTimer < 0)
        {
            if (CurrentHealthBar1.fillAmount < DamageHealthBar1.fillAmount)
            {
                float shrinkSpeed = 0.5f;
                DamageHealthBar1.fillAmount -= shrinkSpeed * Time.deltaTime;
                if (DamageHealthBar2 != null) DamageHealthBar2.fillAmount -= shrinkSpeed * Time.deltaTime;
            }
            else if (CurrentHealthBar1.fillAmount < DamageHealthBar1.fillAmount)
            {
                DamageHealthBar1.fillAmount = CurrentHealthBar1.fillAmount;
                if (DamageHealthBar2 != null) DamageHealthBar2.fillAmount = CurrentHealthBar2.fillAmount;
            }
        }
    }

    public void Setup(HealthSystem healthSystem)
    {
        this._healthSystem = healthSystem;
        healthSystem.OnHealthChanged += HealthSystem_OnHealthChanged;
    }

    private void HealthSystem_OnHealthChanged(object sender, System.EventArgs e)
    {
        _damagedHealthShrinkTimer = _damagedHealthShrinkTimerMax;
        CurrentHealthBar1.fillAmount = _healthSystem.GetHealthPercent();
        if (CurrentHealthBar2 != null) CurrentHealthBar2.fillAmount = _healthSystem.GetHealthPercent();
        if (CurrentHealthBar1.fillAmount > DamageHealthBar1.fillAmount)
        {
            DamageHealthBar1.fillAmount = _healthSystem.GetHealthPercent();
            if (DamageHealthBar2 != null) DamageHealthBar2.fillAmount = _healthSystem.GetHealthPercent();
        }
    }
}
