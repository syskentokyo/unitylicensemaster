using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace SyskenTLib.LicenseMaster
{
    public class LicenseManager : MonoBehaviour
    {
        [SerializeField] private LicenseOnlyShowRootConfig rootRootConfig;

        private LicenseUtil _licenseUtil = new LicenseUtil();
        
        
        
        /// <summary>
        /// ライセンス表記が必要なライセンス一覧を返す
        /// </summary>
        /// <returns></returns>
        public List<LicenseConfig> GetLicenseConfigs()
        {
            List<LicenseConfig> sortedConfigList  =  _licenseUtil.SortOrderConfig(rootRootConfig.GetLicenseList());
            return sortedConfigList;
        }
        
        
        /// <summary>
        /// ライセンス表記が必要なライセンス一覧のHTMLを返す
        /// </summary>
        /// <returns></returns>
        public string GetLicenseConfigsHTML()
        {
            return rootRootConfig.GetLicenseHTML();
        }
        
        /// <summary>
        /// ライセンス表記が必要なライセンス一覧のMarkdownを返す
        /// </summary>
        /// <returns></returns>
        public string GetLicenseConfigsMarkdown()
        {
            return rootRootConfig.GetLicenseMarkdown();
        }

        /// <summary>
        /// ライセンス表記が必要なライセンス一覧のテキストを返す
        /// </summary>
        /// <returns></returns>
        public string GetLicenseConfigsTxt()
        {
            return rootRootConfig.GetLicenseRawTxt();
        }


    }
}