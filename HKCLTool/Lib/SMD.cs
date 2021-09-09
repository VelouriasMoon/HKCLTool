using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKCLTool.Lib
{
    class SMD
    {
        public List<Nodes> nodes { get; set; }
        public List<Skeleton> skeleton { get; set; }
        public List<Triangles> triangles {  get; set; }

        public string[] WriteSMD()
        {
            List<string> smd = new List<string>();
            smd.Add("version 1");
            smd.Add("nodes");
            foreach (Nodes node in nodes)
            {
                smd.Add(node.Write());
            }
            smd.Add("end");
            smd.Add("skeleton");
            smd.Add("time 0");
            foreach (Skeleton bone in skeleton)
            {
                smd.Add(bone.Write());
            }
            smd.Add("end");
            smd.Add("triangles");
            foreach (Triangles tri in triangles)
            {
                smd.Add(tri.Write());
            }
            smd.Add("end");
            return smd.ToArray();
        }

        public class Nodes
        {
            public int ID { get; set; } = 0;
            public string Name { get; set; } = "ROOT";
            public int Parent {  get; set; } = -1;

            public string Write()
            {
                return $"{ID} \"{Name}\" {Parent}";
            }
        }

        public class Skeleton
        {
            public int ID {  get; set; } = 0;
            public float PosX {  get; set; } = 0;
            public float PosY {  get; set; } = 0;
            public float PosZ {  get; set; } = 0;
            public float RotX {  get; set; } = 0;
            public float RotY {  get; set; } = 0;
            public float RotZ {  get; set; } = 0;

            public string Write()
            {
                return $"{ID} {PosX} {PosY} {PosZ} {RotX} {RotY} {RotZ}";
            }
        }

        public class Triangles
        {
            public string Material { get; set; }
            public List<Vertex> Vertices {  get; set; }

            public string Write()
            {
                if (Vertices.Count < 3)
                    return null;

                return $"{Material}\n{Vertices[0].Write()}\n{Vertices[1].Write()}\n{Vertices[2].Write()}";
            }
        }

        public class Links
        {
            public int BoneID {  get; set; }
            public float Weight {  get; set; }
        }

        public class Vertex
        {
            public int ParentBone { get; set; }
            public float PosX { get; set; }
            public float PosY { get; set; }
            public float PosZ { get; set; }
            public float NormX { get; set; } = 0;
            public float NormY { get; set; } = 0;
            public float NormZ { get; set; } = 0;
            public float U { get; set; } = 0;
            public float V { get; set; } = 0;
            public List<Links> links { get; set; }

            public string Write()
            {
                string weights = "";
                if (links.Count > 0)
                {
                    weights = $" {links.Count}";
                    foreach (var link in links)
                    {
                        weights = $"{weights} {link.BoneID} {link.Weight}";
                    }
                }
                return $"{ParentBone} {PosX} {PosY} {PosZ} {NormX} {NormY} {NormZ}{weights}";
            }
        }
    }
}
