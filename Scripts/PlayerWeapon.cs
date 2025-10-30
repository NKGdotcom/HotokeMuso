using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    private Player owner;
    
    // Start is called before the first frame update
    void Start()
    {
        owner = transform.root.gameObject.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        var _enemy = other.GetComponent<NoobEnemy>();
        if(_enemy != null && other is CapsuleCollider)
        {
            if(owner.CurrentState is AttackState attackState)
            {
                attackState.OnHitEnemy(owner, _enemy);
            }
        }
    }
}