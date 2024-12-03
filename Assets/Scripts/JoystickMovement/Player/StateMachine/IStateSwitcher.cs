using Assets.Scripts.JoystickMovement.Player.StateMachine.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.JoystickMovement.Player.StateMachine
{
    public interface IStateSwitcher
    {
        void SwitcherState<T>() where T : MovementState;
    }
}