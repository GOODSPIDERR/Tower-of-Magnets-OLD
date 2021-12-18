using UnityEditor;
using UnityEngine;

public class PlayerAirState : PlayerBaseState
{
    public override void EnterState(PlayerMovement player)
    {

    }
    public override void UpdateState(PlayerMovement player)
    {
        Debug.Log("YOU ARE IN AIR STATE");
    }
    public override void FixedUpdateState(PlayerMovement player)
    {
        
    }
}
