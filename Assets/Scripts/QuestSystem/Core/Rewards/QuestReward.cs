using System.Text;
namespace QuestSystem
{
    [System.Serializable]
    public class QuestReward
    {
        public int experience = 0;      // 奖励经验
        public int itemObjAmount;       // 奖励物品数量

        public string ExperienceStr
        {
            get
            {
                return $"{experience}点经验";
            }
        }
    }
}