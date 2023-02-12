using UnityEngine;

namespace BaseProject.Mechanics.Swerve
{
    public class SwerveInputSystem : MonoBehaviour
    {
        private Vector3 _lastFrameFingerPos;
        private Vector3 _moveFactor;

        public Vector3 MoveFactor => _moveFactor;

        public void SwerveUpdate()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _lastFrameFingerPos = Input.mousePosition;
            }
        
            else if (Input.GetMouseButton(0))
            {
                _moveFactor = Input.mousePosition - _lastFrameFingerPos;

                _lastFrameFingerPos = Input.mousePosition;
            }
        
            else if (Input.GetMouseButtonUp(0))
            {
                _moveFactor = Vector3.zero;
            }
        }
    }
}
