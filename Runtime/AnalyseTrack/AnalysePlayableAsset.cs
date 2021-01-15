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
    public class AnalysePlayableAsset : PlayableAsset,ITimelineClipAsset
    {
        public string UUID;
        public bool LogCreatePlayable;
        public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
        {
            if (LogCreatePlayable)
            {
                Debug.Log($"触发 <color=#00ff00>{nameof(AnalysePlayableAsset)}.{nameof(CreatePlayable)}</color> UUID:{UUID}\n" +
                $"graph:{JsonUtility.ToJson(graph)} \n" +
                $"owner:{owner.name}");
            }
            
            var res = Playable.Create(graph);
            return res;
        }

        public override double duration => 2f;

        public ClipCaps clipCaps => ClipCaps.All;
    }
}
