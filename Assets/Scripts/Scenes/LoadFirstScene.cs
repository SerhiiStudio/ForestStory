using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadFirstScene : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private Text text;

    private string sceneToLoad = Scenes.Chapter1;
    private string textProgress = "Progress: ";



    private void Start()
    {
        StartCoroutine(StartSceneAsync());

        //InputSistema.Instance.Input.Clicks.Up.performed += ctx => {StartCoroutine(StartSceneAsync());};
    }


    private IEnumerator StartSceneAsync()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneToLoad);
        operation.allowSceneActivation = false;

        while (operation.progress < 0.9f)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);

            if (slider != null)
                slider.value = progress;
            if (text != null)
                text.text = textProgress + (int)(progress * 10);

            Debug.Log($"Progress: {progress}");
            yield return null;
        }
        operation.allowSceneActivation = true;
        }


}
