using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoobEnemy : MonoBehaviour
{
    public INoobEnemyState CurrentState{ get; private set; }
    private NoobEnemyStatus noobEnemyStatus;
    private Rigidbody noobEnemyRb;
    private bool damage = false;
    public bool FoundPlayer { get; private set; } = false;
    public GameObject Player { get ; private set; }
    public float MoveSpeed { get => moveSpeed; private set => moveSpeed = value; }
    public Rigidbody NoobEnemyRb { get => noobEnemyRb; private set => noobEnemyRb = value;}
    public bool Damage { get => damage; private set => damage = value;}
    public bool IsGround { get; private set; } = true;
    [SerializeField] private float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        noobEnemyRb = GetComponent<Rigidbody>();
        noobEnemyStatus = GetComponent<NoobEnemyStatus>();
        ChangeState(new NoobEnemyIdleState());
    }

    void Update()
    {
        CurrentState?.Update(this);
    }
    private void FixedUpdate()
    {
        CurrentState?.FixedUpdate(this);
    }
    public void TakeDamage(float _damage)
    {
        noobEnemyStatus.TakeDamage(_damage);
    }
    public void ChangeState(INoobEnemyState _newState)
    {
        if (CurrentState is NoobEnemyHitState) return;
        CurrentState?.Exit(this);
        CurrentState = _newState;
        CurrentState?.Enter(this);
    }

    public void BeKnockedBack(Vector3 _force)
    {
        CurrentState?.Exit(this);
        CurrentState = new NoobEnemyFlinchState(_force);
        CurrentState?.Enter(this);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            damage = true;
            BeKnockedBack(collision.transform.position);
        }
        if (collision.gameObject.CompareTag("Ground"))
        {
            IsGround = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            IsGround = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            FoundPlayer = true;
            Player = other.gameObject;
            ChangeState(new NoobEnemyRangeState());
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            FoundPlayer = false;
            ChangeState(new NoobEnemyIdleState());
        }
    }
}
