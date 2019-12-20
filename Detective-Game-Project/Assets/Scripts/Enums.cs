namespace Scripts
{
    public enum ActivePlayer
    {
        Human,
        Animal,
        Both
    }

    public enum GameType
    {
        SinglePlayer,
        MultiPlayer,
        MultiPlayerSplitScreen
    }

    public enum InteractableType
    {
        Normal,
        ItemNeeded,
        Pickup,
        HoldButton,
        Movable,
        EndLevel,
        DEBUG, // Interacting with a DEBUG spawns an item without destroying root item
        STATECHANGER // Interacting with a STATECHANGER only changes a state
    }

    public enum ButtonPress
    {
        Down,
        Hold
    }

    public enum AxisType
    {
        Axis,
        AxisRaw
    }

    public enum SequencePuzzleStatus
    {
        Correct,
        Incomplete,
        Wrong
    }

    public enum Direction
    {
        XPlus,
        XMinus,
        YPlus,
        YMinus,
        ZPlus,
        ZMinus,
    }

    public enum SolutionType
    {
        Destroy
    }

    public enum InputType
    {
        Keyboard,
        Controller
    }

    public enum InteractState
    {
        DEACTIVATED,
        ACTIVATED
    }
}
