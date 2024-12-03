using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]
public class PlayerView : MonoBehaviour
{
    private const string RunUp = "RunUp";
    private const string RunDown = "RunDown";
    private const string RunLeft = "RunLeft";
    private const string RunRigth = "RunRight";

    private const string IdleUp = "IdleUp";
    private const string IdleDown = "IdleDown";
    private const string IdleLeft = "IdleLeft";
    private const string IdleRight = "IdleRight";

    private SpriteRenderer _playerView;
    private Animator _animator;
    
    public SpriteRenderer GetPlayerView => _playerView;
    public Animator GetAnimator => _animator;

    private void Start()
    {
        _playerView = GetComponent<SpriteRenderer>();
    }

    public void Initialize() => _animator = GetComponent<Animator>();   
    
    public void StartRunUp() => _animator.SetBool(RunUp, true);
    public void StopRunUp() => _animator.SetBool(RunUp, false);

    public void StartRunDown() => _animator.SetBool(RunDown, true);
    public void StopRunDown() => _animator.SetBool(RunDown, false);

    public void StartRunLeft() => _animator.SetBool(RunLeft, true);
    public void StopRunLeft() => _animator.SetBool(RunLeft, false);

    public void StartRunRigth() => _animator.SetBool(RunRigth, true);
    public void StopRunRigth() => _animator.SetBool(RunRigth, false);

    public void StartIdleUp() => _animator.SetBool(IdleUp, true);
    public void StopIdleUp() => _animator.SetBool(IdleUp, false);

    public void StartIdleDown() => _animator.SetBool(IdleDown, true);
    public void StopIdleDown() => _animator.SetBool(IdleDown, false);

    public void StartIdleLeft() => _animator.SetBool(IdleLeft, true);
    public void StopIdleLeft() => _animator.SetBool(IdleLeft, false);

    public void StartIdleRight() => _animator.SetBool(IdleRight, true);
    public void StopIdleRight() => _animator.SetBool(IdleRight, false);

    public void StopAllAnimations()
    {
        StopRunRigth();
        StopRunLeft();
        StopRunUp();
        StopRunDown();

        StopIdleUp();
        StopIdleDown();
        StopIdleLeft();
        StopIdleRight();
    }
}