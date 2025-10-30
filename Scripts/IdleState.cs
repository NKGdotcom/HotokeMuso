using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class IdleState : IPlayerState
{
    public void Enter(Player player)
    {
        player.MoveSpeed = player.Data.PlayerMoveSpeed;
        player.RunTime = 0f;
    }

    public void Update(Player player)
    {
        player.HorizontalInput = Input.GetAxis("Horizontal");
        player.VerticalInput = Input.GetAxis("Vertical");

        // “ü—Í‚ª‚ ‚ê‚ÎˆÚ“®‚Ö
        if (player.HorizontalInput != 0 || player.VerticalInput != 0)
        {
            player.ChangeState(new MoveState());
        }

        if (Input.GetMouseButtonDown(0))
        {
            player.ChangeState(new AttackState());
        }
    }

    public void FixedUpdate(Player player) { }

    public void Exit(Player player) { }
}
