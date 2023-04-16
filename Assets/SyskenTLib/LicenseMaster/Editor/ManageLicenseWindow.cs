using System;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using System.Linq;
using SyskenTLib.LicenseMaster;
using UnityEngine.UI;

namespace SyskenTLib.LicenseMasterEditor
{
    public class ManageLicenseWindow : EditorWindow
    {
        private Vector2 _currentScroveViewPosition = Vector2.zero;

        private static LicenseUtil _licenseUtil = new LicenseUtil();


        [MenuItem("SyskenTLib/LicenseMaster/ManageLicense", priority = 30)]
        private static void ShowWindow()
        {
            var window = GetWindow<ManageLicenseWindow>();
            window.titleContent = new GUIContent("ManageLicense");
            window.Show();
        }
        
        [MenuItem("SyskenTLib/LicenseMaster/CreateConfig", priority = 130)]
        private static void AddConfigFile()
        {
            CreateConfig();
            UpdateRootConfig();
        }
        

        private void OnGUI()
        {
            //スクロール
            _currentScroveViewPosition = EditorGUILayout.BeginScrollView(_currentScroveViewPosition);

            EditorGUILayout.BeginVertical("Box");

            EditorGUILayout.Space(10);



            if (GUILayout.Button("CreateConfig", GUILayout.Width(300)))
            {
                CreateConfig();
                UpdateRootConfig();
            }

            EditorGUILayout.Space(50);

            EditorGUILayout.LabelField("Output License List");
            if (GUILayout.Button("OutputHtml", GUILayout.Width(300)))
            {
                UpdateRootConfig();
                List<LicenseConfig> currentAllConfigList = _licenseUtil.SortOrderConfig(SearchAllLicenceConfig());
                List<LicenseConfig> mustShowLicenseConfigOnlyList =
                    _licenseUtil.FilterOnlyMustShowLicenseConfig(currentAllConfigList);

                OutputFileFormatManager outputFileFormatManager = new OutputFileFormatManager();
                string rawHTMLText = outputFileFormatManager.GenerateHTML(mustShowLicenseConfigOnlyList);

                TextAsset textAsset = SearchHTMLAssetOnAllLicenceConfig();
                string filePath = AssetDatabase.GetAssetPath(textAsset);
                File.WriteAllText(filePath,rawHTMLText);
                EditorUtility.SetDirty(textAsset);
                AssetDatabase.SaveAssets();
                AssetDatabase.Refresh();
                
                

                Selection.activeObject = textAsset;//UnityEditor上で選択したことにする
                
                Debug.Log("Htmlを更新しました "+filePath);

            }
            

            EditorGUILayout.Space(10);
            if (GUILayout.Button("OutputMarkdown", GUILayout.Width(300)))
            {
                UpdateRootConfig();
                List<LicenseConfig> currentAllConfigList = _licenseUtil.SortOrderConfig(SearchAllLicenceConfig());
                List<LicenseConfig> mustShowLicenseConfigOnlyList =
                    _licenseUtil.FilterOnlyMustShowLicenseConfig(currentAllConfigList);

                OutputFileFormatManager outputFileFormatManager = new OutputFileFormatManager();
                string rawMarkdownText = outputFileFormatManager.GenerateMARKDOWN(mustShowLicenseConfigOnlyList);

                TextAsset textAsset = SearchMarkdownAssetOnAllLicenceConfig();
                string filePath = AssetDatabase.GetAssetPath(textAsset);
                File.WriteAllText(filePath,rawMarkdownText);
                EditorUtility.SetDirty(textAsset);
                AssetDatabase.SaveAssets();
                AssetDatabase.Refresh();
                
                Selection.activeObject = textAsset;//UnityEditor上で選択したことにする
                
                Debug.Log("Markdownを更新しました "+filePath);
            }

            EditorGUILayout.EndVertical();

            EditorGUILayout.EndScrollView();
        }

        private static LicenseRootConfig SearchAllRootConfig()
        {
            string[] guids = AssetDatabase.FindAssets("t:LicenseRootConfig");
            LicenseRootConfig rootConfig = null; 
            
            guids.ToList().ForEach(nextGUID =>
            {
                string filePath = AssetDatabase.GUIDToAssetPath(nextGUID);
                rootConfig= AssetDatabase.LoadAssetAtPath<LicenseRootConfig> (filePath);
                
            });
            
            return rootConfig;
        }
        
