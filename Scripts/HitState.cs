using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitState : IPlayerState
{
    private float hitTime;
    private float hitDuration = 0.4f;
    private Vector3 knockbackForce; //吹き飛ばす力を保持
    private bool knockbackApplied = false;
    // Start is called before the first frame update
    public void Enter(Player player)
    {
        hitTime = 0f;
        knockbackApplied = false;
        //hitアニメーション

        player.PlayerRb.velocity = Vector3.zero;
        player.MoveSpeed = 0f;
    }

    // Update is called once per frame
    public void Update(Player player)
    {
        hitTime += Time.deltaTime;

        if(hitTime >= hitDuration)
        {
            player.ChangeState(new IdleState());
        }
    }
    public void FixedUpdate(Player player)
    {
    }
    public void Exit(Player player) 
    {
        
    }
}
