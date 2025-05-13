using UnityEngine;

namespace Assets.Scripts.Services.Input
{
    public abstract class InputService : IInputService
    {
        protected const string Horizontal = "Horizontal";
        protected const string Vertical = "Vertical";
        protected const string Button = "Attack";

        public abstract Vector2 Axis { get; }

        public bool IsAttackButtonUp =>
            SimpleInput.GetButtonUp(Button);

        protected static Vector2 SimpleInputAxis()
        {
            return new Vector2(SimpleInput.GetAxis(Horizontal), SimpleInput.GetAxis(Vertical));
        }

        public bool AttackButtonUp()
        {
            return SimpleInput.GetButtonUp(Button);
        }
    }
}