using System.Collections.Generic;
using System.Linq;

namespace SyskenTLib.LicenseMaster
{
    public class LicenseUtil
    {

        /// <summary>
        /// 優先度高い順に並び替える
        /// </summary>
        /// <param name="originalConfigList"></param>
        /// <returns></returns>
        public List<LicenseConfig> SortOrderConfig(List<LicenseConfig> originalConfigList)
        {
            List<LicenseConfig> sortedList = originalConfigList.OrderBy(config => config.GetShowLicenseOrder).ToList();
            return sortedList;
        }
        
        /// <summary>
        /// ライセンス表示が必要なライセンスのみに絞る
        /// </summary>
        /// <param name="originalConfigList"></param>
        /// <returns></returns>
        public List<LicenseConfig> FilterOnlyMustShowLicenseConfig(List<LicenseConfig> originalConfigList)
        {
            List<LicenseConfig> sortedList = originalConfigList.Where(config => config.GetIsMustShowLicense == true).ToList();
            return sortedList;
        }
        
    }
}