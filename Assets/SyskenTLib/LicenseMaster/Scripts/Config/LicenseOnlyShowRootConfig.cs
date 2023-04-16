using System.Collections.Generic;
using UnityEngine;

namespace SyskenTLib.LicenseMaster
{
  
    public class LicenseOnlyShowRootConfig : ScriptableObject
    {
        [Header("表示すべきライセンス")]
        [SerializeField] private List<LicenseConfig> _licenseMustShowConfigList;

        
        [Header("別形式")]
        [SerializeField] private TextAsset _licenseHtml;
        [SerializeField] private TextAsset _licenseMarkdown;
        [SerializeField] private TextAsset _licenseRawTxt;


        public List<LicenseConfig> GetLicenseList()
        {
            return _licenseMustShowConfigList;
        }

        public string GetLicenseHTML()
        {
            return _licenseHtml.text;
        }

        public string GetLicenseMarkdown()
        {
            return _licenseMarkdown.text;
        }
        
        public string GetLicenseRawTxt()
        {
            return _licenseRawTxt.text;
        }
        
        
#if UNITY_EDITOR
        public void SetLicenseList(List<LicenseConfig> configList)
        {
            _licenseMustShowConfigList=configList;
        }
#endif
    }
}