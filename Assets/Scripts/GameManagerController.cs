using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManagerController : MonoBehaviour{

    public TextMeshProUGUI welcomeText;
    public GameObject controller;
    public Slider scoreSlider;

    public CameraShake cameraShake;

    private void Start() {
        Time.timeScale = 0;
        scoreSlider.maxValue = GameObject.FindGameObjectsWithTag("White").Length;
    }

    private void Update() {
        if(Time.timeScale == 0) {
            if (Input.anyKeyDown) {
                Time.timeScale = 1;
                welcomeText.gameObject.SetActive(false);
                controller.gameObject.SetActive(true);
                scoreSlider.gameObject.SetActive(true);          
            }
        }
    }

    private void OnTriggerEnter(Collider other) {
        Destroy(other.gameObject);
        if(other.gameObject.tag == "White") scoreSlider.value++;
        if (other.gameObject.tag == "Red") {
            cameraShake.TriggerShake();
            StartCoroutine("ReloadLevel");
        } 
        if (scoreSlider.value == scoreSlider.maxValue) {
            if (SceneManager.GetActiveScene().buildIndex != 2) {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            else {
                welcomeText.gameObject.SetActive(true);
                welcomeText.text = "Congratulations!";
            }
            

        }
    }
    private IEnumerator ReloadLevel() {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}



//private void Update() {
//    if (Time.timeScale == 0) {
//        if (Input.touchCount > 0) {
//            Time.timeScale = 1;
//        }
//    }
//}