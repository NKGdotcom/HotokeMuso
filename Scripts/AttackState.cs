using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AttackState : IPlayerState
{
    private enum AttackMove { x1, x2, x3, x4, y1, y2, y3, y4, y5 }
    private AttackMove attackMove;
    private Collider attackCollider;
    private float attackTime = 0f;
    private float attackDuration = 1.5f;

    private int attackCount = 1;

    private bool finishAttack;
    private bool nextComboQueued = false;
    private bool nextChargeComboQueued = false;

    public void Enter(Player player)
    {
        finishAttack = false;
        attackCount = 1;
        attackTime = 0f;
        player.MoveSpeed = player.Data.PlayerAttackMoveSpeed;
        player.IsAttack = true;
        Y1Attack(player);

        attackCollider = player.AttackCollider;
        attackCollider.enabled = true;
    }

    public void Update(Player player)
    {
        var _stateInfo = player.PlayerAnimator.GetCurrentAnimatorStateInfo(0);
        float _progress = _stateInfo.normalizedTime % 1f;
        bool _isTransitioning = player.PlayerAnimator.IsInTransition(0);
        if (_stateInfo.IsTag("Attack"))
        {
            // É{É^ÉìÇâüÇµÇΩÇÁÅuó\ñÒÅvÇæÇØÇ∑ÇÈ
            if (Input.GetMouseButtonDown(0) && !finishAttack)
            {
                nextComboQueued = true;
            }
            if (Input.GetMouseButtonDown(1) && !finishAttack)
            {
                nextChargeComboQueued = true;
            }
            if (_progress >= 0.7f)
            {
                if (nextChargeComboQueued)
                {
                    nextChargeComboQueued = false;
                    XAttack(player);
                }
                else if (nextComboQueued)
                {
                    nextComboQueued = false;
                    YAttack(player);
                }
            }
            // çUåÇÇ™èIóπ & ëJà⁄íÜÇ≈Ç»Ç¢Ç»ÇÁIdleÇ÷
            if (_progress >= 0.98f && !_isTransitioning && !nextComboQueued && !nextChargeComboQueued)
            {
                player.ChangeState(new IdleState());
            }
        }
    }
    public void FixedUpdate(Player player)
    {
        Vector3 _inputDirection = new Vector3(player.HorizontalInput, 0f, player.VerticalInput);

        if (_inputDirection.sqrMagnitude > 0.0001f)
        {
            _inputDirection.Normalize();

            Quaternion _targetRotation = Quaternion.LookRotation(_inputDirection, Vector3.up);
            player.transform.rotation = Quaternion.Slerp(
                player.transform.rotation,
                _targetRotation,
                Time.deltaTime * player.Data.PlayerAttackRotateSpeed
            );
        }

        Vector3 _moveDirection = _inputDirection.normalized * player.MoveSpeed;
        player.PlayerRb.MovePosition(player.transform.position + _moveDirection * Time.deltaTime);
    }
    private void YAttack(Player player)
    {
        if (attackMove == AttackMove.y1) Y2Attack(player);
        else if (attackMove == AttackMove.y2) Y3Attack(player);
        else if (attackMove == AttackMove.y3) Y4Attack(player);
        else if (attackMove == AttackMove.y4) Y5Attack(player);
    }
    private void Y1Attack(Player player)
    {
        player.PlayerAnimator.SetInteger("Y", attackCount);
        attackMove = AttackMove.y1;
    }
    private void Y2Attack(Player player)
    {
        attackCount++;
        player.PlayerAnimator.SetInteger("Y", attackCount);
        attackMove = AttackMove.y2;
    }
    private void Y3Attack(Player player)
    {
        attackCount++;
        player.PlayerAnimator.SetInteger("Y", attackCount);
        attackMove = AttackMove.y3;
    }
    private void Y4Attack(Player player)
    {
        attackCount++;
        player.PlayerAnimator.SetInteger("Y", attackCount);
        attackMove = AttackMove.y4;
    }
    private void Y5Attack(Player player)
    {
        attackCount++;
        player.PlayerAnimator.SetInteger("Y", attackCount);
        attackMove = AttackMove.y5;
        finishAttack = true;
    }
    private void XAttack(Player player)
    {
        player.PlayerAnimator.SetTrigger("X");
        if (attackMove == AttackMove.y1) X1Attack(player);
        else if (attackMove == AttackMove.y2) X2Attack(player);
        else if (attackMove == AttackMove.y3) X3Attack(player);
        else if (attackMove == AttackMove.y4) X4Attack(player);
    }
    private void X1Attack(Player player)
    {
        attackMove = AttackMove.x1;
        finishAttack = true;
    }
    private void X2Attack(Player player)
    {
        attackMove = AttackMove.x2;
        finishAttack = true;
    }
    private void X3Attack(Player player)
    {
        attackMove = AttackMove.x3;
        finishAttack = true;
    }
    private void X4Attack(Player player)
    {
        attackMove = AttackMove.x4;
        finishAttack = true;
    }

    public void Exit(Player player)
    {
        player.IsAttack = false;

        finishAttack = false;
        attackTime = 0f;

        // AnimatorÉäÉZÉbÉg
        player.PlayerAnimator.ResetTrigger("X");
        player.PlayerAnimator.ResetTrigger("FinishAttack");
        player.PlayerAnimator.SetInteger("Y", 0);

        // çUåÇèIóπÉgÉäÉKÅ[
        player.PlayerAnimator.SetTrigger("FinishAttack");

        attackMove = AttackMove.y1;
        attackCount = 0;

        attackCollider.enabled = false;
    }

    public void OnHitEnemy(Player player, NoobEnemy enemy)
    {
        Debug.Log("çUåÇÇµÇΩ");
        Vector3 _dir = (enemy.transform.position - player.transform.position).normalized;

        // ç≈èIíi or XçUåÇÇ»ÇÁêÅÇ´îÚÇŒÇµ
        if (attackMove == AttackMove.y5 || attackMove == AttackMove.x1 ||
            attackMove == AttackMove.x2 || attackMove == AttackMove.x3 ||
            attackMove == AttackMove.x4)
        {
            enemy.ChangeState(new NoobEnemyKnockbackState(_dir));
        }
        else if(enemy.IsGround)
        {
            enemy.ChangeState(new NoobEnemyFlinchState(_dir));
            enemy.TakeDamage(player.Data.PlayerAttackStatus);
        }
        else if (!enemy.IsGround)
        {
            enemy.ChangeState(new NoobEnemyAirHitState(_dir));
        }
    }
}