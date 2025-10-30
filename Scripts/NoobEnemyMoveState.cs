using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class NoobEnemyMoveState : INoobEnemyState
{
    private float moveFinishTime = 0.5f;
    private float moveTime;
    private Vector3 dir;
    private float randomX;
    private float randomZ;
    public void Enter(NoobEnemy noobEnemy)
    {
        moveTime = 0;
        randomX = Random.Range(-1f, 1f);
        randomZ = Random.Range(-1f, 1f);
        dir = new Vector3(randomX, 0, randomZ);

        noobEnemy.gameObject.transform.rotation = Quaternion.LookRotation(dir, Vector3.up);
    }
    public void Update(NoobEnemy noobEnemy) 
    {
        moveTime += Time.deltaTime;
        noobEnemy.NoobEnemyRb.MovePosition(noobEnemy.transform.position + dir * Time.deltaTime * noobEnemy.MoveSpeed);
        if (moveTime > moveFinishTime)
        {
            noobEnemy.ChangeState(new NoobEnemyIdleState());
        }
    }

    public void FixedUpdate(NoobEnemy noobEnemy) { }

    public void Exit(NoobEnemy noobEnemy) { }
}
