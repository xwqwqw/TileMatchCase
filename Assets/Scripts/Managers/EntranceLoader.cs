using System.Collections;
using Constants;
using Managers;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TKK
{
    public class EntranceLoader : MonoBehaviour
    {
        public GameObject loadingScreen;
        private void Start() => ListenEvents();
        private void ListenEvents() => Events.OnFakeLoading.AddListener(LoadScenes);
        private void LoadScenes() => StartCoroutine(LoadSceneAsync());

        private IEnumerator LoadSceneAsync()
        {
            var operation = SceneManager.LoadSceneAsync(SceneNames.GameScene.ToString());

            loadingScreen.SetActive(true);
            while (!operation.isDone)
            {
                yield return null;
            }
        }
    }
}