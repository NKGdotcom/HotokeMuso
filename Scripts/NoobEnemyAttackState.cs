using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class NoobEnemyAttackState : INoobEnemyState
{
    private float time;
    private float attackWaitTime;
    private float delayTime = 2;
    private bool attack;
    public void Enter(NoobEnemy noobEnemy)
    {
        time = 0;
        attackWaitTime = Random.Range(2f, 7f);
        attack = false;
    }
    public void Update(NoobEnemy noobEnemy)
    {
        time += Time.deltaTime;
        if (time > attackWaitTime)
        {
            if (!attack)
            {
                attack = true;
                Debug.Log("UŒ‚‚µ‚Ü‚µ‚½");
            }
            //UŒ‚ƒAƒjƒ[ƒVƒ‡ƒ“
            if(time > delayTime + attackWaitTime)
            {
                if (noobEnemy.FoundPlayer) noobEnemy.ChangeState(new NoobEnemyRangeState());
                else noobEnemy.ChangeState(new NoobEnemyIdleState());
            }
        }
        if(!attack)
        {
            Vector3 _dir = noobEnemy.transform.position - noobEnemy.Player.transform.position;
            noobEnemy.transform.rotation = Quaternion.LookRotation(_dir, Vector3.up);
        }
    }
    public void FixedUpdate(NoobEnemy noobEnemy) 
    {
        if (!noobEnemy.FoundPlayer) noobEnemy.ChangeState(new NoobEnemyMoveState()); 
    }

    public void Exit(NoobEnemy noobEnemy) { }
}
