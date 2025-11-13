using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ステージの一連の過程を作成
/// </summary>
public class StageFlow : MonoBehaviour
{
    [SerializeField] private Serif[] serifLists;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
public class Serif
{
    public Text Comment { get => comment;}
    public Image Speaker { get => speaker; }
    [SerializeField] private Text comment;
    [SerializeField] private Image speaker;
}


