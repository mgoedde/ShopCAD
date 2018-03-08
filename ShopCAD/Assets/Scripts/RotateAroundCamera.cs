using UnityEngine;


public class RotateAroundCamera : MonoBehaviour
{
    Camera cam;
    public bool isControlable;
    private Vector3 screenPoint;
    private Vector3 lastPosition;
    private Vector3 offset;
    public Transform target;
    public float distance = 5.0f;
    public float xSpeed = 50.0f;
    public float ySpeed = 50.0f;
    public float yMinLimit = -80f;
    public float yMaxLimit = 80f;
    public float distanceMin = .5f;
    public float distanceMax = 15f;
    public float smoothTime = 2f;
    public float rotationYAxis = 0.0f;
    float rotationXAxis = 0.0f;
    float velocityX = 0.0f;
    float velocityY = 0.0f;
    float moveDirection = -1;
    public float wheelSpeed = 2f;
    public float orbitSpeed = 1f;
    public float panSpeed = 2f;
    public int orbitKey = 1;
    public int panKey = 2;
    public void SetControllable(bool value)
    {
        isControlable = value;
    }
    // Use this for initialization
    void Start()
    {
        cam = GetComponentInChildren<Camera>();
        Vector3 angles = transform.eulerAngles;
        rotationYAxis = (rotationYAxis == 0) ? angles.y : rotationYAxis;
        rotationXAxis = angles.x;
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        // Make the rigid body not change rotation
        if (rigidbody)
        {
            rigidbody.freezeRotation = true;
        }
    }
    void LateUpdate()
    {
        if (target)
        {
            if (Input.GetMouseButton(orbitKey) && isControlable)
            {
                velocityX += xSpeed * Input.GetAxis("Mouse X") * 0.02f * orbitSpeed;
                velocityY += ySpeed * Input.GetAxis("Mouse Y") * 0.02f * orbitSpeed;
            }
            target.Translate(Vector3.forward * Input.GetAxis("Mouse ScrollWheel") * wheelSpeed);
            if (Input.GetMouseButtonDown(panKey) && isControlable)
            {
                lastPosition = Input.mousePosition;
            }
            if (Input.GetMouseButton(panKey) && isControlable)
            {
                Vector3 delta = Input.mousePosition - lastPosition;
                target.Translate(delta.x * panSpeed * moveDirection, delta.y * panSpeed * moveDirection, 0);
                lastPosition = Input.mousePosition;
            }
            if (Input.GetKeyDown(KeyCode.R) && isControlable)
            {
                target.transform.position = Vector3.zero;
            }
            if (Input.GetKeyDown(KeyCode.T) && isControlable)
            {
                moveDirection *= -1;
            }
            rotationYAxis += velocityX;
            rotationXAxis -= velocityY;
            rotationXAxis = ClampAngle(rotationXAxis, yMinLimit, yMaxLimit);
            Quaternion fromRotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 0);
            Quaternion toRotation = Quaternion.Euler(rotationXAxis, rotationYAxis, 0);
            Quaternion rotation = toRotation;
            Vector3 negDistance = new Vector3(0.0f, 0.0f, -distance);
            Vector3 position = rotation * negDistance + target.position;
            transform.rotation = rotation;
            transform.position = position;
            velocityX = Mathf.Lerp(velocityX, 0, Time.deltaTime * smoothTime);
            velocityY = Mathf.Lerp(velocityY, 0, Time.deltaTime * smoothTime);
        }

    }
    public static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360F)
            angle += 360F;
        if (angle > 360F)
            angle -= 360F;
        return Mathf.Clamp(angle, min, max);
    }
}