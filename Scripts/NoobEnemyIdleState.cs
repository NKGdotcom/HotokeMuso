using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoobEnemyIdleState : INoobEnemyState
{
    //基本はIdle状態
    //数秒ごとに
    private float time;
    private float idleTime = 4;
    public void Enter(NoobEnemy noobEnemy)
    {
        time = 0;
       //アニメーション
    }
    public void Update(NoobEnemy noobEnemy) 
    {
        time += Time.deltaTime;
        if(time > idleTime)
        {
            noobEnemy.ChangeState(new NoobEnemyMoveState());
        }
    }

    public void FixedUpdate(NoobEnemy noobEnemy) { }

    public void Exit(NoobEnemy noobEnemy) { }
    
}
