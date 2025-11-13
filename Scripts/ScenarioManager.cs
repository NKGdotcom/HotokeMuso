using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScenarioManager : MonoBehaviour
{
    [SerializeField] private StageScenario scenario;
    [SerializeField] private DialogueUI dialogueUI;
    [SerializeField] private GameObject dialogue;

    private float nextWaitTime = 1;
    private int currentIndex = 0;
    private bool waiting = false;
    private Dictionary<string, int> functionTriggers = new();
    private Dictionary<string, int> conditionTriggers = new();

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i< scenario.Events.Length; i++)
        {
            var e = scenario.Events[i];
            if (e.TriggerType == TriggerType.Function)
            {
                functionTriggers[scenario.Events[i].TriggerFunctionName] = i;
            }
            else if (e.TriggerType == TriggerType.Condition)
            {
                conditionTriggers[e.TriggerFunctionName] = i;   
            }
        }
        StartCoroutine(ScenarioFlow());
    }

    private IEnumerator ScenarioFlow()
    {
        while(currentIndex < scenario.Events.Length)
        {
            dialogue.SetActive(true);
            var e = scenario.Events[currentIndex];
            //UIのセリフを表示
            dialogueUI.ShowDialogue(e.CharacterName, e.Dialogue, e.FaceSprite);

            switch (e.TriggerType)
            {
                case TriggerType.Auto:
                    currentIndex++;
                    yield return null;
                    break;
                case TriggerType.Time:
                    yield return new WaitForSeconds(e.DelayTime);
                    currentIndex++;
                    break;
                case TriggerType.Function:
                case TriggerType.Condition:
                    waiting = true;
                    yield return new WaitUntil(() => !waiting);
                    yield return new WaitForSeconds(e.DelayTime);
                    currentIndex++;
                    break;
            }


            yield return new WaitForSeconds(nextWaitTime);
            dialogue.SetActive(false);
            yield return new WaitForSeconds(nextWaitTime);
        }
        yield break;
    }
    // 🔹 外部イベントから呼び出す
    public void Trigger(string triggerName)
    {
        if ((functionTriggers.TryGetValue(triggerName, out int fIndex) && fIndex == currentIndex)
            || (conditionTriggers.TryGetValue(triggerName, out int cIndex) && cIndex == currentIndex))
        {
            if (waiting)
            {
                waiting = false;
            }
        }
    }

    // 🔹 割り込み用（例：敵に近づいたら）
    /*public void InsertScenario(ScenarioEvent insertEvent)
    {
        StopAllCoroutines();
        StartCoroutine(PlayInsertedEvent(insertEvent));
    }*/

    /*private IEnumerator PlayInsertedEvent(ScenarioEvent insertEvent)
    {
        dialogueUI.ShowDialogue(insertEvent.characterName, insertEvent.dialogue);
        yield return new WaitForSeconds(insertEvent.delayTime);
        StartCoroutine(PlayScenario()); // 元の進行に戻る
    }*/

    // 関数呼び方
    //FindAnyObjectByType<ScenarioManager>().TriggerFunction("OnBossAppears");
}
