using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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
        private StateSet[] _stateLibrary;

        public StateSet stateSet;

        /*
        public StateType stateType;
        public bool atrCanMove;
        public bool atrCanAttack;
        public bool atrCanRecieve;
        public bool atrCanDodge;
        public bool atrGrounded;
        */

        private void Start()
        {
            UpdateState(_stateLibrary[(int)StateType.Idle]);
        }

        private void UpdateState(StateSet newStateSet)
        {
            stateSet = newStateSet;
        }

        private void Update()
        {
            /*
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
            */
        }
    }
}