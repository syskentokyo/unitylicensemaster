using System;
using System.Collections.Generic;
using UnityEngine;

namespace SyskenTLib.LicenseMaster
{
    public enum LicenseType:int 
    {
        MIT=10,
        Apache=11,
        BSD3Clause=12,
        
        //UnityAssetStore系
        UnityAssetStoreSingleEntity=20,
        UnityAssetStoreMultiEntity=21,
        UnityAssetStoreSeat=22,
        /// <summary>
        /// UnityAssetStore(20200203まで）で古いライセンス状態の時に購入したタイプ
        /// </summary>
        UnityAssetStoreOld20200203=23,
        
        //クリエイティブ・コモンズ
        CC0=300,
        
        //フォント系
        SILOpenFontLicenseVersion1_1=400,
        
        //Mozilla系
        MozillaPublic=700,
        
        //GPL系
        GPL = 800,
        LGPL=801,
        AGPL=802,

        Other= 999,
        
    }

    public enum ChargeType:int
    {
        Unknown=0,
        Free=1,
        Paid_OneTimePurchase=2,
        Paid_Subscritption=3,
        
        /// <summary>
        /// 一人一つ購入するもの
        /// </summary>
        Paid_PurchaseForTheNumberOfUsers=10
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

        [Header("使用(依存）しているライブラリ一覧(UnityEditor上のみ有効）")]
        [SerializeField] private List<LicenseConfig> _useLicenseList=new List<LicenseConfig>();

        public List<LicenseConfig> GetUseLicenseList => _useLicenseList;

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
            
        [SerializeField] private ChargeType _chargeType = ChargeType.Unknown;
        public ChargeType GetChargeType=> _chargeType;
        
#if UNITY_EDITOR        
        [Header("========開発チームメンバー向け========")]    
        [Header("チームメンバーごとに追加アセット・シート購入が必要か？(UnityEditor上のみ有効）")] [SerializeField] private bool _isNeedToPurchaseForEachMember = false;
        public bool GetNeedToPurchaseForEachMember => _isNeedToPurchaseForEachMember; 
        
        [Header("チームメンバー全員がライブラリについて把握しておく必要があるか(UnityEditor上のみ有効）")] [SerializeField] private bool _isNeedAboutThisLibForEachMember = false;
        public bool GetIsNeedAboutThisLibForEachMember => _isNeedAboutThisLibForEachMember; 
#endif          
        
        [Header("========ライセンス表記系========")]    
        [Header("ライセンス表記が必要か？")] [SerializeField] private bool _isMustShowLicense = false;
        public bool GetIsMustShowLicense => _isMustShowLicense; 
        
        
        [Header("ライセンス表記する場合の表示優先度: 0:high 1000:low")] [Range(0, 1000)] [SerializeField]
        private int showLicenseOrder = 500;
        public int GetShowLicenseOrder => showLicenseOrder;
        
        [TextArea(minLines:4,maxLines:30)]
        [SerializeField] private string  _licenseShowText = "";
        public string GetLicenseShowText => _licenseShowText; 
        
        [Header("========その他========")]    
        [Header("カスタムパラメータ")]
        [TextArea(minLines:1,maxLines:100)]
        [SerializeField] private string  _customText1 = "";
        public string GetCustomText1 => _customText1;
        
        [TextArea(minLines:1,maxLines:100)]
        [SerializeField] private string  _customText2 = "";
        public string GetCustomText2 => _customText2; 

        
        

    }
}