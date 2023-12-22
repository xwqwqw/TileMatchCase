using System.Collections;
using TKK.Constants;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TKK.Managers
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