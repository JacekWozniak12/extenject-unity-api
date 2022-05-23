using UnityEngine;
using Zenject;

public abstract class Controller : IInitializable
{
    public abstract void Initialize();
}