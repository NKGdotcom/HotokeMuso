using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private Slider hpSlider;
    [SerializeField] private Slider specialSlider;
    [SerializeField] private PlayerStatus playerStatus;

    // Start is called before the first frame update
    void Start()
    {
        playerStatus.OnHPChanged.AddListener(UpdateHP);
        playerStatus.OnSpecialGaugeChanged.AddListener(UpdateSpecial);
    }
    private void UpdateHP(float _normalized)
    {
        hpSlider.value = _normalized;
    }
    private void UpdateSpecial(float _normalized)
    {
        specialSlider.value = _normalized;
    }
}
