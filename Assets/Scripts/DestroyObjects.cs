using UnityEngine;

public class GameManager : MonoBehaviour{

    private void OnTriggerEnter(Collider other) {
        Destroy(other.gameObject);
    }
}
