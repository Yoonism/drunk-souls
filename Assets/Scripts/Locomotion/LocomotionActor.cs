using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

namespace Elite.Locomotion
{
    public class LocomotionActor : MonoBehaviour
    {
        public enum StateType
        {
            Idle,
            Attacking,
            Dodging,
            Stunned
        }

        [System.Serializable]
        public struct StateSet
        {
            public StateType stateType;
            public bool atrCanMove;
            public bool atrCanAttack;
            public bool atrCanRecieve;
            public bool atrCanDodge;
            public bool atrGrounded;
        }


        [SerializeField]
        private RaycastEngine _raycastEngine;
        [SerializeField]
        private TextMeshPro _stateDebugTMP;

        [SerializeField]
        private StateSet[] _stateLibrary;

        public StateSet stateSet;

        private void Start()
        {
            UpdateState(StateType.Idle);
        }

        private void Update()
        {
            if(Input.GetKey(KeyCode.Space))
            {
                stateSet = _stateLibrary[(int)StateType.Stunned];
            }

            UpdateDebugInformation();

            UpdateMovement();
        }

        private void UpdateMovement()
        {
            if(!stateSet.atrCanMove) return;

            _raycastEngine.inputAxis.x = Input.GetAxis("Horizontal");
        }

        private void UpdateDebugInformation()
        {
            _stateDebugTMP.text = stateSet.stateType.ToString();
        }

        private void UpdateState(StateType newState)
        {
            stateSet = _stateLibrary[(int)newState];
        }

        /*
        private void Update()
        {

            _raycastEngine.inputAxis.x = Input.GetAxis("Horizontal");

            if(Input.GetKey(KeyCode.Space)) _raycastEngine.inputAxis.y = 1f;
            else _raycastEngine.inputAxis.y = 0f;

            if(_raycastEngine.GetCurrentGrounded())
            {
                if(Mathf.Abs(_raycastEngine.inputAxis.x) != 0f) _actorState = ActorState.Walking;
                else _actorState = ActorState.Standing;
            }
            else _actorState = ActorState.Air;

            if(_raycastEngine.inputAxis.x < 0f) _spriteContainer.localScale = new Vector3(-0.1f, 1f, 0.1f);//.Set(-1f, 0f, 0f);
            if(_raycastEngine.inputAxis.x > 0f) _spriteContainer.localScale = new Vector3(0.1f, 1f, 0.1f);//.Set(1f, 0f, 0f);

        }
        */
    }
}