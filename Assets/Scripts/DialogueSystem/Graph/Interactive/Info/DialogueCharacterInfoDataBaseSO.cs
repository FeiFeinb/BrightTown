using System.Collections.Generic;
using DialogueSystem.GamePlay;
using UnityEngine;

namespace DialogueSystem.Graph
{
    /// <summary>
    /// 可对话NPC数据库
    /// </summary>
    [CreateAssetMenu(fileName = "New DialogueCharacterInfoDataBaseSO", menuName = "Dialogue System/DialogueCharacterInfoDataBaseSO")]
    public class DialogueCharacterInfoDataBaseSO : ScriptableObject
    {
        // TODO: 利用Addressable添加角色信息
        public DialogueCharacterInfoSO[] characterInfos;        // 可对话NPC人物信息
        public readonly Dictionary<DialogueCharacterInfoSO, GameObject> sceneCharacterInfoDic = new Dictionary<DialogueCharacterInfoSO, GameObject>();  // 场景中NPC-GameObject字典

        /// <summary>
        /// 更新数据库
        /// </summary>
        public void Init()
        {
            // 序列化场景NPC记录字典
            foreach (var sceneNPC in FindObjectsOfType<DialogueNPC>())
            {
                sceneCharacterInfoDic.Add(sceneNPC.npcInfo, sceneNPC.gameObject);
            }
        }

        public void GenerateCharacterID()
        {
            // 仓库序列化时赋值ID
            for (int i = 0; i < characterInfos.Length; i++)
            {
                characterInfos[i].ID = i;
            }
        }
    }
}