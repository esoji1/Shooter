using UnityEngine;

public class MagicianView : MonoBehaviour
{
    private const string IsRun = "IsRun";
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

    public void StartWalk() => _animator.SetBool(IsRun, true);
    public void StopWalk() => _animator.SetBool(IsRun, false);

    public void StartAttack() => _animator.SetBool(IsAttack, true);
    public void StopAttack() => _animator.SetBool(IsAttack, false);

    public void PlayDie() => _animator.Play(Die);
}