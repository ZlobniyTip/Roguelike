using UnityEngine;

public class HeroAnimator : MonoBehaviour
{
    private static readonly int MoveHash = Animator.StringToHash("Speed");
    private static readonly int IdleHash = Animator.StringToHash("Idle");

    [SerializeField] private Animator _animator;
    [SerializeField] private CharacterController _controller;

    private void Update()
    {
        _animator.SetFloat(MoveHash, _controller.velocity.magnitude, 0.1f, Time.deltaTime);
    }

    private void SetAnimation()
    {

    }
}
