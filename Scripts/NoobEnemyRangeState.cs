using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoobEnemyRangeState : INoobEnemyState
{
    private float chaseMoveSpeed = 0.1f;
    private float approachDistance = 5;
    private float dis;

    public void Enter(NoobEnemy noobEnemy)
    {
        Debug.Log("UŒ‚”»’èˆÊ’u‚É“ü‚è‚Ü‚µ‚½");
    }
    public void Update(NoobEnemy noobEnemy) 
    {
        dis = Vector3.Distance(noobEnemy.Player.transform.position, noobEnemy.transform.position);
        if (dis > approachDistance)
        {
            Vector3 _dir = noobEnemy.Player.transform.position - noobEnemy.transform.position;
            dis = Vector3.Distance(noobEnemy.Player.transform.position, noobEnemy.transform.position);
            noobEnemy.NoobEnemyRb.MovePosition(noobEnemy.transform.position + _dir * Time.deltaTime * chaseMoveSpeed);
            noobEnemy.transform.rotation = Quaternion.LookRotation(-(_dir), Vector3.up);
        }
        else
        {
            noobEnemy.ChangeState(new NoobEnemyAttackState());
        }
    }

    public void FixedUpdate(NoobEnemy noobEnemy) { }

    public void Exit(NoobEnemy noobEnemy) { }
}
