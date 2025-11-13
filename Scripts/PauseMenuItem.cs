using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenuItem : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI selectTMP;
    [SerializeField] private Image selectUnderline;

    [SerializeField] private Canvas submenuCanvas;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /// <summary>
    /// 選択中
    /// </summary>
    public void SelectUI()
    {
        selectTMP.gameObject.SetActive(true);
        selectUnderline.gameObject.SetActive(true);
    }
    /// <summary>
    /// 選択から外す
    /// </summary>
    public void DeselectUI()
    {
        selectTMP.gameObject.SetActive(false);
        selectUnderline.gameObject.SetActive(false);
    }
    /// <summary>
    /// メニューを開く
    /// </summary>
    public void OpenSubMenu()
    {
        if (submenuCanvas != null) submenuCanvas.gameObject.SetActive(true);
    }
}
