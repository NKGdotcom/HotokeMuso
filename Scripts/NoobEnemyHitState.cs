using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoobEnemyHitState : INoobEnemyState
{
    private float knockbackForce = 5;
    private Vector3 knockbackDirection;
    private float duration;
    private float timer = 0f;
    
    public NoobEnemyHitState(Vector3 _direction)
    {
        this.knockbackDirection = _direction;
    }
    // Start is called before the first frame update
    public void Enter(NoobEnemy noobEnemy)
    {
        Debug.Log("UŒ‚‚ð—^‚¦‚½");
        noobEnemy.NoobEnemyRb.velocity = knockbackForce * knockbackDirection;
    }
    public void Update(NoobEnemy noobEnemy)
    {

    }
    public void FixedUpdate(NoobEnemy noobEnemy)
    {
        timer += Time.deltaTime;

        // ™X‚É‘¬“x‚ðŒ¸Š‚³‚¹‚é
        noobEnemy.NoobEnemyRb.velocity = Vector3.Lerp(
            noobEnemy.NoobEnemyRb.velocity,
            Vector3.zero,
            Time.deltaTime * 5f
        );

        if (timer >= duration)
        {
            noobEnemy.ChangeState(new NoobEnemyIdleState());
        }
    }

    public void Exit(NoobEnemy noobEnemy)
    {
        noobEnemy.NoobEnemyRb.velocity = Vector3.zero;
    }
}
