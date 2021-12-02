using LevGogol.GameCore.Tanks;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private InputFacade _input;
    [SerializeField] private Tank _tank;

    public void Start()
    {
        StartLevel();
    }

    public void StartLevel()
    {
        _tank.OnDead.AddListener(StopLevel);
        
        BindInputToTank();
    }

    public void StopLevel()
    {
        UnBindInputPlayer();
    }

    private void BindInputToTank()
    {
        _input.OnForward.AddListener(_tank.Movement.MoveForward);
        _input.OnBack.AddListener(_tank.Movement.MoveBack);
        _input.OnLeft.AddListener(_tank.Movement.RotateLeft);
        _input.OnRight.AddListener(_tank.Movement.RotateRight);
        _input.OnFire.AddListener(_tank.TryShoot);
        _input.OnNextWeapon.AddListener(_tank.NextWeapon);
        _input.OnPreviousWeapon.AddListener(_tank.PreviousWeapon);
    }

    private void UnBindInputPlayer()
    {
        _input.OnForward.RemoveListener(_tank.Movement.MoveForward);
        _input.OnBack.RemoveListener(_tank.Movement.MoveBack);
        _input.OnLeft.RemoveListener(_tank.Movement.RotateLeft);
        _input.OnRight.RemoveListener(_tank.Movement.RotateRight);
        _input.OnFire.RemoveListener(_tank.TryShoot);
        _input.OnNextWeapon.RemoveListener(_tank.NextWeapon);
        _input.OnPreviousWeapon.RemoveListener(_tank.PreviousWeapon);
    }
}
