using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
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
    public class AnalyseMixer : PlayableBehaviour
    {
        public bool LogOnGraphStart = true;

        public AnalyseTrack Track { get; internal set; }

        public override void OnGraphStart(Playable playable)
        {
            if (LogOnGraphStart)
            {
                Debug.Log($"Mixer 触发 {nameof(AnalyseMixer)}.{nameof(OnGraphStart)}。\n" +
                $"graph:{JsonUtility.ToJson(playable)}");
            }
            base.OnGraphStart(playable);
        }   

        public override void OnPlayableCreate(Playable playable)
        {
            Debug.Log($"Mixer 触发 {nameof(AnalyseMixer)}.{nameof(OnPlayableCreate)}。\n" +
                $"graph:{JsonUtility.ToJson(playable)}");
            base.OnPlayableCreate(playable);
        }

        public override void OnGraphStop(Playable playable)
        {
            Debug.Log($"Mixer 触发 {nameof(AnalyseMixer)}.{nameof(OnGraphStop)}。\n" +
                $"graph:{JsonUtility.ToJson(playable)}");
            base.OnGraphStop(playable);
        }

        public override void OnPlayableDestroy(Playable playable)
        {
            Debug.Log($"Mixer 触发 {nameof(AnalyseMixer)}.{nameof(OnPlayableDestroy)}。\n" +
                $"graph:{JsonUtility.ToJson(playable)}");
            base.OnPlayableDestroy(playable);
        }

        public override void OnBehaviourPlay(Playable playable, FrameData info)
        {
            Debug.Log($"Mixer 触发 {nameof(AnalyseMixer)}.{nameof(OnBehaviourPlay)}。\n" +
                $"graph:{JsonUtility.ToJson(playable)} \n" +
                $"info:{JsonUtility.ToJson(info)} \n");

            base.OnBehaviourPlay(playable, info);
        }

        public override void OnBehaviourPause(Playable playable, FrameData info)
        {
            Debug.Log($"Mixer 触发 {nameof(AnalyseMixer)}.{nameof(OnBehaviourPause)}。\n" +
                $"graph:{JsonUtility.ToJson(playable)} \n" +
                $"info:{JsonUtility.ToJson(info)} \n");
            base.OnBehaviourPause(playable, info);
        }

        public override void PrepareData(Playable playable, FrameData info)
        {
            Debug.Log($"Mixer 触发 {nameof(AnalyseMixer)}.{nameof(PrepareData)}。\n" +
                $"graph:{JsonUtility.ToJson(playable)} \n" +
                $"info:{JsonUtility.ToJson(info)} \n");
            base.PrepareData(playable, info);
        }

        public override void PrepareFrame(Playable playable, FrameData info)
        {
            if (Track.LogMixerPrepareFrame)
            {
                Debug.Log($"Mixer 触发 {nameof(AnalyseMixer)}.{nameof(PrepareFrame)}。\n" +
                    $"graph:{JsonUtility.ToJson(playable)} \n" +
                    $"info:{JsonUtility.ToJson(info)} \n");
            }
            base.PrepareFrame(playable, info);
        }

        public override void ProcessFrame(Playable playable, FrameData info, object playerData)
        {
            if (Track.LogMixerProcessFrame)
            {
                Debug.Log($"Mixer 触发 {nameof(AnalyseMixer)}.{nameof(ProcessFrame)}。\n" +
                    $"graph:{JsonUtility.ToJson(playable)} \n" +
                    $"info:{JsonUtility.ToJson(info)} \n" +
                    $"object:{JsonUtility.ToJson(playerData)}");
            }
            base.ProcessFrame(playable, info, playerData);
        }

        
    }
}
