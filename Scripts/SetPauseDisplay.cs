using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPauseDisplay : MonoBehaviour
{
    [SerializeField] private GameObject pauseUICanvas;
    [SerializeField] private PauseMenuItem[] pauseMenuItemList;
    [SerializeField] private Animator pauseUIAnimator;
    private bool isPaused = false;
    private int nowIndexPage = 0;
    // Start is called before the first frame update
    void Start()
    {
        pauseUICanvas.SetActive(false); //開いたらアニメーションを付ける予定

        nowIndexPage = 0;
        pauseUIAnimator.ResetTrigger("Close");
    }

    // Update is called once per frame
    void Update()
    {
        //Pキーでオプションの開け閉め
        if (Input.GetKeyDown(KeyCode.P))
        {
            TogglePauseDisplay();
        }

        if (isPaused)
        {
            if(Input.GetKeyDown(KeyCode.W)) //上に
            {
                pauseMenuItemList[nowIndexPage].DeselectUI();
                if (nowIndexPage == 0)
                {
                    nowIndexPage = pauseMenuItemList.Length - 1;
                }
                else
                {
                    nowIndexPage--;
                }
                pauseMenuItemList[nowIndexPage].SelectUI();
            }
            else if(Input.GetKeyDown(KeyCode.S)) //下に
            {
                pauseMenuItemList[nowIndexPage].DeselectUI();
                if (nowIndexPage == pauseMenuItemList.Length - 1)
                {
                    nowIndexPage = 0;
                }
                else
                {
                    nowIndexPage++;
                }
                pauseMenuItemList[nowIndexPage].SelectUI();
            }
        }
    }
    /// <summary>
    /// ポーズ画面の開け閉め
    /// </summary>
    private void TogglePauseDisplay()
    {
        isPaused = !isPaused;
       

        pauseMenuItemList[nowIndexPage].SelectUI();

        if (isPaused)
        {
            pauseUICanvas.SetActive(isPaused);
            Time.timeScale = 0.0f;
        }
        else
        {
            StartCoroutine(CloseUIDisplay());
        }
    }
    /// <summary>
    /// アニメーションを流すためコルーチンを使用
    /// </summary>
    /// <returns></returns>
    private IEnumerator CloseUIDisplay()
    {
        AnimatorStateInfo info = pauseUIAnimator.GetCurrentAnimatorStateInfo(0);
        pauseUIAnimator.SetTrigger("Close");
        yield return new WaitForSecondsRealtime(info.length);
        pauseUICanvas.SetActive(isPaused);
        Time.timeScale = 1.0f;
        yield break;
    }
}
