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
    [Header("�v���C���[�̒ʏ�ړ��X�s�[�h")]
    [SerializeField] private float playerMoveSpeed;
    [Header("�v���C���[�̃_�b�V���Ɉڂ鎞��")]
    [SerializeField] private float playerDashInterval;
    [Header("�v���C���[�̃_�b�V���X�s�[�h")]
    [SerializeField] private float playerDashMoveSpeed;
    [Header("�U�����̈ړ��X�s�[�h")]
    [SerializeField] private float playerAttackMoveSpeed;
    [Header("�ʏ�̉�]�X�s�[�h")]
    [SerializeField] private float playerMoveRotateSpeed;
    [Header("�U�����̉�]�X�s�[�h")]
    [SerializeField] private float playerAttackRotateSpeed;
    [Header("�v���C���[�̍U����")]
    [SerializeField] private float playerAttackStatus;
}
