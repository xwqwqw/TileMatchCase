using System.Collections;
using Managers;
using UnityEngine;
using UnityEngine.UI;

namespace TKK.Loading
{
    public class Loading : MonoBehaviour
    {
        [SerializeField] private Text loadingText;
        [SerializeField] private Image loadingImg;
        [HideInInspector] public static Loading Instance;
        private string loadingText0 = "LOADING";
        private string loadingText1 = ".";

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(this.gameObject);
                return;
            }

            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }

        private void OnEnable()
        {
            StartCoroutine(Loop());
            StartCoroutine(RotateImage());
            OnStart();
        }

        private void OnStart()
        {
            StartCoroutine(TurnOff());
        }

        IEnumerator TurnOff()
        {
            yield return new WaitForSeconds(2f);
            Events.OnFakeLoading.Invoke();
            gameObject.SetActive(false);
        }

        IEnumerator Loop()
        {
            yield return null;
            float t = 0;
            while (true)
            {
                while (t < 1)
                {
                    loadingImg.fillAmount = t;
                    t += Time.deltaTime * 2.5f;
                    yield return new WaitForEndOfFrame();
                }

                loadingImg.fillClockwise = false;

                while (t > 0)
                {
                    loadingImg.fillAmount = t;
                    t -= Time.deltaTime * 2.5f;
                    yield return new WaitForEndOfFrame();
                }

                loadingImg.fillClockwise = true;
            }
        }

        IEnumerator RotateImage()
        {
            while (true)
            {
                loadingText.text = loadingText0 + "\n";
                yield return new WaitForSeconds(.15f);
                loadingText.text = loadingText0 + "\n" + loadingText1;
                yield return new WaitForSeconds(.15f);
                loadingText.text = loadingText0 + "\n" + loadingText1 + loadingText1;
                yield return new WaitForSeconds(.15f);
                loadingText.text = loadingText0 + "\n" + loadingText1 + loadingText1 + loadingText1;
                yield return new WaitForSeconds(.15f);
            }
        }
    }
}