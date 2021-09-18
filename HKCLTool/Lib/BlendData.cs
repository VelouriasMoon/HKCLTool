using System.Collections.Generic;
using HKX2;

namespace HKCLTool.Lib
{
    public class BlendData
    {
        public List<BlendEntry> blendEntries { get; set; }

        public BlendData Read(hclObjectSpaceSkinPOperator Skin)
        {
            BlendData blend = new BlendData();

            if (Skin.m_objectSpaceDeformer.m_fourBlendEntries.Count > 0)
            {
                foreach (var eb in Skin.m_objectSpaceDeformer.m_fourBlendEntries)
                {
                    List<BlendEntry> blendEntries = new List<BlendEntry>();

                    //entry blocks are set sizes of 16 verts, 16*(blend size) bones and 16*(blend size) weights
                    //entry blocks store each element as a sperate vaule the can't be enumerated because fuck you

                    blendEntries.Add(new BlendEntry() { 
                        Vertex = eb.m_vertexIndices_0, SkinCount = 4,
                        Bone_1 = eb.m_boneIndices_0, Bone_2 = eb.m_boneIndices_1, Bone_3 = eb.m_boneIndices_2, Bone_4 = eb.m_boneIndices_3,
                        Weight_1 = eb.m_boneWeights_0, Weight_2 = eb.m_boneWeights_1, Weight_3 = eb.m_boneWeights_2, Weight_4 = eb.m_boneWeights_3,
                    });
                    blendEntries.Add(new BlendEntry() { 
                        Vertex = eb.m_vertexIndices_1, SkinCount = 4,
                        Bone_1 = eb.m_boneIndices_4, Bone_2 = eb.m_boneIndices_5, Bone_3 = eb.m_boneIndices_6, Bone_4 = eb.m_boneIndices_7,
                        Weight_1 = eb.m_boneWeights_4, Weight_2 = eb.m_boneWeights_5, Weight_3 = eb.m_boneWeights_6, Weight_4 = eb.m_boneWeights_7,
                    });
                    blendEntries.Add(new BlendEntry() { 
                        Vertex = eb.m_vertexIndices_2, SkinCount = 4,
                        Bone_1 = eb.m_boneIndices_8, Bone_2 = eb.m_boneIndices_9, Bone_3 = eb.m_boneIndices_10, Bone_4 = eb.m_boneIndices_11,
                        Weight_1 = eb.m_boneWeights_8, Weight_2 = eb.m_boneWeights_9, Weight_3 = eb.m_boneWeights_10, Weight_4 = eb.m_boneWeights_11,
                    });
                    blendEntries.Add(new BlendEntry() { 
                        Vertex = eb.m_vertexIndices_3, SkinCount = 4,
                        Bone_1 = eb.m_boneIndices_12, Bone_2 = eb.m_boneIndices_13, Bone_3 = eb.m_boneIndices_14, Bone_4 = eb.m_boneIndices_15,
                        Weight_1 = eb.m_boneWeights_12, Weight_2 = eb.m_boneWeights_13, Weight_3 = eb.m_boneWeights_14, Weight_4 = eb.m_boneWeights_15,
                    });
                    blendEntries.Add(new BlendEntry() { 
                        Vertex = eb.m_vertexIndices_4,
                        SkinCount = 4,
                        Bone_1 = eb.m_boneIndices_16, Bone_2 = eb.m_boneIndices_17, Bone_3 = eb.m_boneIndices_18, Bone_4 = eb.m_boneIndices_19,
                        Weight_1 = eb.m_boneWeights_16, Weight_2 = eb.m_boneWeights_17, Weight_3 = eb.m_boneWeights_18, Weight_4 = eb.m_boneWeights_19,
                    });
                    blendEntries.Add(new BlendEntry() { 
                        Vertex = eb.m_vertexIndices_5,
                        SkinCount = 4,
                        Bone_1 = eb.m_boneIndices_20, Bone_2 = eb.m_boneIndices_21, Bone_3 = eb.m_boneIndices_22, Bone_4 = eb.m_boneIndices_23,
                        Weight_1 = eb.m_boneWeights_20, Weight_2 = eb.m_boneWeights_21, Weight_3 = eb.m_boneWeights_22, Weight_4 = eb.m_boneWeights_23,
                    });
                    blendEntries.Add(new BlendEntry() { 
                        Vertex = eb.m_vertexIndices_6,
                        SkinCount = 4,
                        Bone_1 = eb.m_boneIndices_24, Bone_2 = eb.m_boneIndices_25, Bone_3 = eb.m_boneIndices_26, Bone_4 = eb.m_boneIndices_27,
                        Weight_1 = eb.m_boneWeights_24, Weight_2 = eb.m_boneWeights_25, Weight_3 = eb.m_boneWeights_26, Weight_4 = eb.m_boneWeights_27,
                    });
                    blendEntries.Add(new BlendEntry() { 
                        Vertex = eb.m_vertexIndices_7,
                        SkinCount = 4,
                        Bone_1 = eb.m_boneIndices_28, Bone_2 = eb.m_boneIndices_29, Bone_3 = eb.m_boneIndices_30, Bone_4 = eb.m_boneIndices_31,
                        Weight_1 = eb.m_boneWeights_28, Weight_2 = eb.m_boneWeights_29, Weight_3 = eb.m_boneWeights_30, Weight_4 = eb.m_boneWeights_31,
                    });
                    blendEntries.Add(new BlendEntry() { 
                        Vertex = eb.m_vertexIndices_8,
                        SkinCount = 4,
                        Bone_1 = eb.m_boneIndices_32, Bone_2 = eb.m_boneIndices_33, Bone_3 = eb.m_boneIndices_34, Bone_4 = eb.m_boneIndices_35,
                        Weight_1 = eb.m_boneWeights_32, Weight_2 = eb.m_boneWeights_33, Weight_3 = eb.m_boneWeights_34, Weight_4 = eb.m_boneWeights_35,
                    });
                    blendEntries.Add(new BlendEntry() { 
                        Vertex = eb.m_vertexIndices_9,
                        SkinCount = 4,
                        Bone_1 = eb.m_boneIndices_36, Bone_2 = eb.m_boneIndices_37, Bone_3 = eb.m_boneIndices_38, Bone_4 = eb.m_boneIndices_39,
                        Weight_1 = eb.m_boneWeights_36, Weight_2 = eb.m_boneWeights_37, Weight_3 = eb.m_boneWeights_38, Weight_4 = eb.m_boneWeights_39,
                    });
                    blendEntries.Add(new BlendEntry() { 
                        Vertex = eb.m_vertexIndices_10,
                        SkinCount = 4,
                        Bone_1 = eb.m_boneIndices_40, Bone_2 = eb.m_boneIndices_41, Bone_3 = eb.m_boneIndices_42, Bone_4 = eb.m_boneIndices_43,
                        Weight_1 = eb.m_boneWeights_40, Weight_2 = eb.m_boneWeights_41, Weight_3 = eb.m_boneWeights_42, Weight_4 = eb.m_boneWeights_43,
                    });
                    blendEntries.Add(new BlendEntry() { 
                        Vertex = eb.m_vertexIndices_11,
                        SkinCount = 4,
                        Bone_1 = eb.m_boneIndices_44, Bone_2 = eb.m_boneIndices_45, Bone_3 = eb.m_boneIndices_46, Bone_4 = eb.m_boneIndices_47,
                        Weight_1 = eb.m_boneWeights_44, Weight_2 = eb.m_boneWeights_45, Weight_3 = eb.m_boneWeights_46, Weight_4 = eb.m_boneWeights_47,
                    });
                    blendEntries.Add(new BlendEntry() { 
                        Vertex = eb.m_vertexIndices_12,
                        SkinCount = 4,
                        Bone_1 = eb.m_boneIndices_48, Bone_2 = eb.m_boneIndices_49, Bone_3 = eb.m_boneIndices_50, Bone_4 = eb.m_boneIndices_51,
                        Weight_1 = eb.m_boneWeights_48, Weight_2 = eb.m_boneWeights_49, Weight_3 = eb.m_boneWeights_50, Weight_4 = eb.m_boneWeights_51,
                    });
                    blendEntries.Add(new BlendEntry() { 
                        Vertex = eb.m_vertexIndices_13,
                        SkinCount = 4,
                        Bone_1 = eb.m_boneIndices_52, Bone_2 = eb.m_boneIndices_53, Bone_3 = eb.m_boneIndices_54, Bone_4 = eb.m_boneIndices_55,
                        Weight_1 = eb.m_boneWeights_52, Weight_2 = eb.m_boneWeights_53, Weight_3 = eb.m_boneWeights_54, Weight_4 = eb.m_boneWeights_55,
                    });
                    blendEntries.Add(new BlendEntry() { 
                        Vertex = eb.m_vertexIndices_14,
                        SkinCount = 4,
                        Bone_1 = eb.m_boneIndices_56, Bone_2 = eb.m_boneIndices_57, Bone_3 = eb.m_boneIndices_58, Bone_4 = eb.m_boneIndices_59,
                        Weight_1 = eb.m_boneWeights_56, Weight_2 = eb.m_boneWeights_57, Weight_3 = eb.m_boneWeights_58, Weight_4 = eb.m_boneWeights_59,
                    });
                    blendEntries.Add(new BlendEntry() { 
                        Vertex = eb.m_vertexIndices_15,
                        SkinCount = 4,
                        Bone_1 = eb.m_boneIndices_60, Bone_2 = eb.m_boneIndices_61, Bone_3 = eb.m_boneIndices_62, Bone_4 = eb.m_boneIndices_63,
                        Weight_1 = eb.m_boneWeights_60, Weight_2 = eb.m_boneWeights_61, Weight_3 = eb.m_boneWeights_62, Weight_4 = eb.m_boneWeights_63,
                    });

                    if (blend.blendEntries == null || blend.blendEntries.Count <= 0)
                        blend.blendEntries = blendEntries;
                    else
                    {
                        foreach (var entry in blendEntries)
                        {
                            blend.blendEntries.Add(entry);
                        }
                    }
                }
            }

            if (Skin.m_objectSpaceDeformer.m_threeBlendEntries.Count > 0)
            {
                foreach (var eb in Skin.m_objectSpaceDeformer.m_threeBlendEntries)
                {
                    List<BlendEntry> blendEntries = new List<BlendEntry>();

                    blendEntries.Add(new BlendEntry() { 
                        Vertex = eb.m_vertexIndices_0, SkinCount = 3,
                        Bone_1 = eb.m_boneIndices_0, Bone_2 = eb.m_boneIndices_1, Bone_3 = eb.m_boneIndices_2,
                        Weight_1 = eb.m_boneWeights_0, Weight_2 = eb.m_boneWeights_1, Weight_3 = eb.m_boneWeights_2,
                    });
                    blendEntries.Add(new BlendEntry() { 
                        Vertex = eb.m_vertexIndices_1,
                        SkinCount = 3,
                        Bone_1 = eb.m_boneIndices_3, Bone_2 = eb.m_boneIndices_4, Bone_3 = eb.m_boneIndices_5,
                        Weight_1 = eb.m_boneWeights_3, Weight_2 = eb.m_boneWeights_4, Weight_3 = eb.m_boneWeights_5,
                    });
                    blendEntries.Add(new BlendEntry() { 
                        Vertex = eb.m_vertexIndices_2,
                        SkinCount = 3,
                        Bone_1 = eb.m_boneIndices_6, Bone_2 = eb.m_boneIndices_7, Bone_3 = eb.m_boneIndices_8,
                        Weight_1 = eb.m_boneWeights_6, Weight_2 = eb.m_boneWeights_7, Weight_3 = eb.m_boneWeights_8,
                    });
                    blendEntries.Add(new BlendEntry() { 
                        Vertex = eb.m_vertexIndices_3,
                        SkinCount = 3,
                        Bone_1 = eb.m_boneIndices_9, Bone_2 = eb.m_boneIndices_10, Bone_3 = eb.m_boneIndices_11,
                        Weight_1 = eb.m_boneWeights_9, Weight_2 = eb.m_boneWeights_10, Weight_3 = eb.m_boneWeights_11,
                    });
                    blendEntries.Add(new BlendEntry() { 
                        Vertex = eb.m_vertexIndices_4,
                        SkinCount = 3,
                        Bone_1 = eb.m_boneIndices_12, Bone_2 = eb.m_boneIndices_13, Bone_3 = eb.m_boneIndices_14,
                        Weight_1 = eb.m_boneWeights_12, Weight_2 = eb.m_boneWeights_13, Weight_3 = eb.m_boneWeights_14,
                    });
                    blendEntries.Add(new BlendEntry() { 
                        Vertex = eb.m_vertexIndices_5,
                        SkinCount = 3,
                        Bone_1 = eb.m_boneIndices_15, Bone_2 = eb.m_boneIndices_16, Bone_3 = eb.m_boneIndices_17,
                        Weight_1 = eb.m_boneWeights_15, Weight_2 = eb.m_boneWeights_16, Weight_3 = eb.m_boneWeights_17,
                    });
                    blendEntries.Add(new BlendEntry() { 
                        Vertex = eb.m_vertexIndices_6,
                        SkinCount = 3,
                        Bone_1 = eb.m_boneIndices_18, Bone_2 = eb.m_boneIndices_19, Bone_3 = eb.m_boneIndices_20,
                        Weight_1 = eb.m_boneWeights_18, Weight_2 = eb.m_boneWeights_19, Weight_3 = eb.m_boneWeights_20,
                    });
                    blendEntries.Add(new BlendEntry() { 
                        Vertex = eb.m_vertexIndices_7,
                        SkinCount = 3,
                        Bone_1 = eb.m_boneIndices_21, Bone_2 = eb.m_boneIndices_22, Bone_3 = eb.m_boneIndices_23,
                        Weight_1 = eb.m_boneWeights_21, Weight_2 = eb.m_boneWeights_22, Weight_3 = eb.m_boneWeights_23,
                    });
                    blendEntries.Add(new BlendEntry() { 
                        Vertex = eb.m_vertexIndices_8,
                        SkinCount = 3,
                        Bone_1 = eb.m_boneIndices_24, Bone_2 = eb.m_boneIndices_25, Bone_3 = eb.m_boneIndices_26,
                        Weight_1 = eb.m_boneWeights_24, Weight_2 = eb.m_boneWeights_25, Weight_3 = eb.m_boneWeights_26,
                    });
                    blendEntries.Add(new BlendEntry() { 
                        Vertex = eb.m_vertexIndices_9,
                        SkinCount = 3,
                        Bone_1 = eb.m_boneIndices_27, Bone_2 = eb.m_boneIndices_28, Bone_3 = eb.m_boneIndices_29,
                        Weight_1 = eb.m_boneWeights_27, Weight_2 = eb.m_boneWeights_28, Weight_3 = eb.m_boneWeights_29,
                    });
                    blendEntries.Add(new BlendEntry() { 
                        Vertex = eb.m_vertexIndices_10,
                        SkinCount = 3,
                        Bone_1 = eb.m_boneIndices_30, Bone_2 = eb.m_boneIndices_31, Bone_3 = eb.m_boneIndices_32,
                        Weight_1 = eb.m_boneWeights_30, Weight_2 = eb.m_boneWeights_31, Weight_3 = eb.m_boneWeights_32,
                    });
                    blendEntries.Add(new BlendEntry() { 
                        Vertex = eb.m_vertexIndices_11,
                        SkinCount = 3,
                        Bone_1 = eb.m_boneIndices_33, Bone_2 = eb.m_boneIndices_34, Bone_3 = eb.m_boneIndices_35,
                        Weight_1 = eb.m_boneWeights_33, Weight_2 = eb.m_boneWeights_34, Weight_3 = eb.m_boneWeights_35,
                    });
                    blendEntries.Add(new BlendEntry() { 
                        Vertex = eb.m_vertexIndices_12,
                        SkinCount = 3,
                        Bone_1 = eb.m_boneIndices_36, Bone_2 = eb.m_boneIndices_37, Bone_3 = eb.m_boneIndices_38,
                        Weight_1 = eb.m_boneWeights_36, Weight_2 = eb.m_boneWeights_37, Weight_3 = eb.m_boneWeights_38,
                    });
                    blendEntries.Add(new BlendEntry() { 
                        Vertex = eb.m_vertexIndices_13,
                        SkinCount = 3,
                        Bone_1 = eb.m_boneIndices_39, Bone_2 = eb.m_boneIndices_40, Bone_3 = eb.m_boneIndices_41,
                        Weight_1 = eb.m_boneWeights_39, Weight_2 = eb.m_boneWeights_40, Weight_3 = eb.m_boneWeights_41,
                    });
                    blendEntries.Add(new BlendEntry() { 
                        Vertex = eb.m_vertexIndices_14,
                        SkinCount = 3,
                        Bone_1 = eb.m_boneIndices_42, Bone_2 = eb.m_boneIndices_43, Bone_3 = eb.m_boneIndices_44,
                        Weight_1 = eb.m_boneWeights_42, Weight_2 = eb.m_boneWeights_43, Weight_3 = eb.m_boneWeights_44,
                    });
                    blendEntries.Add(new BlendEntry() { 
                        Vertex = eb.m_vertexIndices_15,
                        SkinCount = 3,
                        Bone_1 = eb.m_boneIndices_45, Bone_2 = eb.m_boneIndices_46, Bone_3 = eb.m_boneIndices_47,
                        Weight_1 = eb.m_boneWeights_45, Weight_2 = eb.m_boneWeights_46, Weight_3 = eb.m_boneWeights_47,
                    });


                    if (blend.blendEntries == null || blend.blendEntries.Count <= 0)
                        blend.blendEntries = blendEntries;
                    else
                    {
                        foreach (var entry in blendEntries)
                        {
                            blend.blendEntries.Add(entry);
                        }
                    }
                }
            }

            if (Skin.m_objectSpaceDeformer.m_twoBlendEntries.Count > 0)
            {
                foreach (var eb in Skin.m_objectSpaceDeformer.m_twoBlendEntries)
                {
                    List<BlendEntry> blendEntries = new List<BlendEntry>();

                    blendEntries.Add(new BlendEntry() { 
                        Vertex = eb.m_vertexIndices_0,
                        SkinCount = 2,
                        Bone_1 = eb.m_boneIndices_0, Bone_2 = eb.m_boneIndices_1,
                        Weight_1 = eb.m_boneWeights_0, Weight_2 = eb.m_boneWeights_1,
                    });
                    blendEntries.Add(new BlendEntry() { 
                        Vertex = eb.m_vertexIndices_1,
                        SkinCount = 2,
                        Bone_1 = eb.m_boneIndices_2, Bone_2 = eb.m_boneIndices_3,
                        Weight_1 = eb.m_boneWeights_2, Weight_2 = eb.m_boneWeights_3,
                    });
                    blendEntries.Add(new BlendEntry() { 
                        Vertex = eb.m_vertexIndices_2,
                        SkinCount = 2,
                        Bone_1 = eb.m_boneIndices_4, Bone_2 = eb.m_boneIndices_5,
                        Weight_1 = eb.m_boneWeights_4, Weight_2 = eb.m_boneWeights_5,
                    });
                    blendEntries.Add(new BlendEntry() { 
                        Vertex = eb.m_vertexIndices_3,
                        SkinCount = 2,
                        Bone_1 = eb.m_boneIndices_6, Bone_2 = eb.m_boneIndices_7,
                        Weight_1 = eb.m_boneWeights_6, Weight_2 = eb.m_boneWeights_7,
                    });
                    blendEntries.Add(new BlendEntry() { 
                        Vertex = eb.m_vertexIndices_4,
                        SkinCount = 2,
                        Bone_1 = eb.m_boneIndices_8, Bone_2 = eb.m_boneIndices_9,
                        Weight_1 = eb.m_boneWeights_8, Weight_2 = eb.m_boneWeights_9,
                    });
                    blendEntries.Add(new BlendEntry() { 
                        Vertex = eb.m_vertexIndices_5,
                        SkinCount = 2,
                        Bone_1 = eb.m_boneIndices_10, Bone_2 = eb.m_boneIndices_11,
                        Weight_1 = eb.m_boneWeights_10, Weight_2 = eb.m_boneWeights_11,
                    });
                    blendEntries.Add(new BlendEntry() { 
                        Vertex = eb.m_vertexIndices_6,
                        SkinCount = 2,
                        Bone_1 = eb.m_boneIndices_12, Bone_2 = eb.m_boneIndices_13,
                        Weight_1 = eb.m_boneWeights_12, Weight_2 = eb.m_boneWeights_13,
                    });
                    blendEntries.Add(new BlendEntry() { 
                        Vertex = eb.m_vertexIndices_7,
                        SkinCount = 2,
                        Bone_1 = eb.m_boneIndices_14, Bone_2 = eb.m_boneIndices_15,
                        Weight_1 = eb.m_boneWeights_14, Weight_2 = eb.m_boneWeights_15,
                    });
                    blendEntries.Add(new BlendEntry() { 
                        Vertex = eb.m_vertexIndices_8,
                        SkinCount = 2,
                        Bone_1 = eb.m_boneIndices_16, Bone_2 = eb.m_boneIndices_17,
                        Weight_1 = eb.m_boneWeights_16, Weight_2 = eb.m_boneWeights_17,
                    });
                    blendEntries.Add(new BlendEntry() { 
                        Vertex = eb.m_vertexIndices_9,
                        SkinCount = 2,
                        Bone_1 = eb.m_boneIndices_18, Bone_2 = eb.m_boneIndices_19,
                        Weight_1 = eb.m_boneWeights_18, Weight_2 = eb.m_boneWeights_19,
                    });
                    blendEntries.Add(new BlendEntry() { 
                        Vertex = eb.m_vertexIndices_10,
                        SkinCount = 2,
                        Bone_1 = eb.m_boneIndices_20, Bone_2 = eb.m_boneIndices_21,
                        Weight_1 = eb.m_boneWeights_20, Weight_2 = eb.m_boneWeights_21,
                    });
                    blendEntries.Add(new BlendEntry() { 
                        Vertex = eb.m_vertexIndices_11,
                        SkinCount = 2,
                        Bone_1 = eb.m_boneIndices_22, Bone_2 = eb.m_boneIndices_23,
                        Weight_1 = eb.m_boneWeights_22, Weight_2 = eb.m_boneWeights_23,
                    });
                    blendEntries.Add(new BlendEntry() { 
                        Vertex = eb.m_vertexIndices_12,
                        SkinCount = 2,
                        Bone_1 = eb.m_boneIndices_24, Bone_2 = eb.m_boneIndices_25,
                        Weight_1 = eb.m_boneWeights_24, Weight_2 = eb.m_boneWeights_25,
                    });
                    blendEntries.Add(new BlendEntry() { 
                        Vertex = eb.m_vertexIndices_13,
                        SkinCount = 2,
                        Bone_1 = eb.m_boneIndices_26, Bone_2 = eb.m_boneIndices_27,
                        Weight_1 = eb.m_boneWeights_26, Weight_2 = eb.m_boneWeights_27,
                    });
                    blendEntries.Add(new BlendEntry() { 
                        Vertex = eb.m_vertexIndices_14,
                        SkinCount = 2,
                        Bone_1 = eb.m_boneIndices_28, Bone_2 = eb.m_boneIndices_29,
                        Weight_1 = eb.m_boneWeights_28, Weight_2 = eb.m_boneWeights_29,
                    });
                    blendEntries.Add(new BlendEntry() { 
                        Vertex = eb.m_vertexIndices_15,
                        SkinCount = 2,
                        Bone_1 = eb.m_boneIndices_30, Bone_2 = eb.m_boneIndices_31,
                        Weight_1 = eb.m_boneWeights_30, Weight_2 = eb.m_boneWeights_31,
                    });


                    if (blend.blendEntries == null || blend.blendEntries.Count <= 0)
                        blend.blendEntries = blendEntries;
                    else
                    {
                        foreach (var entry in blendEntries)
                        {
                            blend.blendEntries.Add(entry);
                        }
                    }
                }
            }

            if (Skin.m_objectSpaceDeformer.m_oneBlendEntries.Count > 0)
            {
                foreach (var eb in Skin.m_objectSpaceDeformer.m_oneBlendEntries)
                {
                    List<BlendEntry> blendEntries = new List<BlendEntry>();

                    blendEntries.Add(new BlendEntry() { Vertex = eb.m_vertexIndices_0, SkinCount = 1, Bone_1 = eb.m_boneIndices_0, Weight_1 = 255 });
                    blendEntries.Add(new BlendEntry() { Vertex = eb.m_vertexIndices_1, SkinCount = 1, Bone_1 = eb.m_boneIndices_1, Weight_1 = 255 });
                    blendEntries.Add(new BlendEntry() { Vertex = eb.m_vertexIndices_2, SkinCount = 1, Bone_1 = eb.m_boneIndices_2, Weight_1 = 255 });
                    blendEntries.Add(new BlendEntry() { Vertex = eb.m_vertexIndices_3, SkinCount = 1, Bone_1 = eb.m_boneIndices_3, Weight_1 = 255 });
                    blendEntries.Add(new BlendEntry() { Vertex = eb.m_vertexIndices_4, SkinCount = 1, Bone_1 = eb.m_boneIndices_4, Weight_1 = 255 });
                    blendEntries.Add(new BlendEntry() { Vertex = eb.m_vertexIndices_5, SkinCount = 1, Bone_1 = eb.m_boneIndices_5, Weight_1 = 255 });
                    blendEntries.Add(new BlendEntry() { Vertex = eb.m_vertexIndices_6, SkinCount = 1, Bone_1 = eb.m_boneIndices_6, Weight_1 = 255 });
                    blendEntries.Add(new BlendEntry() { Vertex = eb.m_vertexIndices_7, SkinCount = 1, Bone_1 = eb.m_boneIndices_7, Weight_1 = 255 });
                    blendEntries.Add(new BlendEntry() { Vertex = eb.m_vertexIndices_8, SkinCount = 1, Bone_1 = eb.m_boneIndices_8, Weight_1 = 255 });
                    blendEntries.Add(new BlendEntry() { Vertex = eb.m_vertexIndices_9, SkinCount = 1, Bone_1 = eb.m_boneIndices_9, Weight_1 = 255 });
                    blendEntries.Add(new BlendEntry() { Vertex = eb.m_vertexIndices_10, SkinCount = 1, Bone_1 = eb.m_boneIndices_10, Weight_1 = 255 });
                    blendEntries.Add(new BlendEntry() { Vertex = eb.m_vertexIndices_11, SkinCount = 1, Bone_1 = eb.m_boneIndices_11, Weight_1 = 255 });
                    blendEntries.Add(new BlendEntry() { Vertex = eb.m_vertexIndices_12, SkinCount = 1, Bone_1 = eb.m_boneIndices_12, Weight_1 = 255 });
                    blendEntries.Add(new BlendEntry() { Vertex = eb.m_vertexIndices_13, SkinCount = 1, Bone_1 = eb.m_boneIndices_13, Weight_1 = 255 });
                    blendEntries.Add(new BlendEntry() { Vertex = eb.m_vertexIndices_14, SkinCount = 1, Bone_1 = eb.m_boneIndices_14, Weight_1 = 255 });
                    blendEntries.Add(new BlendEntry() { Vertex = eb.m_vertexIndices_15, SkinCount = 1, Bone_1 = eb.m_boneIndices_15, Weight_1 = 255 });



                    if (blend.blendEntries == null || blend.blendEntries.Count <= 0)
                        blend.blendEntries = blendEntries;
                    else
                    {
                        foreach (var entry in blendEntries)
                        {
                            blend.blendEntries.Add(entry);
                        }
                    }
                }
            }

            List<SkinVert> verts = new List<SkinVert>();

            foreach (var unps in Skin.m_localUnpackedPs)
            {
                verts.Add(new SkinVert() { X = unps.m_localPosition_0.X, Y = unps.m_localPosition_0.Y, Z = unps.m_localPosition_0.X});
                verts.Add(new SkinVert() { X = unps.m_localPosition_1.X, Y = unps.m_localPosition_1.Y, Z = unps.m_localPosition_1.X });
                verts.Add(new SkinVert() { X = unps.m_localPosition_2.X, Y = unps.m_localPosition_2.Y, Z = unps.m_localPosition_2.X });
                verts.Add(new SkinVert() { X = unps.m_localPosition_3.X, Y = unps.m_localPosition_3.Y, Z = unps.m_localPosition_3.X });
                verts.Add(new SkinVert() { X = unps.m_localPosition_4.X, Y = unps.m_localPosition_4.Y, Z = unps.m_localPosition_4.X });
                verts.Add(new SkinVert() { X = unps.m_localPosition_5.X, Y = unps.m_localPosition_5.Y, Z = unps.m_localPosition_5.X });
                verts.Add(new SkinVert() { X = unps.m_localPosition_6.X, Y = unps.m_localPosition_6.Y, Z = unps.m_localPosition_6.X });
                verts.Add(new SkinVert() { X = unps.m_localPosition_7.X, Y = unps.m_localPosition_7.Y, Z = unps.m_localPosition_7.X });
                verts.Add(new SkinVert() { X = unps.m_localPosition_8.X, Y = unps.m_localPosition_8.Y, Z = unps.m_localPosition_8.X });
                verts.Add(new SkinVert() { X = unps.m_localPosition_9.X, Y = unps.m_localPosition_9.Y, Z = unps.m_localPosition_9.X });
                verts.Add(new SkinVert() { X = unps.m_localPosition_10.X, Y = unps.m_localPosition_10.Y, Z = unps.m_localPosition_10.X });
                verts.Add(new SkinVert() { X = unps.m_localPosition_11.X, Y = unps.m_localPosition_11.Y, Z = unps.m_localPosition_11.X });
                verts.Add(new SkinVert() { X = unps.m_localPosition_12.X, Y = unps.m_localPosition_12.Y, Z = unps.m_localPosition_12.X });
                verts.Add(new SkinVert() { X = unps.m_localPosition_13.X, Y = unps.m_localPosition_13.Y, Z = unps.m_localPosition_13.X });
                verts.Add(new SkinVert() { X = unps.m_localPosition_14.X, Y = unps.m_localPosition_14.Y, Z = unps.m_localPosition_14.X });
                verts.Add(new SkinVert() { X = unps.m_localPosition_15.X, Y = unps.m_localPosition_15.Y, Z = unps.m_localPosition_15.X });
            }

            foreach (BlendEntry entry in blend.blendEntries)
            {
                //Add the XYZ locations for each vert to pair them with the particles later
                entry.X = verts[entry.Vertex].X;
                entry.Y = verts[entry.Vertex].Y;
                entry.Z = verts[entry.Vertex].Z;

                //Filter the bone indexes through the transform subset to get the real skeleton index 
                entry.Bone_1 = Skin.m_transformSubset[entry.Bone_1];
                if (entry.SkinCount > 1)
                {
                    entry.Bone_2 = Skin.m_transformSubset[entry.Bone_2];
                    if (entry.SkinCount > 2)
                    {
                        entry.Bone_3 = Skin.m_transformSubset[entry.Bone_3];
                        if (entry.SkinCount > 4)
                            entry.Bone_4 = Skin.m_transformSubset[entry.Bone_4];
                    }
                }
            }

            return blend;
        }
    }

    public class BlendEntry
    {
        ///BOTW usually only has 4 skin count, but this list can be expanded to fit all 8 
        ///each blend data list contains info for vertices and the bones and weights it ties to
        public int Vertex { get; set; } = 0;
        public int SkinCount { get; set; } = 0;
        public float X { get; set; } = 0;
        public float Y { get; set; } = 0;
        public float Z { get; set; } = 0;
        public int Bone_1 {  get; set; } = 0;
        public int Bone_2 {  get; set; } = 0;
        public int Bone_3 {  get; set; } = 0;
        public int Bone_4 {  get; set; } = 0;
        public uint Weight_1 {  get; set; } = 0;
        public uint Weight_2 {  get; set; } = 0;
        public uint Weight_3 {  get; set; } = 0;
        public uint Weight_4 { get; set; } = 0;
    }

    public class SkinVert
    {
        public float X {  get; set; }
        public float Y {  get; set; }
        public float Z {  get; set; }
    }
}
