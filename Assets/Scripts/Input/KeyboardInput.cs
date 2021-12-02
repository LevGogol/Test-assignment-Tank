using UnityEngine;

public class KeyboardInput : InputFacade
{
    private void Update()
    {
        if (Input.GetKey(KeyCode.W)) OnForward.Invoke();
        if (Input.GetKey(KeyCode.S)) OnBack.Invoke();
        if (Input.GetKey(KeyCode.A)) OnLeft.Invoke();
        if (Input.GetKey(KeyCode.D)) OnRight.Invoke();
        if (Input.GetKeyDown(KeyCode.X)) OnFire.Invoke();
        if (Input.GetKeyDown(KeyCode.Q)) OnPreviousWeapon.Invoke();
        if (Input.GetKeyDown(KeyCode.E)) OnNextWeapon.Invoke();
    }
}