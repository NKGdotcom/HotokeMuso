using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAppears : MonoBehaviour
{
    [SerializeField] private NoobEnemy[] noobEnemyList;
    private Collider appearCollider;

    private float appearInterval = 0.01f;
    private float hiddenInterval = 0.01f;
    private bool inPlayer = false;
    private bool isAppearing = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!inPlayer && other.gameObject.TryGetComponent(out Player _player))
        {
            inPlayer = true;
            if (!isAppearing)
            {
                EnemyAppear();
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (inPlayer && other.gameObject.TryGetComponent(out Player _player))
        {
            inPlayer = false;

            EnemyHidden(); 
        }
    }

    /// <summary>
    /// 範囲内に味方が入ってきたとき、敵を出現させる
    /// </summary>
    private void EnemyAppear()
    {
        isAppearing = true;
        foreach (var noobEnemy in noobEnemyList)
        {
            if (!inPlayer) break;

            noobEnemy.gameObject.SetActive(true);
        }
    }
    /// <summary>
    /// 範囲内に味方がいなくなった場合、敵を消す。
    /// </summary>
    private void EnemyHidden()
    {
        isAppearing = false;
        foreach (var noobEnemy in noobEnemyList)
        {
            if (inPlayer) break;

            noobEnemy.gameObject.SetActive(false);
           
        }
    }
}
