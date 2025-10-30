using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NoobEnemyStatus : MonoBehaviour
{
    public float Attack { get => attack; private set => attack = value; }
    [Header("敵ステータス")]
    [SerializeField] private float maxHP;
    [SerializeField] private float attack = 10;
    private float currentHP;
    private NoobEnemy noobEnemy;

    public float MaxHP { get => maxHP; private set => maxHP = value; }
    public float CurrentHP { get => currentHP; set => currentHP = value; }

    [Header("イベント")]
    public UnityEvent OnDead;
    public UnityEvent<float> OnHPChanged;

    // Start is called before the first frame update
    void Start()
    {
        noobEnemy = GetComponent<NoobEnemy>();
        currentHP = maxHP;
        OnHPChanged?.Invoke(currentHP / maxHP);
    }

    public void TakeDamage(float _damage)
    {
        Debug.Log(_damage);
        currentHP -= _damage;
        currentHP = Mathf.Clamp(currentHP, 0, maxHP);

        OnHPChanged?.Invoke(currentHP / maxHP);

        if(currentHP > 0)
        {
            if (noobEnemy != null)
            {
                //noobEnemy.BeKnockedBack(knockbackForce);
            }
        }
        else
        {
            Dead();
        }
    }
    private void Dead()
    {
        OnDead?.Invoke();
    }
}
