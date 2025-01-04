
public interface IStateSwitcher
{
    void SwitcherState<T>() where T : MovementState;
}