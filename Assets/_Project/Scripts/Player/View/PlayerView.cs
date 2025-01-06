using UnityEngine;

[RequireComponent(typeof(SpriteRenderer), typeof(Animator))]
public class PlayerView : MonoBehaviour
{
    private const string IsRun = "IsRun";
    private const string IsIdle = "IsIdle";
    private const string Hit = "Hit";

    private SpriteRenderer _spriteRenderer;
    private Animator _animator;
    
    public SpriteRenderer SpriteRenderer => _spriteRenderer;
    public Animator Animator => _animator;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Initialize() => _animator = GetComponent<Animator>();   
    
    public void StartRuning() => _animator.SetBool(IsRun, true);
    public void StopRuning() => _animator.SetBool(IsRun, false);

    public void StartIdle() => _animator.SetBool(IsIdle, true);
    public void StopIdle() => _animator.SetBool(IsIdle, false);

    public void PlayHit() => _animator.Play(Hit);
}