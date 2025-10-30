using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoobEnemyUI : MonoBehaviour
{
    private GameObject noobEnemy;
    private Slider hpSlider;
    private NoobEnemyStatus enemyStatus;
    // Start is called before the first frame update
    void Start()
    {
        noobEnemy = transform.root.gameObject;
        hpSlider = GetComponent<Slider>();
        enemyStatus = noobEnemy.GetComponent<NoobEnemyStatus>();

        enemyStatus.OnHPChanged.AddListener(UpdateHPBar);
        UpdateHPBar(enemyStatus.CurrentHP / enemyStatus.MaxHP);
    }
    private void Update()
    {
        transform.rotation = Camera.main.transform.rotation;
    }

    private void UpdateHPBar(float _normalized)
    {
        hpSlider.value = _normalized;
    }
}
