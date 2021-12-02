using UnityEngine;
using UnityEngine.Events;

public abstract class InputFacade : MonoBehaviour
{
    public UnityEvent OnForward;
    public UnityEvent OnBack;
    public UnityEvent OnLeft;
    public UnityEvent OnRight;
    public UnityEvent OnFire;
    public UnityEvent OnPreviousWeapon;
    public UnityEvent OnNextWeapon;
}