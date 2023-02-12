using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;

namespace BaseProject.Mechanics.Swerve
{
    [RequireComponent(typeof(SwerveInputSystem), typeof(Rigidbody))]
    public class SwerveMain : MonoBehaviour
    {
        #region Private Variables

        private SwerveInputSystem _swerveInputSystem;
        private Rigidbody _rb;
        private SwerveSettingsSO _swerveSo;

        #endregion

        #region SerializeField Variables

        [TabGroup("Which axis do you want to swerve?")] [SerializeField]
        private bool x;

        [TabGroup("Which axis do you want to swerve?")] [SerializeField]
        private bool y;

        #endregion

        #region Properties

        private Vector3 RbPos => _rb.position;

        #endregion

        #region Odin Buttons

#if UNITY_EDITOR
        [Button("Ping Swerve Settings")]
        public void PingSettings()
        {
            _swerveSo = Resources.Load("BaseProject/Mechanics/Swerve/SwerveMovementSettings") as SwerveSettingsSO;
            EditorGUIUtility.PingObject(_swerveSo);
        }
#endif
        
        #endregion

        private void Awake()
        {
            ResourcesLoad();
            GetReferences();
        }

        private void Update()
        {
            UpdateInit();
        }

        private void UpdateInit()
        {
            _swerveInputSystem.SwerveUpdate();
            MechanicUpdate();
        }

        // ReSharper disable Unity.PerformanceAnalysis
        private void MechanicUpdate()
        {
            if (x && !y)
            {
                _rb.MovePosition(RbPos + new Vector3(_swerveInputSystem.MoveFactor.x * _swerveSo.XAxisSpeed * Time.deltaTime
                    , 0, 0)
                );
            }

            if (!x && y)
            {
                _rb.MovePosition(RbPos + new Vector3(0,
                    _swerveInputSystem.MoveFactor.y * _swerveSo.YAxisSpeed * Time.deltaTime, 0)
                );
            }

            if (x && y)
            {
                _rb.MovePosition(RbPos + new Vector3(
                    _swerveInputSystem.MoveFactor.x * _swerveSo.XAxisSpeed * Time.deltaTime,
                    _swerveInputSystem.MoveFactor.y * _swerveSo.YAxisSpeed * Time.deltaTime,
                    0)
                );
            }

            if (!x && !y)
            {
                Debug.LogError("Please Choose Swerve Direction");
                Debug.Break();
            }
        }

        private void GetReferences()
        {
            _swerveInputSystem = GetComponent<SwerveInputSystem>();
            _rb = GetComponent<Rigidbody>();
        }

        private void ResourcesLoad()
        {
            _swerveSo = Resources.Load("BaseProject/Mechanics/Swerve/SwerveMovementSettings") as SwerveSettingsSO;
        }
    }
}