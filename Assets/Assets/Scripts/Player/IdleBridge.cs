using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace KinematicCharacterController.Examples
{
    public class IdleBridge : MonoBehaviour
    {
        //StateManager states;
        ExampleCharacterController bridge;
        PlayerStats deathBridge;
        
        private void Start()
        {
            //states = GetComponentInParent<StateManager>();
            bridge = GetComponentInParent<ExampleCharacterController>();
            deathBridge = GetComponentInParent<PlayerStats>();
        }

        public void IdlePlusBridge()
        {
            //states.FinishIdle();
            bridge.FinishIdle();
        }

        public void SandDeadBridge()
        {
            deathBridge.TryToDie();
        }
    }

}