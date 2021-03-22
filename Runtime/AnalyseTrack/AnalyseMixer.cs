using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Playables;

namespace UnityEngine.Timeline
{
    /// <summary>
    /// <para>混合器从<see cref="PlayableBehaviour"/>继承</para>
    /// 混合器官方通常以Mixer后缀
    /// <para><see cref="ActivationMixerPlayable"/>,<seealso cref="CinemachineMixer"/></para>
    /// </summary>
    [DisplayName("分析轨道混合器")]//PlayableBehaviour名字不起作用
    [Serializable]
    public class AnalyseMixer : PlayableBehaviour
    {
        public AnalyseTrack Track { get; internal set; }

        public Color ClassColor = new Color(0.02f, 0.58f, 0.30f, 1);
        public Color FuncColor = new Color(0.70f, 0.42f, 0.01f, 1);
        public bool LogMixerOnGraphStart = true;
        public bool LogMixerOnPlayableCreate = true;
        public bool LogMixerOnGraphStop = true;
        public bool LogMixerOnPlayableDestroy = true;
        public bool LogMixerOnBehaviourPlay = true;
        public bool LogMixerOnBehaviourPause = true;
        public bool LogMixerPrepareData = false;
        public bool LogMixerPrepareFrame = false;
        public bool LogMixerProcessFrame = false;

        internal static string Html(string orignal, in Color color)
        {
            return $"<color=#{ColorUtility.ToHtmlStringRGBA(color)}>{orignal}</color>";
        }

        string ClassName => Html(nameof(AnalyseMixer), ClassColor);

        string FuncName([CallerMemberName] string funcName = "")
        {
            return Html(funcName, FuncColor);
        }

        public override void OnGraphStart(Playable playable)
        {
            if (LogMixerOnGraphStart)
            {
                Debug.Log($"Mixer 触发 {ClassName}.{FuncName()}。\n" +
                $"graph:{JsonUtility.ToJson(playable)}");
            }
            base.OnGraphStart(playable);
        }

        public override void OnPlayableCreate(Playable playable)
        {
            if (LogMixerOnPlayableCreate)
            {
                Debug.Log($"Mixer 触发 {ClassName}.{FuncName()}。\n" +
                $"graph:{JsonUtility.ToJson(playable)}");
            }

            base.OnPlayableCreate(playable);
        }

        public override void OnGraphStop(Playable playable)
        {
            if (LogMixerOnGraphStop)
            {
                Debug.Log($"Mixer 触发 {ClassName}.{FuncName()}。\n" +
                $"graph:{JsonUtility.ToJson(playable)}");
            }

            base.OnGraphStop(playable);
        }

        public override void OnPlayableDestroy(Playable playable)
        {
            if (LogMixerOnPlayableDestroy)
            {
                Debug.Log($"Mixer 触发 {ClassName}.{FuncName()}。\n" +
                $"graph:{JsonUtility.ToJson(playable)}");
            }

            base.OnPlayableDestroy(playable);
        }

        public override void OnBehaviourPlay(Playable playable, FrameData info)
        {
            if (LogMixerOnBehaviourPlay)
            {
                Debug.Log($"Mixer 触发 {ClassName}.{FuncName()}。\n" +
                $"graph:{JsonUtility.ToJson(playable)} \n" +
                $"info:{JsonUtility.ToJson(info)} \n");
            }

            base.OnBehaviourPlay(playable, info);
        }

        public override void OnBehaviourPause(Playable playable, FrameData info)
        {
            if (LogMixerOnBehaviourPause)
            {
                Debug.Log($"Mixer 触发 {ClassName}.{FuncName()}。\n" +
                $"graph:{JsonUtility.ToJson(playable)} \n" +
                $"info:{JsonUtility.ToJson(info)} \n");
            }

            base.OnBehaviourPause(playable, info);
        }

        public override void PrepareData(Playable playable, FrameData info)
        {
            if (LogMixerPrepareData)
            {
                Debug.Log($"Mixer 触发 {ClassName}.{FuncName()}。\n" +
                $"graph:{JsonUtility.ToJson(playable)} \n" +
                $"info:{JsonUtility.ToJson(info)} \n");
            }

            base.PrepareData(playable, info);
        }

        [Space]
        public bool LogMixerFrameInfo = true;
        public override void PrepareFrame(Playable playable, FrameData info)
        {
            if (LogMixerPrepareFrame)
            {
                Debug.Log($"Mixer 触发 {ClassName}.{FuncName()}。\n" +
                    $"graph:{JsonUtility.ToJson(playable)} \n" +
                    $"info:{JsonUtility.ToJson(info)} \n");
            }

            if (LogMixerFrameInfo)
            {
                Debug.Log($"frameId {info.frameId} evaluationType {info.evaluationType}" +
                    $" deltaTime {info.deltaTime}  {info} " +
                    $"  playable {playable.GetTime()} frame {(int)(playable.GetTime() * 60)}");
            }
            base.PrepareFrame(playable, info);
        }

        public override void ProcessFrame(Playable playable, FrameData info, object playerData)
        {
            if (LogMixerProcessFrame)
            {
                Debug.Log($"Mixer 触发 {ClassName}.{FuncName()}。\n" +
                    $"graph:{JsonUtility.ToJson(playable)} \n" +
                    $"info:{JsonUtility.ToJson(info)} \n" +
                    $"object:{JsonUtility.ToJson(playerData)}");
            }
            base.ProcessFrame(playable, info, playerData);
        }


    }
}
