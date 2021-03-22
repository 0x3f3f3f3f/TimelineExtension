using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace UnityEngine.Timeline
{
    /// <summary>
    /// <para>对timeline 和 playable 系统进行分析，主要是在各个函数打log</para>
    /// 可播轨道官方通常以Track后缀
    /// <para><see cref="ActivationTrack"/>,<seealso cref="AnimationTrack"/></para>
    /// </summary>
    [TrackColor(0.82f, 0.58f, 0.23f)]
    [DisplayName("分析轨道")]//轨道名字不起作用
    [TrackClipType(typeof(AnalysePlayableAsset))]
    public partial class AnalyseTrack : PlayableTrack
    {
        public bool LogCreatePlayable;
        protected override Playable CreatePlayable(PlayableGraph graph, GameObject gameObject, TimelineClip clip)
        {
            if (LogCreatePlayable)
            {
                Debug.Log($"触发 <color=#0000ff>{nameof(AnalyseTrack)}.{nameof(CreatePlayable)}</color> \n" +
                    $"graph:{JsonUtility.ToJson(graph)} \n" +
                    $"owner:{gameObject.name} \n" +
                    $"clip:{JsonUtility.ToJson(clip)}");
            }

            return base.CreatePlayable(graph, gameObject, clip);
        }

        public bool LogOnCreateClip;
        protected override void OnCreateClip(TimelineClip clip)
        {
            if (LogOnCreateClip)
            {
                Debug.Log($"触发 <color=#0000ff>{nameof(AnalyseTrack)}.{nameof(OnCreateClip)}</color> \n" +
                $"clip:{JsonUtility.ToJson(clip)}");
            }

            base.OnCreateClip(clip);
            if (clip.asset is AnalysePlayableAsset asset)
            {
                clip.displayName = "分析Clip：  " + asset.template.UUID.Substring(0, 8);
            }
        }

        public bool LogCreateTrackMixer;

        public override Playable CreateTrackMixer(PlayableGraph graph, GameObject go, int inputCount)
        {
            if (LogCreateTrackMixer)
            {
                Debug.Log($"触发 <color=#0000ff>{nameof(AnalyseTrack)}.{nameof(CreateTrackMixer)}</color> \n" +
                $"graph:{JsonUtility.ToJson(graph)}  owner:{go.name} inputCount:{inputCount}");
            }
            var handle = ScriptPlayable<AnalyseMixer>.Create(graph, MixerLogSetting, inputCount);
            handle.GetBehaviour().Track = this;
            return handle;
        }

        public bool LogOnAfterTrackDeserialize;

        protected override void OnAfterTrackDeserialize()
        {
            if (LogOnAfterTrackDeserialize)
            {
                Debug.Log($"触发 <color=#0000ff>{nameof(AnalyseTrack)}.{nameof(OnAfterTrackDeserialize)}</color> \n");
            }
            base.OnAfterTrackDeserialize();
        }

        [Header("Mixer混合器Log设置")]
        public AnalyseMixer MixerLogSetting = new AnalyseMixer();
    }

    internal static class Ex
    {
        public static string Html(this string orignal, in Color color)
        {
            return $"<color=#{ColorUtility.ToHtmlStringRGBA(color)}>{orignal}</color>";
        }
    }
}

