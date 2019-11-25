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
        Unlockable,
        Pickup,
        Movable
    }

    public enum ButtonPress
    {
        Down,
        Up,
        Press
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
}