using System.Collections.Generic;
using SyskenTLib.LicenseMaster;
using UnityEngine;

namespace SyskenTLib.LicenseMasterEditor
{
    public class LicenseRootConfig : ScriptableObject
    {
        [Header("すべてのライセンス")]
        [SerializeField] private List<LicenseConfig> _licenseAllConfigList;

        
        [Header("別形式")]
        [SerializeField] private TextAsset _licenseHtml;
        [SerializeField] private TextAsset _licenseMarkdown;
        [SerializeField] private TextAsset _licenseRawTxt;

        public List<LicenseConfig> GetLicenseList()
        {
            return _licenseAllConfigList;
        }
        
        public TextAsset GetLicenseHTMLAsset()
        {
            return _licenseHtml;
        }

        public string GetLicenseHTML()
        {
            return _licenseHtml.text;
        }

        public TextAsset GetLicenseMarkdownAsset()
        {
            return _licenseMarkdown;
        }
        
        public string GetLicenseMarkdown()
        {
            return _licenseMarkdown.text;
        }
        
        public TextAsset GetLicenseRawTxtAsset()
        {
            return _licenseRawTxt;
        }
        
        public string GetLicenseRawTxt()
        {
            return _licenseRawTxt.text;
        }
        
        
        #if UNITY_EDITOR
        public void SetLicenseList(List<LicenseConfig> configList)
        {
            _licenseAllConfigList=configList;
        }
        #endif
    }
}