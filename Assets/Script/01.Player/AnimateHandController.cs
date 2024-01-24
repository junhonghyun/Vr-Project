using UnityEngine;
using UnityEngine.InputSystem;

namespace Unity_VR_Basics_2023_Hands.Oculus_Hands.Scripts
{
    [RequireComponent(typeof(Animator))]
    public class AnimateHandController : MonoBehaviour
    {
        [SerializeField] private InputActionReference gripInputActionRef;
        [SerializeField] private InputActionReference triggerInputActionRef;

        private Animator _handAnimator;
        private float _gripValue;
        private float _triggerValue;

        private void Awake()
        {
            _handAnimator = GetComponent<Animator>();
        }

        // Update is called once per frame
        private void Update()
        {
            AnimateGrip();
            AnimateTrigger();
        }

        private void AnimateGrip()
        {
            _gripValue = gripInputActionRef.action.ReadValue<float>();
            _handAnimator.SetFloat("Grip", _gripValue);
        }

        private void AnimateTrigger()
        {
            _triggerValue = triggerInputActionRef.action.ReadValue<float>();
            _handAnimator.SetFloat("Trigger", _triggerValue);
        }
    }
}