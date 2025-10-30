using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerData playerData;
    [SerializeField] private ParticleSystem dashEffect;
    public IPlayerState CurrentState { get; private set; }
    public float HorizontalInput { get; set; }
    public float VerticalInput { get; set; }
    public float MoveSpeed { get; set; }
    public float RunTime { get; set; } = 0;
    public bool IsAttack { get; set; } = false;
    public Animator PlayerAnimator { get ; private set; }
    public PlayerStatus PlayerStatus { get; private set; }

    public PlayerData Data { get => playerData; private set => playerData = value; }
    public Rigidbody PlayerRb { get; private set; }
    public ParticleSystem DashEffect { get => dashEffect; private set => dashEffect = value; }
    public Vector3 LastHitEnemyPos { get; private set; }
    public Collider AttackCollider { get; private set; }
    private void Awake()
    {
        PlayerStatus = GetComponent<PlayerStatus>();
        PlayerStatus.OnDead.AddListener(OnPlayerDead);
    }
    // Start is called before the first frame update
    void Start()
    {
        PlayerRb = GetComponent<Rigidbody>();
        PlayerAnimator = GetComponent<Animator>();
        AttackCollider = gameObject.GetComponentInChildren<SphereCollider>();
        AttackCollider.enabled = false;
        ChangeState(new IdleState());
    }

    // Update is called once per frame
    void Update()
    {
        CurrentState?.Update(this);
    }
    private void FixedUpdate()
    {
        CurrentState?.FixedUpdate(this);
    }
    public void ChangeState(IPlayerState _newState)
    {
        CurrentState?.Exit(this);
        CurrentState = _newState;
        CurrentState?.Enter(this);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            LastHitEnemyPos = other.transform.position;
        }
        if (other.CompareTag("EnemyAttack"))
        {
            LastHitEnemyPos = other.transform.position;

            float _damage = other.gameObject.GetComponent<NoobEnemyStatus>().Attack;
            if(!IsAttack) ChangeState(new  HitState());
            PlayerStatus.TakeDamage(_damage);
        }
    }
    private void OnPlayerDead()
    {
        ChangeState(new PlayerDeadState());
    }
}
