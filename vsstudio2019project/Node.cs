﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMD_Graph_Studio
{
    class Node
    {
        private readonly String name;
        private readonly UInt64 id;

        public Node(String name)
        {
            this.name = name;
            this.id = IDGenerator.GetNextID();
        }

        public Node(byte[] raw, int length, int offset)
        {
            this.id = BitConverter.ToUInt64(raw, offset);
            this.name = ASCIIEncoding.UTF8.GetString(raw, offset + 8, length - 8);
        }

        public String GetName()
        {
            return this.name;
        }

        public byte[] getAsBytes()
        {
            int strbytes = ASCIIEncoding.UTF8.GetByteCount(this.name);
            byte[] result = new byte[strbytes + 8];
            byte[] idbytes = BitConverter.GetBytes(this.id);
            for(int i=0;i<8;i++)
            {
                result[i] = idbytes[i];
            }
            ASCIIEncoding.UTF8.GetBytes(this.name, 0, this.name.Length, result, 8);
            return result;
        }

        

        public UInt64 GetID()
        {
            return this.id;
        }
    }
}