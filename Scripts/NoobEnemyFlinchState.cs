using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using UnityEngine;

public class NoobEnemyFlinchState : INoobEnemyState
{
    private Vector3 knockDir;
    private float force = 5;
    private float duration;
    private float timer;

    public NoobEnemyFlinchState(Vector3 _dir)
    {
        knockDir = _dir.normalized;
    }
    // Start is called before the first frame update
    public void Enter(NoobEnemy noobEnemy)
    {
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
