using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerState
{
    void Enter(Player player);
    void Update(Player player);
    void FixedUpdate(Player player);
    void Exit(Player player);
}
