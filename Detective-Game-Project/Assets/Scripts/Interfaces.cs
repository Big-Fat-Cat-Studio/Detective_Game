using System.Collections;
using System.Collections.Generic;

namespace Scripts
{
    public interface IButtonTarget
    {
        void Activate();
    }
    public interface IInteractable
    {
        void InRange();
        void OutRange();
    }
    public interface IPuzzleManager
    {
        void CompletePuzzle();
    }
    public interface IPuzzleResult
    {
        void ActivateSolution();
    }
    public interface IActivateWithPiss
    {
        void Activation();
    }
    public interface ISkipable
    {
        void Skip();
    }
}