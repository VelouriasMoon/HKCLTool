using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using HKX2;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace HKCLTool
{
    public class ShouldSerializeContractResolver : DefaultContractResolver
    {
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            var property = base.CreateProperty(member, memberSerialization);

            if (property.PropertyName != null && property.PropertyName.StartsWith("m_"))
                property.PropertyName = property.PropertyName.Substring(2);
            if (property.PropertyName == "Signature") property.ShouldSerialize = instance => false;
            if (property.PropertyName == "IsIdentity") property.ShouldSerialize = instance => false;
            if (property.PropertyName == "Translation") property.ShouldSerialize = instance => false;

            return property;
        }
    }

    class Program
    {
        static List<string> ClothDataNameList = new List<string>();
        static List<hclClothData> newClothDatas = new List<hclClothData>();
        static List<hkaSkeleton> newSkeletons = new List<hkaSkeleton>();
        static hkRootLevelContainer hkclfile;

        static void Main(string[] args)
        {
            if (args.Length <= 0)
                Console.WriteLine("not enough arguments");
            else if (args[0] == "-l")
            {
                var hkfile = ReadHkclfile(args[1]);
                Listhkcl(hkfile);
            }
            else if (args[0] == "-json" || args[0] == "-hku" || args[0] == "-hknx")
            {
                if (args[1] == "-r")
                {
                    hkclfile = ReadHkclfile(args[2]);
                    RemoveCloth(hkclfile, Convert.ToInt32(args[3]));
                    ExportFile(hkclfile, args[0], args[2]);
                    Listhkcl(hkclfile);
                    return;
                }
                else
                {
                    if (args.Length <= 3)
                        Console.WriteLine("not enough arguments");

                    hkclfile = ReadHkclfile(args[1]);
                    var hk2 = ReadHkclfile(args[2]);

                    foreach (string indexes in args[3..])
                    {
                        try
                        {
                            Convert.ToInt32(indexes);
                        }
                        catch (FormatException e)
                        {
                            Console.WriteLine("invaild armuments");
                            return;
                        }
                        MergeHKCL(hkclfile, hk2, Convert.ToInt32(indexes));
                    }
                    ExportFile(hkclfile, args[0], args[1]);
                    //Listhkcl(hkclfile);
                    return;
                }
            }
            else if (args[0] == "--bonelist")
            {
                var hkfile = ReadHkclfile(args[1]);
                ListBones(hkfile);
            }
            else
                Console.WriteLine("invaild armuments");
        }

        private static readonly JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings
        {
            PreserveReferencesHandling = PreserveReferencesHandling.Objects,
            TypeNameHandling = TypeNameHandling.Auto,
            ContractResolver = new ShouldSerializeContractResolver(),
            Converters = new List<JsonConverter>
            {
                new StringEnumConverter()
            }
        };

        private static readonly Dictionary<string, short> BotwSectionOffsetForExtension =
            new Dictionary<string, short>
            {
                {"hkcl", 0},
                {"hkrg", 0},
                {"hkrb", 0},
                {"hktmrb", 16},
                {"hknm2", 16}
            };

        internal static IHavokObject ReadHKX(byte[] bytes)
        {
            var des = new PackFileDeserializer();
            var br = new BinaryReaderEx(bytes);

            return des.Deserialize(br);
        }

        private static hkRootLevelContainer ReadHkclfile(string infile)
        {
            if (Path.GetExtension(infile) == ".json")
            {
                var Json = (List<IHavokObject>)JsonConvert.DeserializeObject(File.ReadAllText(infile), typeof(List<IHavokObject>), jsonSerializerSettings);
                return (hkRootLevelContainer)Json[0];
            }
            else if (Path.GetExtension(infile) == ".hkcl")
            {
                return (hkRootLevelContainer)ReadHKX(File.ReadAllBytes(infile));
            }
            else
                return null;
        }

        internal static byte[] WriteHKX(IHavokObject root, HKXHeader header)
        {
            var s = new PackFileSerializer();
            var ms = new MemoryStream();
            var bw = new BinaryWriterEx(ms);
            s.Serialize(root, bw, header);
            return ms.ToArray();
        }

        public static byte[] WriteBotwHKX(IReadOnlyList<IHavokObject> roots, string extension, HKXHeader header)
        {
            var root = roots[0];
            header.SectionOffset = BotwSectionOffsetForExtension[extension];
            var writtenRoot = WriteHKX(root, header);
            return writtenRoot;
        }

        internal static void MergeHKCL(hkRootLevelContainer hkfile, hkRootLevelContainer hkfile2, int index)
        {
            //Load key data from the second json into list for later
            foreach (var namedVariant in hkfile2.m_namedVariants)
            {
                if (namedVariant.m_className == "hclClothContainer")
                    ManageCloth(namedVariant);
                if (namedVariant.m_className == "hkaAnimationContainer")
                    ManageSkeleton(namedVariant);
            }

            foreach (var namedVariant in hkfile.m_namedVariants)
            {
                if (namedVariant.m_className == "hclClothContainer")
                {
                    //load the current cloth datas and add the list one to the list
                    hclClothContainer newCloth = (hclClothContainer)namedVariant.m_variant;
                    newCloth.m_clothDatas.Add(newClothDatas[index]);

                    //read the collidabiles in the new cloth data and add them if they don't already exist
                    var simcloth = newClothDatas[index].m_simClothDatas;
                    foreach (var simClothData in simcloth)
                    {
                        foreach (var collide in simClothData.m_perInstanceCollidables)
                        {
                            if (!newCloth.m_collidables.Contains(collide))
                            {
                                newCloth.m_collidables.Add(collide);
                            }
                        }
                    }

                    //replace the existing cloth data container with the new edited one
                    namedVariant.m_variant = newCloth;
                }
                if (namedVariant.m_className == "hkaAnimationContainer")
                {
                    //add the new skeleton to the animation container, index should be the same as the cloth data
                    hkaAnimationContainer newskele = (hkaAnimationContainer)namedVariant.m_variant;
                    newskele.m_skeletons.Add(newSkeletons[index]);
                    namedVariant.m_variant = newskele;
                }
            }

            hkclfile = hkfile;
        }

        private static void ManageCloth(hkRootLevelContainerNamedVariant hknamed)
        {
            hclClothContainer ClothData = (hclClothContainer)hknamed.m_variant;

            foreach (var clothdatas in ClothData.m_clothDatas)
            {
                ClothDataNameList.Add(clothdatas.m_name);
                newClothDatas.Add(clothdatas);
            }
        }

        private static void ManageSkeleton(hkRootLevelContainerNamedVariant hknamed)
        {
            hkaAnimationContainer skele = (hkaAnimationContainer)hknamed.m_variant;

            foreach (var skeleton in skele.m_skeletons)
            {
                //SkeleNameList.Add(skeleton.m_name);
                newSkeletons.Add(skeleton);
            }
        }

        private static void ExportFile(hkRootLevelContainer hkfile, string outformat, string outpath)
        {
            outpath = outpath.Replace(Path.GetExtension(outpath), "");

            if (outformat == "-json")
            {
                if (File.Exists(outpath + ".json"))
                    File.Delete(outpath + ".json");

                var jsonfile = JsonConvert.SerializeObject(new List<IHavokObject> { hkfile }, jsonSerializerSettings);
                File.WriteAllText(outpath + ".json", jsonfile);
            }
            else
            {
                HKXHeader header;
                if (outformat == "-hknx")
                    header = HKXHeader.BotwNx();
                else
                    header = HKXHeader.BotwWiiu();

                if (File.Exists(outpath + ".hkcl"))
                    File.Delete(outpath + ".hkcl");

                File.WriteAllBytes(outpath + ".hkcl", WriteBotwHKX(new List<IHavokObject> { hkfile }, "hkcl", header));
            }
        }

        private static void Listhkcl(hkRootLevelContainer hkfile)
        {
            var namedVariant = hkfile.m_namedVariants[0];

            if (namedVariant.m_className == "hclClothContainer")
            {
                hclClothContainer ClothData = (hclClothContainer)namedVariant.m_variant;

                foreach (var clothdatas in ClothData.m_clothDatas)
                {
                    ClothDataNameList.Add(clothdatas.m_name);
                }
            }

            int i = 0;
            foreach (string name in ClothDataNameList)
            {
                Console.WriteLine($"{i}: {name}");
                i++;
            }
        }

        private static void ListBones(hkRootLevelContainer hkfile)
        {
            foreach (var namedVariant in hkfile.m_namedVariants)
            {
                if (namedVariant.m_className == "hkaAnimationContainer")
                {
                    hkaAnimationContainer skele = (hkaAnimationContainer)namedVariant.m_variant;

                    foreach (var skeleton in skele.m_skeletons)
                    {
                        Console.WriteLine(skeleton.m_name);

                        foreach (var bone in skeleton.m_bones)
                        {
                            Console.WriteLine($"\t{bone.m_name}");
                        }
                    }
                }
            }
        }

        private static void RemoveCloth(hkRootLevelContainer hkfile, int index)
        {
            foreach (var namedVariant in hkfile.m_namedVariants)
            {
                if (namedVariant.m_className == "hclClothContainer")
                {
                    hclClothContainer Cloth = (hclClothContainer)namedVariant.m_variant;
                    Cloth.m_clothDatas.RemoveAt(index);
                    namedVariant.m_variant = Cloth;
                }
                if (namedVariant.m_className == "hkaAnimationContainer")
                {
                    hkaAnimationContainer skeleton = (hkaAnimationContainer)namedVariant.m_variant;
                    skeleton.m_skeletons.RemoveAt(index);
                    namedVariant.m_variant = skeleton;
                }
            }
            hkclfile = hkfile;
        }
    }
}
