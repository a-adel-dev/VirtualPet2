using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(XRGrabInteractable))]
public class TutorialBall : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float respawnDelay = 2f;
    [SerializeField] private float velocityThreshold = 0.1f;

    private Rigidbody _rb;
    private XRGrabInteractable _grabInteractable;
    private Vector3 _initialPosition;
    private Quaternion _initialRotation;
    private float _stoppedTime;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _grabInteractable = GetComponent<XRGrabInteractable>();
        
        // Store initial transform values
        _initialPosition = transform.position;
        _initialRotation = transform.rotation;
    }

    private void Update()
    {
        // Check if not currently grabbed and has stopped moving
        if (!_grabInteractable.isSelected && CheckStoppedMoving())
        {
            _stoppedTime += Time.deltaTime;
            
            if (_stoppedTime >= respawnDelay)
            {
                Respawn();
            }
        }
        else
        {
            _stoppedTime = 0f;
        }
    }

    private bool CheckStoppedMoving()
    {
        // Check both velocity and angular velocity
        return _rb.linearVelocity.magnitude < velocityThreshold && 
               _rb.angularVelocity.magnitude < velocityThreshold;
    }

    private void Respawn()
    {
        // Reset physics state
        _rb.linearVelocity = Vector3.zero;
        _rb.angularVelocity = Vector3.zero;
        
        // Reset position and rotation
        transform.SetPositionAndRotation(_initialPosition, _initialRotation);
        
        // Reset timer
        _stoppedTime = 0f;
    }

    // Optional: Draw gizmo to show initial position in editor
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(_initialPosition, 0.1f);
    }
}