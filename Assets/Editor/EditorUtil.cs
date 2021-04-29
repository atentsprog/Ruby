using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class EditorUtil
{
    private class SpriteInfo
    {
        public Sprite sprite;
        public int seq;

        public SpriteInfo(Sprite item, int seq)
        {
            this.sprite = item;
            this.seq = seq;
        }
    }

    private class MakeAniInfo
    {
        public string groupName;
        public List<SpriteInfo> sprites = new List<SpriteInfo>();
        public string animationFilePath;
    }

    /// <summary>
    /// 텍스쳐나 스프라이트 목록을 애니메이션으로 생성
    /// </summary>
    [MenuItem("Assets/Tool/Make Animation", false, 1)]
    public static void SvnLogSelected()
    {
        List<Sprite> sprites = new List<Sprite>(Selection.objects.Length);
        foreach (var item in Selection.objects)
        {
            string path = AssetDatabase.GetAssetPath(item.GetInstanceID());

            if (Directory.Exists(path))
            {
                string[] files = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories);
                foreach (var file in files)
                {
                    if (file.EndsWith(".meta"))
                        continue;

                    Sprite sprite1 = AssetDatabase.LoadAssetAtPath<Sprite>(file);
                    if (sprite1 == null)
                        continue;

                    sprites.Add(sprite1);
                }
                continue;
            }

            Sprite sprite = null;
            if (item is Sprite)
                sprite = (Sprite)item;
            else
            {
                Texture2D texture = (Texture2D)item;
                if (texture == null)
                    continue;
                sprite = AssetDatabase.LoadAssetAtPath<Sprite>(AssetDatabase.GetAssetPath(texture));
            }
            if (sprite == null)
                continue;

            sprites.Add(sprite);
        }

        // 폴더 선택했는지, 파일 선택했는지
        // 그룹으로 나누기 -> 네이밍 정해져 있어야함. ex)숫자로 구분, _언더바로 구분
        // 애니메이션 만들어질 경로 ( 애니메이션 파일 이름 포함)

        // 그룹 나누기
        Dictionary<string, MakeAniInfo> aniInfo = new Dictionary<string, MakeAniInfo>();  // <그룹이름, 애니메이션 정보>
        foreach (var item in sprites)
        {
            string filename;
            string assetFullPath = AssetDatabase.GetAssetPath(item);

            filename = (item is Sprite) ? item.name : Path.GetFileNameWithoutExtension(assetFullPath);

            int seq = -1;
            // filename 에서 언더바로 구분하거나, 숫자로 구분해야함.
            string groupName;
            if (filename.IndexOf("_") > 0)
            {
                // _ 가 있음.
                string[] tempStr = filename.Split('_');
                groupName = tempStr[0];
                seq = int.Parse(tempStr[1]);
            }
            else
            {
                // 숫자로 구분.
                int firstNumberIndex = filename.IndexOfAny("0123456789".ToCharArray());

                groupName = filename.Substring(0, firstNumberIndex);

                string number = filename.Substring(firstNumberIndex, filename.Length - firstNumberIndex);

                bool result = int.TryParse(number, out int i); //i now = 108
                if (result == false)
                    continue;

                seq = i;
            }

            // 새로생성되는 폴더 위치를 지정
            if (aniInfo.ContainsKey(groupName) == false)
            {
                aniInfo[groupName] = new MakeAniInfo();
                aniInfo[groupName].groupName = groupName;
                aniInfo[groupName].animationFilePath = $"{Path.GetDirectoryName(assetFullPath)}\\{groupName}.anim";
            }
            aniInfo[groupName].sprites.Add(new SpriteInfo(item, seq));
        }

        // aniInfo seq  대로 정렬.
        foreach (var item in aniInfo)
        {
            item.Value.sprites.Sort(
            delegate (SpriteInfo p1, SpriteInfo p2)
            {
                return (p1.seq.CompareTo(p2.seq));
            });
        }

        EditorCurveBinding spriteBinding = new EditorCurveBinding();
        spriteBinding.type = typeof(SpriteRenderer);
        spriteBinding.path = "";
        spriteBinding.propertyName = "m_Sprite";

        // 애니메이션 만들기
        foreach (var item in aniInfo)
        {
            var makeInfo = item.Value;
            var spriteInfo = makeInfo.sprites;
            ObjectReferenceKeyframe[] spriteKeyFrames = new ObjectReferenceKeyframe[spriteInfo.Count];
            for (int i = 0; i < (spriteInfo.Count); i++)
            {
                spriteKeyFrames[i] = new ObjectReferenceKeyframe();
                spriteKeyFrames[i].time = i;
                spriteKeyFrames[i].value = spriteInfo[i].sprite;
            }

            AnimationClip animClip = new AnimationClip();
            animClip.frameRate = 30;   // FPS
            AnimationUtility.SetObjectReferenceCurve(animClip, spriteBinding, spriteKeyFrames);

            AssetDatabase.CreateAsset(animClip, makeInfo.animationFilePath);
        }
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }
}