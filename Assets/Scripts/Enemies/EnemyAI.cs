using UnityEngine;

namespace LevGogol.GameCore.Enemies
{
    public class EnemyAI : MonoBehaviour
    {
        public Vector3 Direction(Transform target)
        {
            return target.position - transform.position;
        }
    }
}