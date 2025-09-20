using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CarController : MonoBehaviour
{
    [Header("References")]
    public Rigidbody rb; // car body Rigidbody (assign in inspector)
    public Transform wheelFL; // front-left visual wheel
    public Transform wheelFR; // front-right visual wheel
    public Transform wheelRL; // rear-left visual wheel
    public Transform wheelRR; // rear-right visual wheel

    [Header("Physics / Movement")]
    public float motorForce = 4000f;      // forward/backward force
    public float maxSteerAngle = 30f;     // visual steer angle for front wheels
    public float steerSpeed = 2.5f;       // how fast the car rotates when steering
    public float brakeForce = 8000f;      // braking force (opposing)
    public float maxSpeed = 30f;          // top speed (m/s)

    [Header("Wheel Visuals")]
    public float wheelRadius = 0.35f;     // in meters (used to convert linear travel -> wheel rotation)
    public bool autoDetectWheelRadius = true;

    // internal
    float wheelRotationDegrees; // degree to rotate wheels this FixedUpdate
    float steeringAngle;        // current steer visual angle (degrees)

    void Reset()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        if (rb == null) rb = GetComponent<Rigidbody>();
        if (autoDetectWheelRadius)
        {
            DetectWheelRadius();
        }
    }

    void DetectWheelRadius()
    {
        // try to guess radius from first assigned wheel mesh bounds (if any)
        Transform any = wheelFL ?? wheelFR ?? wheelRL ?? wheelRR;
        if (any != null)
        {
            var mr = any.GetComponentInChildren<MeshFilter>();
            if (mr != null)
            {
                wheelRadius = Mathf.Max(0.01f, mr.sharedMesh.bounds.extents.y * any.localScale.y);
            }
        }
    }

    void FixedUpdate()
    {
        // Input
        float motorInput = Input.GetAxis("Vertical");   // W/S or UpDown
        float steerInput = Input.GetAxis("Horizontal"); // A/D or LeftRight
        bool braking = Input.GetKey(KeyCode.Space);     // space to brake

        // Limit forward speed
        float forwardSpeed = Vector3.Dot(rb.velocity, transform.forward); // signed speed along forward axis
        if (forwardSpeed > maxSpeed && motorInput > 0f)
            motorInput = 0f; // don't accelerate past max forward
        if (forwardSpeed < -maxSpeed * 0.5f && motorInput < 0f)
            motorInput = 0f; // limit reverse speed (optional)

        // Apply forward/backward force (relative to car orientation)
        Vector3 localForwardForce = transform.forward * motorInput * motorForce * Time.fixedDeltaTime;
        rb.AddForce(localForwardForce);

        // Braking
        if (braking)
        {
            // apply opposing force proportional to current velocity
            Vector3 brakingForce = -rb.velocity.normalized * brakeForce * Time.fixedDeltaTime;
            // avoid reversing direction purely by brake
            if (rb.velocity.magnitude > 0.1f)
                rb.AddForce(brakingForce);
        }

        // Steering: rotate the rigidbody yaw. Scale steering effectiveness with speed.
        float speedFactor = Mathf.Clamp(rb.velocity.magnitude / 8f, 0f, 1f); // tweak denominator to taste
        float yawDegrees = steerInput * maxSteerAngle * steerSpeed * speedFactor * Time.fixedDeltaTime;
        if (Mathf.Abs(yawDegrees) > 0.0001f)
        {
            Quaternion delta = Quaternion.Euler(0f, yawDegrees, 0f);
            rb.MoveRotation(rb.rotation * delta);
        }

        // Visual steering angle (for wheel orientation) - smoother interpolation
        float targetSteerAngle = steerInput * maxSteerAngle;
        steeringAngle = Mathf.Lerp(steeringAngle, targetSteerAngle, 10f * Time.fixedDeltaTime);

        // Wheel visual rotation (spin) computed from linear distance travelled this frame
        float distanceThisFrame = rb.velocity.magnitude * Time.fixedDeltaTime; // meters
        if (wheelRadius <= 0.001f) wheelRadius = 0.35f;
        float rotationDegrees = (distanceThisFrame / (2f * Mathf.PI * wheelRadius)) * 360f;
        // direction matters: if moving backward, rotation should be opposite
        if (Vector3.Dot(rb.velocity, transform.forward) < 0f) rotationDegrees = -rotationDegrees;

        // Apply to wheels
        RotateWheels(rotationDegrees);
        SteerFrontWheels(steeringAngle);
    }

    void RotateWheels(float deg)
    {
        if (wheelFL) wheelFL.Rotate(Vector3.right, deg, Space.Self);
        if (wheelFR) wheelFR.Rotate(Vector3.right, deg, Space.Self);
        if (wheelRL) wheelRL.Rotate(Vector3.right, deg, Space.Self);
        if (wheelRR) wheelRR.Rotate(Vector3.right, deg, Space.Self);
    }

    void SteerFrontWheels(float steerDeg)
    {
        if (wheelFL) SetLocalSteerY(wheelFL, steerDeg);
        if (wheelFR) SetLocalSteerY(wheelFR, steerDeg);
    }

    void SetLocalSteerY(Transform wheel, float steerDeg)
    {
        // Assumes wheel forward axis is local X rotation for spin, and local Y is the steer yaw.
        // We'll change localEulerAngles.y while preserving other axes.
        Vector3 le = wheel.localEulerAngles;
        // Convert to -180..180 range to interpolate nicely
        float currentY = NormalizeAngle(le.y);
        float newY = Mathf.LerpAngle(currentY, steerDeg, 0.8f); // smoothing
        le.y = newY;
        wheel.localEulerAngles = le;
    }

    float NormalizeAngle(float a)
    {
        while (a > 180f) a -= 360f;
        while (a < -180f) a += 360f;
        return a;
    }

}
