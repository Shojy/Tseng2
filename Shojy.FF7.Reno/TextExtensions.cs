﻿using System.Text;

namespace Shojy.FF7.Reno;

[PublicAPI]
public static class TextExtensions
{
    private static readonly Dictionary<byte, byte> Lookup = new()
    {
        {0x0,0x20},
        {0x1,0x21},
        {0x2,0x22},
        {0x3,0x23},
        {0x4,0x24},
        {0x5,0x25},
        {0x6,0x26},
        {0x7,0x27},
        {0x8,0x28},
        {0x9,0x29},
        {0xA,0x2A},
        {0xB,0x2B},
        {0xC,0x2C},
        {0xD,0x2D},
        {0xE,0x2E},
        {0xF,0x2F},
        {0x10,0x30},
        {0x11,0x31},
        {0x12,0x32},
        {0x13,0x33},
        {0x14,0x34},
        {0x15,0x35},
        {0x16,0x36},
        {0x17,0x37},
        {0x18,0x38},
        {0x19,0x39},
        {0x1A,0x3A},
        {0x1B,0x3B},
        {0x1C,0x3C},
        {0x1D,0x3D},
        {0x1E,0x3E},
        {0x1F,0x3F},
        {0x20,0x40},
        {0x21,0x41},
        {0x22,0x42},
        {0x23,0x43},
        {0x24,0x44},
        {0x25,0x45},
        {0x26,0x46},
        {0x27,0x47},
        {0x28,0x48},
        {0x29,0x49},
        {0x2A,0x4A},
        {0x2B,0x4B},
        {0x2C,0x4C},
        {0x2D,0x4D},
        {0x2E,0x4E},
        {0x2F,0x4F},
        {0x30,0x50},
        {0x31,0x51},
        {0x32,0x52},
        {0x33,0x53},
        {0x34,0x54},
        {0x35,0x55},
        {0x36,0x56},
        {0x37,0x57},
        {0x38,0x58},
        {0x39,0x59},
        {0x3A,0x5A},
        {0x3B,0x5B},
        {0x3C,0x5C},
        {0x3D,0x5D},
        {0x3E,0x5E},
        {0x3F,0x5F},
        {0x40,0x60},
        {0x41,0x61},
        {0x42,0x62},
        {0x43,0x63},
        {0x44,0x64},
        {0x45,0x65},
        {0x46,0x66},
        {0x47,0x67},
        {0x48,0x68},
        {0x49,0x69},
        {0x4A,0x6A},
        {0x4B,0x6B},
        {0x4C,0x6C},
        {0x4D,0x6D},
        {0x4E,0x6E},
        {0x4F,0x6F},
        {0x50,0x70},
        {0x51,0x71},
        {0x52,0x72},
        {0x53,0x73},
        {0x54,0x74},
        {0x55,0x75},
        {0x56,0x76},
        {0x57,0x77},
        {0x58,0x78},
        {0x59,0x79},
        {0x5A,0x7A},
        {0x5B,0x7B},
        {0x5C,0x7C},
        {0x5D,0x7D},
        {0x5E,0x7E},
        {0x5F,0x7F},
        {0x60,0x84},
        {0x61,0x81},
        {0x62,0x87},
        {0x63,0x89},
        {0x64,0x91},
        {0x65,0x96},
        {0x66,0x9C},
        {0x67,0xA1},
        {0x68,0xA0},
        {0x69,0xA2},
        {0x6A,0xA4},
        {0x6B,0xA3},
        {0x6C,0xA5},
        {0x6D,0xA7},
        {0x6E,0xA9},
        {0x6F,0xA8},
        {0x70,0xAA},
        {0x71,0xAB},
        {0x72,0xAD},
        {0x73,0xAC},
        {0x74,0xAE},
        {0x75,0xAF},
        {0x76,0xB1},
        {0x77,0xB3},
        {0x78,0xB2},
        {0x79,0xB4},
        {0x7A,0xB6},
        {0x7B,0xB5},
        {0x7C,0xBA},
        {0x7D,0xB9},
        {0x7E,0xBB},
        {0x7F,0xBC},
        {0x84,0x99},
        {0x85,0x9B},
        {0x87,0x9F},
        {0x8E,0x86},
        {0x8F,0x98},
        {0x9E,0xA6},
        {0x9F,0xB8},
        {0xAA,0x3F},
        {0xAB,0x80},
        {0xAD,0x95},
        {0xB6,0xB7},
        {0xB8,0xBF},
        {0xC5,0x82},
        {0xC6,0x8A},
        {0xC7,0x8B},
        {0xC8,0x81},
        {0xC9,0x88},
        {0xCA,0xAD},
        {0xCB,0xAE},
        {0xCC,0xAF},
        {0xCD,0xAC},
        {0xCE,0x93},
        {0xCF,0x94},
        {0xD1,0x92},
        {0xD2,0x99},
        {0xD3,0x9B},


    };


    public static string ToFFString(this byte[] bytes)
    {
        var length = bytes.Length;
        var text = new List<byte>();

        for (var chr = 0; chr < length; ++chr)
        {
            if (Lookup.ContainsKey(bytes[chr]))
            {
                text.Add(Lookup[bytes[chr]]);
                continue;
            }

            if (bytes[chr] == 0xEA)
            {
                text.AddRange(Encoding.ASCII.GetBytes("{Cloud}"));
            }
            else if (bytes[chr] == 0xEB)
            {
                text.AddRange(Encoding.ASCII.GetBytes("{Barret}"));
            }
            else if (bytes[chr] == 0xEC)
            {
                text.AddRange(Encoding.ASCII.GetBytes("{Tifa}"));
            }
            else if (bytes[chr] == 0xED)
            {
                text.AddRange(Encoding.ASCII.GetBytes("{Aeris}"));
            }
            else if (bytes[chr] == 0xEE)
            {
                text.AddRange(Encoding.ASCII.GetBytes("{Red XIII}"));
            }
            else if (bytes[chr] == 0xEF)
            {
                text.AddRange(Encoding.ASCII.GetBytes("{Yuffie}"));
            }
            else if (bytes[chr] == 0xF0)
            {
                text.AddRange(Encoding.ASCII.GetBytes("{Cait Sith}"));
            }
            else if (bytes[chr] == 0xF1)
            {
                text.AddRange(Encoding.ASCII.GetBytes("{Vincent}"));
            }
            else if (bytes[chr] == 0xF2)
            {
                text.AddRange(Encoding.ASCII.GetBytes("{Cid}"));
            }
            else if (bytes[chr] == 0xF3)
            {
                text.AddRange(Encoding.ASCII.GetBytes("{Party 1}"));
            }
            else if (bytes[chr] == 0xF4)
            {
                text.AddRange(Encoding.ASCII.GetBytes("{Party 2}"));
            }
            else if (bytes[chr] == 0xF5)
            {
                text.AddRange(Encoding.ASCII.GetBytes("{Party 3}"));
            }
            else if (bytes[chr] < 0xFE || bytes[chr] == 0xF8)
            {
                // This is a function with a parameter following. We can skip both.
                ++chr;
            }
            else if (bytes[chr] == 0xFF)
            {
                // That's all folks!
                break;
            }
            else
            {
                text.Add(0x3F);
            }
        }

        return Encoding.ASCII.GetString(text.ToArray());
    }
}