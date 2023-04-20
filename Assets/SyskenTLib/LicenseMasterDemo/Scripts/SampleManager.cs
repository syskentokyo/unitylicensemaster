using System.Collections;
using System.Collections.Generic;
using SyskenTLib.LicenseMaster;
using UnityEngine;

namespace SyskenTLib.LicenseMasterDemo
{
    public class SampleManager : MonoBehaviour
    {
        [SerializeField] private LicenseManager _licenseManager;
        
        // Start is called before the first frame update
        void Start()
        {
            Debug.Log("HTML="+_licenseManager.GetLicenseConfigsHTML());
            
            Debug.Log("Markdown="+_licenseManager.GetLicenseConfigsMarkdown());
            
            Debug.Log("TXT="+_licenseManager.GetLicenseConfigsTxt());
            
            
            _licenseManager.GetLicenseConfigs().ForEach(config =>
            {
                Debug.Log("ライセンス："+config.GetLicenseType + " "+ config.GetLibrayName);
            });
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
