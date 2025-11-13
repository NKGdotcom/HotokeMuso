using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "StageScenario", menuName = "Scenario/StageScenario")]
public class StageScenario : ScriptableObject
{
    public ScenarioEvent[] Events;
}

[Serializable]
public class ScenarioEvent
{
    public string EventName { get => eventName; } //イベント識別用
    public string CharacterName{ get => characterName; } //誰のセリフか
    public string Dialogue { get => dialogue; } //セリフ
    public float DelayTime{ get => delayTime; } //次のイベントまでの時間
    public TriggerType TriggerType { get => triggerType; } //イベントの発生条件
    public string TriggerFunctionName { get => triggerFunctionName; } //関数トリガー名
    public Sprite FaceSprite { get => faceSprite; } //キャラクターの顔画像
    
    [SerializeField] private string eventName;
    [SerializeField] private string characterName;
    [TextArea(2, 5)]
    [SerializeField] private string dialogue;
    [SerializeField] private float delayTime;
    [SerializeField] private TriggerType triggerType;
    [SerializeField] private string triggerFunctionName;
    [SerializeField] private Sprite faceSprite;
}
public enum TriggerType
{
    Time, //時間経過で再生
    Function, //関数でトリガーされる
    Auto, //自動で次に進む
    Condition //条件トリガー用
}
