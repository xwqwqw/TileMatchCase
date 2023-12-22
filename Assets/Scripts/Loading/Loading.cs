using System.Collections;
using Managers;
using UnityEngine;
using UnityEngine.UI;
using Utility;

namespace TKK.Loading
{
    public class Loading : MonoSingleton<Loading>
    {
        [SerializeField] private Text loadingText;
        [SerializeField] private Image loadingImg;
        private string loadingText0 = "LOADING";
        private string loadingText1 = ".";

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

        private IEnumerator TurnOff()
        {
            yield return new WaitForSeconds(2f);
            Events.OnFakeLoading.Invoke();
            gameObject.SetActive(false);
        }

        private IEnumerator Loop()
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

        private IEnumerator RotateImage()
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