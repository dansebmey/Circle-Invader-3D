﻿using UnityEngine;

public class InvokeEnemyAction : State
{
    public override void OnEnter()
    {
        Gm.enemy.InvokeNextAction();
    }

    public override void OnUpdate()
    {
        
    }

    public override void OnExit()
    {
        
    }
}