using UnityEngine;

public class OrcView : MonoBehaviour
{
    private const string IsWalk = "IsWalk";
    private const string IsAttack = "IsAttack";
    private const string Die = "Die";

    private SpriteRenderer _spriteRenderer;
    private Animator _animator;

    public SpriteRenderer SpriteRenderer => _spriteRenderer;
    public Animator Animator => _animator;

    public void Initialize()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }

    public void StartWalk() => _animator.SetBool(IsWalk, true);
    public void StopWalk() => _animator.SetBool(IsWalk, false);

    public void StartAttack() => _animator.SetBool(IsAttack, true);
    public void StopAttack() => _animator.SetBool(IsAttack, false);

    public void PlayDie() => _animator.Play(Die);
}
