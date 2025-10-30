using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour
{
    [Header("プレイヤーのステータス")]
    [SerializeField] private float maxHP;
    private float currentHP;
    [SerializeField] private float maxSpecialGauge = 100f;
    private float currentSpecialGauge;
    private float falterTime = 0.65f;

    [SerializeField] private Slider playerHPSlider;

    public float MaxHP { get => maxHP; private set => maxHP = value; }
    public float CuurentHP { get => currentHP; set => currentHP = value; }
    public float MaxSpecialGauge { get => maxSpecialGauge; private set => maxSpecialGauge = value; }
    public float CurrentSoecialGauge { get => currentSpecialGauge; set => currentSpecialGauge = value; }

    [Header("イベント")]
    public UnityEvent OnDead;
    public UnityEvent<float> OnHPChanged;
    public UnityEvent<float> OnSpecialGaugeChanged;

    // Start is called before the first frame update
    void Start()
    {
        currentHP = maxHP;
        currentSpecialGauge = 0f;
        UpdateUI();
    }
    /// <summary>
    /// ダメージを受ける
    /// </summary>
    /// <param name="_damage"></param>
    public void TakeDamage(float _damage)
    {
        currentHP -= _damage;
        currentHP = Mathf.Clamp(currentHP, 0 , maxHP);

        OnHPChanged?.Invoke(currentHP / maxHP);
        UpdateUI();

        if (currentHP <= 0) OnDead?.Invoke();
    }
    /// <summary>
    /// 回復
    /// </summary>
    /// <param name="_amount"></param>
    public void Heal(float _amount)
    {
        currentHP += _amount;
        currentHP = Mathf.Clamp(currentHP, 0, maxHP);
        OnHPChanged?.Invoke(currentHP / maxHP);
        UpdateUI();
    }
    public void AddSpecialGauge(float _amount)
    {
        currentSpecialGauge += _amount;
        currentSpecialGauge = Mathf.Clamp(currentSpecialGauge, 0, maxSpecialGauge);
        OnSpecialGaugeChanged?.Invoke(currentSpecialGauge / maxSpecialGauge);
        UpdateUI();
    }
    public bool UseSpecialGauge()
    {
        if(currentSpecialGauge >= maxSpecialGauge)
        {
            currentSpecialGauge = 0;
            OnSpecialGaugeChanged?.Invoke(0f);
            UpdateUI();
            return true;
        }
        return false;
    }
    private void UpdateUI()
    {
        playerHPSlider.value = currentHP / maxHP;
    }
}
