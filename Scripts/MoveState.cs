using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MoveState : IPlayerState
{
    [SerializeField] private ParticleSystem dashEffect;
    private float inputThreshols = 0.1f; //閾値
    private bool setDashEffect;
    public void Enter(Player player)
    {
        setDashEffect = false;
        player.MoveSpeed = player.Data.PlayerMoveSpeed;
    }

    // Update is called once per frame
    public void Update(Player player)
    {
        player.HorizontalInput = Input.GetAxis("Horizontal");
        player.VerticalInput = Input.GetAxis("Vertical");

        // 入力がなくなったらIdleへ
        if (player.HorizontalInput == 0 && player.VerticalInput == 0)
        {
            player.ChangeState(new IdleState());
        }

        player.RunTime += Time.deltaTime;
        if (player.RunTime > player.Data.PlayerDashInterval) //ダッシュ
        {
            player.MoveSpeed = player.Data.PlayerDashMoveSpeed;
            ShowDashEffect(player);
        }

        if (Input.GetMouseButtonDown(0))
        {
            player.ChangeState(new AttackState());
        }
    }

    public void FixedUpdate(Player player)
    {
        Quaternion _horizontalRot = Quaternion.AngleAxis(Camera.main.transform.eulerAngles.y, Vector3.up);
        Vector3 _inputDirection = _horizontalRot * new Vector3(player.HorizontalInput, 0f, player.VerticalInput).normalized;

        if (_inputDirection.magnitude > inputThreshols)
        {
            Quaternion _targetRotation = Quaternion.LookRotation(_inputDirection, Vector3.up);
            player.transform.rotation = Quaternion.Slerp(
                 player.transform.rotation,
                 _targetRotation,
                 Time.deltaTime * player.Data.PlayerMoveRotateSpeed
             );

            Vector3 _moveDirection = _inputDirection * player.MoveSpeed;
            player.PlayerRb.MovePosition(player.transform.position + _moveDirection * Time.deltaTime);
        }
    }
    private void ShowDashEffect(Player player)
    {
        if (setDashEffect) return;
        setDashEffect = true;
        player.DashEffect.Play();
    }

    public void Exit(Player player) { }
}