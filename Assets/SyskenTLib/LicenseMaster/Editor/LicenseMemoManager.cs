using System;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using SyskenTLib.LicenseMaster;

namespace SyskenTLib.LicenseMasterEditor
{
    public class LicenseMemoManager
    {
         #region 各々のライセンスメモ

        public  List<string>  GenerateEachLicenseMemo(List<LicenseConfig> configList)
        {
            OutputTemplateFileManager fileTemplateManager = new OutputTemplateFileManager();
            OutputTemplate outputTemplate = fileTemplateManager.SearchOutputTemplate();


            List<string> filePathList = new List<string>();
            

            configList.ForEach(config =>
            {
                string resultText = "";

                //タイトルとスペシャルサンクス
                resultText += "LicenseMasterで自動作成されました。"+"\n";
                resultText += "\nメモ更新日時："+DateTime.Now.ToString("yyyy/MM/dd_HH:mm:ss") +"\n";
                
                //ライブラリ名
                resultText += "\n"+outputTemplate._markdownLibTitleText.Replace(outputTemplate._replaceTargetTextDefine,config.GetLibrayName);

                resultText += "\n\n" + "* メモ１：" + "\n";
                resultText += "\n```\n" + "" + config.GetMemo1+"\n```\n";
                
                resultText += "\n* " + "追加日：" + config.GetCreatedTimeText;
                resultText += "\n* " + "ライセンス：" + config.GetLicenseType;
                resultText += "\n* " + "ライセンス表記が必要？：" + config.GetIsMustShowLicense;
                resultText += "\n* " + "バージョン：" + config.GetLibVersion;
                resultText += "\n* " + "WebURL1：" + config.GetWebURL1;
                resultText += "\n* " + "WebURL2：" + config.GetWebURL2;
                resultText += "\n* " + "カスタム１：" + config.GetCustomText1;
                resultText += "\n* " + "カスタム2：" + config.GetCustomText2;

                //ライセンス表示内容
                resultText += "\n\n"+outputTemplate._markdownLibContentText.Replace(outputTemplate._replaceTargetTextDefine,config.GetLicenseShowText);


                resultText += "\n";


                string configFilePath = AssetDatabase.GetAssetPath(config);
                string memoFilePath = System.IO.Path.GetDirectoryName(configFilePath)+"/"+"licenseMemo.md";

                if (File.Exists(memoFilePath) == false)
                {
                    //
                    //ファイルがなかったときのみ作成する
                    //
                    //ファイル保存
                    File.WriteAllText(memoFilePath, resultText);
                    
                    
                    filePathList.Add(memoFilePath);
                }
            });
            
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();

            
            return filePathList;
        }

        #endregion
    }
}