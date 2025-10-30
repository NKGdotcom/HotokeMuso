using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoobEnemyKnockbackState : INoobEnemyState
{
    private Vector3 knockDir;
    private float force;
    private float timer;
    private float duration;

    public NoobEnemyKnockbackState(Vector3 _dir)
    {
        Debug.Log("çUåÇÇó^Ç¶ÇΩ");
        knockDir = _dir.normalized;
    }
    public void Enter(NoobEnemy noobEnemy)
    {
        noobEnemy.NoobEnemyRb.velocity = knockDir * force + Vector3.up * 5f + Vector3.forward * 10f;
    }

    public void Update(NoobEnemy noobEnemy)
    {

    }

    public void FixedUpdate(NoobEnemy noobEnemy)
    {
    }

    public void Exit(NoobEnemy noobEnemy)
    {
       
    }
}
