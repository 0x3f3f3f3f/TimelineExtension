using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace UnityEngine.Timeline
{
    /// <summary>
    /// 可播放资产官方通常以<see cref="PlayableAsset"/>后缀
    /// <para><see cref="ActivationPlayableAsset"/>,<seealso cref="AnimationPlayableAsset"/></para>
    /// </summary>
    [DisplayName("分析Clip")]
    public class AnalysePlayableAsset : PlayableAsset, ITimelineClipAsset
    {
        public AnalysePlayableBehaviour template = new AnalysePlayableBehaviour();
        public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
        {
            if (template.LogCreatePlayable)
            {
                Debug.Log($"触发 <color=#00ff00>{nameof(AnalysePlayableAsset)}.{nameof(CreatePlayable)}</color> UUID:{template.UUID}\n" +
                $"graph:{JsonUtility.ToJson(graph)} \n" +
                $"owner:{owner.name}");
            }

            var res = ScriptPlayable<AnalysePlayableBehaviour>.Create(graph, template);
            return res;
        }

        public ClipCaps clipCaps => ClipCaps.All;
    }
}
