using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface INoobEnemyState
{
    void Enter(NoobEnemy noobEnemy);
    void Update(NoobEnemy noobEnemy);
    void FixedUpdate(NoobEnemy noobEnemy);
    void Exit(NoobEnemy noobEnemy);
}
