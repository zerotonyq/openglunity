using Zenject;

namespace Input
{
    public class InputActionsManager
    {
        public PlayerInputActions PlayerInputActions { get; private set; }

        [Inject]
        public InputActionsManager()
        {
            PlayerInputActions = new PlayerInputActions();
            PlayerInputActions.Enable();
        }
    }
}