        private static LicenseOnlyShowRootConfig SearchOnlyShowRootConfig()
        {
            string[] guids = AssetDatabase.FindAssets("t:LicenseOnlyShowRootConfig");
            LicenseOnlyShowRootConfig rootConfig = null; 
            
            guids.ToList().ForEach(nextGUID =>
            {
                string filePath = AssetDatabase.GUIDToAssetPath(nextGUID);
                rootConfig= AssetDatabase.LoadAssetAtPath<LicenseOnlyShowRootConfig> (filePath);
                
            });
            
            return rootConfig;
        }
        

        private static List<LicenseConfig> SearchAllLicenceConfig()
        {
            List<LicenseConfig> licenseConfigList = new List<LicenseConfig>();

            string[] guids = AssetDatabase.FindAssets("t:LicenseConfig");
            guids.ToList().ForEach(nextGUID =>
            {
                string filePath = AssetDatabase.GUIDToAssetPath(nextGUID);
                licenseConfigList.Add( AssetDatabase.LoadAssetAtPath<LicenseConfig> (filePath));
                
            });
            
            return licenseConfigList;
        }
        
        
        private static TextAsset  SearchHTMLAssetOnAllLicenceConfig()
        {
            string[] guids = AssetDatabase.FindAssets("t:LicenseRootConfig");
            LicenseRootConfig rootConfig = null; 
            
            guids.ToList().ForEach(nextGUID =>
            {
                string filePath = AssetDatabase.GUIDToAssetPath(nextGUID);
                rootConfig= AssetDatabase.LoadAssetAtPath<LicenseRootConfig> (filePath);
                
            });

            return rootConfig.GetLicenseHTMLAsset();
        }
        
        private static TextAsset  SearchMarkdownAssetOnAllLicenceConfig()
        {
            string[] guids = AssetDatabase.FindAssets("t:LicenseRootConfig");
            LicenseRootConfig rootConfig = null; 
            
            guids.ToList().ForEach(nextGUID =>
            {
                string filePath = AssetDatabase.GUIDToAssetPath(nextGUID);
                rootConfig= AssetDatabase.LoadAssetAtPath<LicenseRootConfig> (filePath);
                
            });

            return rootConfig.GetLicenseMarkdownAsset();
        }

        private static void CreateConfig()
        {
            //選択する
            var selectDirpath = EditorUtility.OpenFolderPanel("Select Save Directory" ,
                Application.dataPath, string.Empty);
            if (string.IsNullOrEmpty(selectDirpath))
            {
                return;
            }
            else
            {
                string fileName = "licenseconfig" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".asset";
                string filePath = selectDirpath + "/" + fileName;
                filePath = filePath.Replace("\\", "/").Replace(Application.dataPath, "Assets");//相対パス

              
                LicenseConfig licenseConfig = ScriptableObject.CreateInstance<LicenseConfig> ();
                string createTimeText = DateTime.Now.ToString("yyyy/MM/dd_HH:mm:ss");
                licenseConfig.SetCreatedTimeText(createTimeText);

                AssetDatabase.CreateAsset(licenseConfig,filePath);
            }
        }

        private static void UpdateRootConfig()
        {
            //優先度順にソートして、設定をファイルを整理
            List<LicenseConfig> currentAllConfigList =  _licenseUtil.SortOrderConfig( SearchAllLicenceConfig());
            List<LicenseConfig> mustShowLicenseConfigList = _licenseUtil.FilterOnlyMustShowLicenseConfig(currentAllConfigList);

            
            //Unity上で確認用の設定整理
            LicenseRootConfig rootConfig = SearchAllRootConfig();
            rootConfig.SetLicenseList(currentAllConfigList);

            
            //アプリ用の設定整理
            LicenseOnlyShowRootConfig onlyShowRootConfig = SearchOnlyShowRootConfig();
            onlyShowRootConfig.SetLicenseList(mustShowLicenseConfigList);
            
            
            
            EditorUtility.SetDirty(rootConfig);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();

        }
    }
}