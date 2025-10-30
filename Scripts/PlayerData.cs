using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName ="ScriptableObjects/Player/PlayerData")]
public class PlayerData : ScriptableObject
{
    public float PlayerMoveSpeed { get => playerMoveSpeed; set => playerMoveSpeed = value; }
    public float PlayerDashInterval { get => playerDashInterval; private set => playerDashInterval = value; }
    public float PlayerDashMoveSpeed { get => playerDashMoveSpeed; set => playerDashMoveSpeed = value;}
    public float PlayerAttackMoveSpeed { get => playerAttackMoveSpeed; private set => playerAttackMoveSpeed = value;}
    public float PlayerMoveRotateSpeed { get => playerMoveRotateSpeed; private set => playerMoveRotateSpeed = value; }
    public float PlayerAttackRotateSpeed { get => playerAttackRotateSpeed; private set => playerAttackRotateSpeed = value;}
    public float PlayerAttackStatus { get => playerAttackStatus; private set => playerAttackStatus = value; }
    [Header("プレイヤーの通常移動スピード")]
    [SerializeField] private float playerMoveSpeed;
    [Header("プレイヤーのダッシュに移る時間")]
    [SerializeField] private float playerDashInterval;
    [Header("プレイヤーのダッシュスピード")]
    [SerializeField] private float playerDashMoveSpeed;
    [Header("攻撃中の移動スピード")]
    [SerializeField] private float playerAttackMoveSpeed;
    [Header("通常の回転スピード")]
    [SerializeField] private float playerMoveRotateSpeed;
    [Header("攻撃中の回転スピード")]
    [SerializeField] private float playerAttackRotateSpeed;
    [Header("プレイヤーの攻撃力")]
    [SerializeField] private float playerAttackStatus;
}
