using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Credits : MonoBehaviour
{
    [SerializeField]
    TextAsset text;
    [SerializeField]
    Text textUI;
    [SerializeField]
    Button menuButton;
    [SerializeField]
    CanvasGroup canvasGroup;
    [SerializeField]
    float scrollTime = 0.8f;
    private bool timerStart = false;
    private float timer;

    void Start()
    {
        textUI.text = text.text;
    }

    void Update()
    {
        if(!timerStart)
        {
            timer += Time.unscaledDeltaTime;

            if(scrollTime < timer)
                timerStart = true;
        }
    }
    void FixedUpdate()
    {
        if(timerStart)
        {
            Vector3 creditPosition = textUI.transform.localPosition;
            textUI.transform.localPosition = new Vector3(creditPosition.x, creditPosition.y + 1f, creditPosition.z);
        }
    }

    public void LoadTitleMenu()
    {
        menuButton.gameObject.SetActive(false);
        StartCoroutine(LoadTitleMenuCoroutine());
    }

    IEnumerator LoadTitleMenuCoroutine()
    {
        float timer = 0f;
        float limit = 1f;
        var sceneLoad = SceneManager.LoadSceneAsync("TitleMenu");
        sceneLoad.allowSceneActivation = false;

        while(timer < limit)
        {
            timer += Time.unscaledDeltaTime;
            canvasGroup.gameObject.SetActive(true);
            canvasGroup.alpha = Mathf.Lerp(1f, 0f, Mathf.Clamp(timer, 0f, limit) / limit);
            yield return new WaitForEndOfFrame();
        }

        while (sceneLoad.progress < 0.9f)
        {
            yield return new WaitForEndOfFrame();
        }
        
        sceneLoad.allowSceneActivation = true;
    }
}
