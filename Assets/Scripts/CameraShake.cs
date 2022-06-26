using UnityEngine;

public class CameraShake : MonoBehaviour {


    private Transform _transform;
    private float shakeDuration = 0f;
    private float shakeMagnitude = 0.7f;
    private float dampingSpeed = 1.0f;
    Vector3 initialPosition;
   
    void Awake() {


        if (_transform == null) {
            _transform = GetComponent(typeof(Transform)) as Transform;
        }
    }

    void OnEnable() {
        initialPosition = _transform.localPosition;
    }

    void Update() {
        if (shakeDuration > 0) {
            _transform.localPosition = initialPosition + Random.insideUnitSphere * shakeMagnitude;

            shakeDuration -= Time.deltaTime * dampingSpeed;
        }
        else {
            shakeDuration = 0f;
            _transform.localPosition = initialPosition;
        }
    }

    public void TriggerShake() {
        shakeDuration = 1.0f;
    }

}
