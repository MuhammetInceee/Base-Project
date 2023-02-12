using UnityEngine;

namespace BaseProject.Mechanics.Swerve
{
    [CreateAssetMenu(menuName = "Base/Mechanics/SwerveSettings")]
    public class SwerveSettingsSO : ScriptableObject
    {
        [SerializeField] private float xAxisSpeed;
        public float XAxisSpeed => xAxisSpeed;

        [SerializeField] private float yAxisSpeed;
        public float YAxisSpeed => yAxisSpeed;
    }
}
