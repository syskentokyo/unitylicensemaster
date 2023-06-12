using System;
using UnityEngine;

namespace SyskenTLib.LicenseMaster
{
    public enum LicenseType:int 
    {
        MIT=10,
        Apache=11,
        BSD3Clause=12,
        
        UnityAssetStoreSingleEntity=20,
        UnityAssetStoreMultiEntity=21,
        UnityAssetStoreSeat=22,
        UnityAssetStoreOld20200203=23,
        
        CC0=300,
        
        MozillaPublic=700,
        
        GPL = 800,
        LGPL=801,
        AGPL=802,

        Other= 999,
        
    }
    
    
    public class LicenseConfig : ScriptableObject
    {


        
        
        [Header("ライブラリ名")]
        [SerializeField] private string  _libraryName = "";
        public string GetLibrayName => _libraryName; 
        
        
#if UNITY_EDITOR
        [Space(10)]
        [Header("メモ(UnityEditor上のみ有効）")]
        [TextArea(minLines:4,maxLines:100)]
        [SerializeField] private string  _memo1 = "";
        public string GetMemo1 => _memo1; 
        
        [Space(10)]
        [Header("Version(UnityEditor上のみ有効）")]
        [TextArea(minLines:1,maxLines:2)]
        [SerializeField] private string  _libversion = "None";
        public string GetLibVersion => _libversion;
        
        [Space(10)]
        [Header("WebPageURL(UnityEditor上のみ有効）")]
        [TextArea(minLines:1,maxLines:2)]
        [SerializeField] private string  _webURL1 = "";
        public string GetWebURL1 => _webURL1;
        
        [TextArea(minLines:1,maxLines:2)]
        [SerializeField] private string  _webURL2 = "";
        public string GetWebURL2 => _webURL2; 

#endif

        [Space(10)]
        [Header("作成日時")]
        [SerializeField] private string _createdTimeText;
        public string GetCreatedTimeText => _createdTimeText; 
        #if UNITY_EDITOR
        public void SetCreatedTimeText(string createTimeText)
        {
            _createdTimeText = createTimeText;
        }
        #endif
        
        
            [Space(10)]
        [Header("ライセンス")]
        [SerializeField] private LicenseType _licenseType = LicenseType.Other;
            public LicenseType GetLicenseType=> _licenseType; 
            
            
        [Header("ライセンス表記が必要か？")] [SerializeField] private bool _isMustShowLicense = false;
        public bool GetIsMustShowLicense => _isMustShowLicense; 
        
        
        [Header("ライセンス表記する場合の優先度: 0:high 1000:low")] [Range(0, 1000)] [SerializeField]
        private int showLicenseOrder = 500;
        public int GetShowLicenseOrder => showLicenseOrder;
        
        [Header("カスタムパラメータ")]
        [TextArea(minLines:1,maxLines:100)]
        [SerializeField] private string  _customText1 = "";
        public string GetCustomText1 => _customText1;
        
        [TextArea(minLines:1,maxLines:100)]
        [SerializeField] private string  _customText2 = "";
        public string GetCustomText2 => _customText2; 
        
        
        [Header("ライセンスの表示内容")]
        [TextArea(minLines:4,maxLines:100)]
        [SerializeField] private string  _licenseShowText = "";
        public string GetLicenseShowText => _licenseShowText; 
        
        

    }
}