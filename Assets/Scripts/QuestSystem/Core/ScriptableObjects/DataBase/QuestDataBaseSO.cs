﻿using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace QuestSystem
{
    [CreateAssetMenu(fileName = "New QuestDataBaseSO", menuName = "Quest System/QuestDataBaseSO")]
    public class QuestDataBaseSO : ScriptableObject
    {
        public Dictionary<string, QuestSO> questSODic = new Dictionary<string, QuestSO>();      // 任务数组
        
        [SerializeField] private QuestSO[] questSOs;                                            // 任务查询字典
        
        public void Init()
        {
            // 清空字典
            questSODic.Clear();
            // 根据数组创建字典
            questSODic = questSOs.ToDictionary(questSO => questSO.QuestUniqueID, questSO => questSO);
        }
    }
}