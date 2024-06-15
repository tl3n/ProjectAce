using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public interface IPlayerState
{
    void EnterState(MovementStateMachine player);
    void UpdateState(MovementStateMachine player);
    void ExitState(MovementStateMachine player);
}

